Imports System.ComponentModel
Imports System.IO

Public Class FileProcessing
    Private Shared ReadOnly log As log4net.ILog = log4net.LogManager.GetLogger(Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Dim FilePathList As List(Of String)
    'Private BasePath As String = "C:\Users\ibrah\Music\"
    Private BasePath As String = "C:\Users\ibrah\OneDrive\Documents\AbbottData\OrdersResultsLogs\ResultLog\"

    Private Sub ButtonProcessFiles_Click(sender As Object, e As EventArgs) Handles ButtonProcessFiles.Click
        If Not BackgroundWorkerLogProcessor.IsBusy Then
            ButtonProcessFiles.Enabled = False
            BackgroundWorkerLogProcessor.RunWorkerAsync()
        End If
    End Sub

    Public Shared Sub UploadData(resultsLogAttribute As ResultsLogAttributes)

    End Sub
    Public Shared Function ExtractData(resultsLogAttribute As ResultsLogAttributes) As List(Of ResultsLogAttributes)
        Dim IsExpectingResultFrames As Boolean = False
        Dim SkipResultProcessing As Boolean = False
        Dim ListOfLogs As New List(Of ResultsLogAttributes)
        Dim ResultLog As ResultsLogAttributes


        For Each line In File.ReadLines(resultsLogAttribute.FilePath)

            Dim PredeterminedFrameType As AstmFrameType = DetermineFrameType(line)
            Dim IsFrameValid = IsASTMFrameValid(line, PredeterminedFrameType)

            Select Case PredeterminedFrameType
                Case AstmFrameType.NA
                    IsExpectingResultFrames = False
                Case AstmFrameType.Order

                    If IsFrameValid = True Then
                        IsExpectingResultFrames = True
                        SkipResultProcessing = False
                        log.Info("Processing current ASTM order frame. Frame validity check passed.")
                        If Not ResultLog Is Nothing Then
                            log.Info("Adding the ResultLog to the log list to be returned.")
                            ListOfLogs.Add(ResultLog)
                        End If
                        Dim SampleNumber As String = line.Split("|")(2)
                        ResultLog = New ResultsLogAttributes(resultsLogAttribute.FilePath) With {.SampleNumber = SampleNumber}

                        log.Info($"Created new log instance for a new sample number: {SampleNumber}")
                    Else
                        SkipResultProcessing = True
                        log.Info("Invalid order frame. Skipping all result frames for this number.")
                    End If

                Case AstmFrameType.Result
                    If SkipResultProcessing = False And IsFrameValid = True And IsExpectingResultFrames = True Then
                        Dim Analyte As New LogAnalyteSpecificData
                        log.Info("Processing current ASTM Result frame")

                        Dim machineParameter = line.Split("|")(2).Split("^")(3)
                        Dim TechinicalValidation As String

                        If Not line.Contains("iSR54792") Then
                            TechinicalValidation = line.Split("|")(12).Split("^")(0)
                        Else
                            TechinicalValidation = line.Split("|")(12)
                            log.Warn("Condition applied for SeroIsr iSR54792 while processing field data.")
                        End If
                        Analyte.MachineParameter = machineParameter
                        Analyte.TechnicalValidation = DateTime.ParseExact(TechinicalValidation,
                                                 "yyyyMMddHHmmss", Globalization.CultureInfo.InvariantCulture)

                        log.Info($"Machine Parameter: {machineParameter} ")
                        log.Info($"Technical Validation at: {TechinicalValidation} ")

                        ResultLog.AnalyteList.Add(Analyte)
                        log.Info("Analyte added to the ResultLog")

                    Else

                        Select Case True
                            Case SkipResultProcessing
                                log.Debug($"Skipping result frame processing. Previous order frame is invalid.")

                            Case IsFrameValid = False
                                log.Debug($"Skipping result frame processing. Invalid result frame.")

                            Case IsExpectingResultFrames = False
                                log.Debug($"Skipping result frame processing. Not expecting result frame.")

                        End Select
                    End If

            End Select


        Next
        If Not ResultLog Is Nothing Then
            log.Info("Adding the ResultLog to the log list to be returned.")
            ListOfLogs.Add(ResultLog)
        End If
        log.Info("Completed extracting data.")

        Return ListOfLogs

    End Function

    Private Shared Function IsASTMFrameValid(line As String, predeterminedFrameType As AstmFrameType) As Boolean
        Dim ReturnValue As Boolean = False
        Dim ResultFrameFieldCount As String = "36,41,44,37,31,37,41,44"
        Dim iSR54792ResultFrameFieldCount = 14
        Dim OrderFrameFieldCountMax As Integer = 26
        Dim OrderFrameFieldCountMin As Integer = 4
        Dim FieldCount As Integer = line.Split("|").Count

        Select Case predeterminedFrameType
            Case AstmFrameType.Order
                If FieldCount = OrderFrameFieldCountMax Then ReturnValue = True
                If (FieldCount < OrderFrameFieldCountMax) And (FieldCount > OrderFrameFieldCountMin) Then
                    log.Warn($"Inconsistant order frame length considered as valid. Field count: {FieldCount} ")
                    ReturnValue = True
                End If
            Case AstmFrameType.Result
                Dim ValidLengths() As String = ResultFrameFieldCount.Split(",")
                For Each value In ValidLengths
                    If FieldCount = value Then ReturnValue = True
                Next

                'For sero ISR
                If line.Contains("iSR54792") Then
                    If FieldCount = iSR54792ResultFrameFieldCount Then ReturnValue = True
                    log.Warn("Condition applied for SeroIsr iSR54792 while validating the frame.")
                End If
        End Select
        Return ReturnValue
    End Function

    Private Shared Function DetermineFrameType(line As String) As AstmFrameType
        Dim ReturnValue As AstmFrameType = AstmFrameType.NA
        If line.Split("|")(0).Contains("O") Then ReturnValue = AstmFrameType.Order
        If line.Split("|")(0).Contains("R") Then ReturnValue = AstmFrameType.Result
        If line.Split("|")(0).Contains("C") Then ReturnValue = AstmFrameType.Comment

        Return ReturnValue
    End Function

    Public Enum AstmFrameType
        NA
        Order
        Result
        Comment
    End Enum


    Private Sub BackgroundWorkerLogProcessor_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorkerLogProcessor.DoWork
        Dim TotalSteps As Integer = 1
        log.Info("Initialise an array to hold the attributes.")
        Dim LogFileAttributes As List(Of ResultsLogAttributes) = New List(Of ResultsLogAttributes)

        Try
            log.Info("Trying to read logs from disk.")
            FilePathList = FileSystemIO.GetFileNames(BasePath)
            log.Info($"Successfully read from disk. Number of files: {FilePathList.Count}")

            BackgroundWorkerLogProcessor.ReportProgress(1 / TotalSteps,
                           New ProgressIndicator With {.Report = $"STEP ONE: Read log files from disk. File Count: {FilePathList.Count}"})

            Dim Counter As Integer = 0
            For Each path In FilePathList
                log.Info($"Loading file attributes. {path}")
                Dim extractedData = ExtractData(New ResultsLogAttributes(path))
                For Each resultLog In extractedData
                    LogFileAttributes.Add(resultLog)
                Next

                Counter += 1
                BackgroundWorkerLogProcessor.ReportProgress(Math.Truncate((Counter / FilePathList.Count) * 100),
                           New ProgressIndicator With {.Report = $"Extracting Data: {Counter} of {FilePathList.Count}"})

            Next

        Catch ex As Exception
            BackgroundWorkerLogProcessor.ReportProgress(1 / TotalSteps,
                           New ProgressIndicator With {.Report = $"Error: {ex.Message}"})
            log.Error(ex.Message & vbCrLf & ex.StackTrace)
        End Try

    End Sub

    Private Sub BackgroundWorkerLogProcessor_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorkerLogProcessor.ProgressChanged
        Dim progress As ProgressIndicator = e.UserState
        ProgressBarDataProcess.Value = e.ProgressPercentage
        LabelDataProcessDisplay.Text = progress.Report
    End Sub

    Private Sub BackgroundWorkerLogProcessor_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorkerLogProcessor.RunWorkerCompleted
        ButtonProcessFiles.Enabled = True
    End Sub
End Class
