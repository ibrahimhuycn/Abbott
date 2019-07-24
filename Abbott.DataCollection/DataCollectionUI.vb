<Assembly: log4net.Config.XmlConfigurator(Watch:=True)>
Public Class DataCollectionUI
    Private Shared ReadOnly log As log4net.ILog = log4net.LogManager.GetLogger(Reflection.MethodBase.GetCurrentMethod().DeclaringType)
    Dim _sampleIdList As List(Of DistinctSampleId)
    Dim TotalSteps As Integer = 1
    Dim ProcessPercentage As Integer


    Private Sub ButtonProcessData_Click(sender As Object, e As EventArgs) Handles ButtonProcessData.Click
        If Not BackgroundWorker.IsBusy Then
            BackgroundWorker.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker.DoWork

        log.Info("Step 1: Get a list of distinct sample ids.")

#Region "Step One: Loading distinct sample numbers List, And Report Progress"
        Try
            log.Info("Loading list of sample Ids.")
            _sampleIdList = SqlDataAccess.LoadDistinctBarcodes()
            log.Info("List of sample Ids loaded.")
            BackgroundWorker.ReportProgress(1 / TotalSteps, New ProgressIndicator With {.Report = "List of sample Ids loaded. Sample count: " & _sampleIdList.Count})
        Catch ex As Exception
            log.Debug("Error loading sample Ids list.")
            log.Error(ex.Message & vbCrLf & ex.StackTrace)
        End Try
#End Region


#Region "Step Two: Iterating samples. Fetch Collection, Received, Technicial Validation, and Result date and Time per sample."

        log.Info("Step 2: Iterating samples. Fetch Collection, Received, Technicial Validation, and Result date and Time per sample.")

        Dim BaseWildQuery As String = "SELECT MIN(h.created_at) AS {ColumnName} FROM dbo.SampleHistory h " &
                                     "WHERE (h.Barcode = 'SampleNumber') AND (h.SampleStatus = 'SampleStatusString')"

        log.Info("Base Wild Query Statement: " & BaseWildQuery)
        Dim NumberOfSteps As Integer = _sampleIdList.Count
        Dim Counter As Integer = 1

        For Each Sample In _sampleIdList
            Dim FetchStatus As String = "Sample Created"

            log.Info("Getting collection time for sample number: " & Sample.SampleId)

            Dim eventCollected As List(Of EventTimings) = SqlDataAccess.RunWildSQL(New RunWildArgs With {
                                     .WildSQL = BaseWildQuery.Replace("SampleNumber", Sample.SampleId).Replace("SampleStatusString", FetchStatus).Replace("{ColumnName}", "Collected")})
            log.Info("Sample: " & Sample.SampleId & ".Collected date and time: " & eventCollected(0).Collected)

            BackgroundWorker.ReportProgress((Counter / NumberOfSteps) * 100,
                                            New ProgressIndicator With {.Report = $"Sample: {Sample.SampleId}. Collected Time: {eventCollected(0).Collected}."})

            log.Info("Getting Accepted Date and time: " & Sample.SampleId)

            FetchStatus = "Sample Accepted"
            Dim eventReceived As List(Of EventTimings) = SqlDataAccess.RunWildSQL(New RunWildArgs With {
                                     .WildSQL = BaseWildQuery.Replace("SampleNumber", Sample.SampleId).Replace("SampleStatusString", FetchStatus).Replace("{ColumnName}", "Received")})
            log.Info("Sample: " & Sample.SampleId & ". Accepted date and time: " & eventReceived(0).Received)

            BackgroundWorker.ReportProgress((Counter / NumberOfSteps) * 100,
                                            New ProgressIndicator With {.Report = $"Sample: {Sample.SampleId}. Received Time: {eventReceived(0).Received}"})


#Region "Technical Validation: Read File paths from disk. Write them to DB"


#End Region


#End Region





            Counter += 1
        Next
        log.Info("Completed Iteration.")

    End Sub

    Private Sub BackgroundWorker_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker.ProgressChanged
        Dim Progress As ProgressIndicator = e.UserState
        LabelProgressDetails.Text = Progress.Report
        ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ButtonOpenLogReader.Click
        Dim LogReader As New FileProcessing With {.Name = "Log Reader"}
        LogReader.Show()
    End Sub
End Class
