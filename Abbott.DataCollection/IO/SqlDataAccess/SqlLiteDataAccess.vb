Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports Dapper
Public Class SqLiteDataAccess
    Private Shared ReadOnly log As log4net.ILog = log4net.LogManager.GetLogger(Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Public Shared Function IsSamplePresent(e As ResultsLogAttributes) As SampleStatus
        'SELECT Id, SampleNumber FROM SampleLog
        log.Info($"Query for the sample ({e.SampleNumber}) on localDb")
        Dim Output As New List(Of SampleStatus)
        Using cnn As IDbConnection = New SQLiteConnection(Helper.GetConnectionString("AbbottLLocalDb"))
            Output = cnn.Query(Of SampleStatus)("SELECT Id, SampleNumber FROM SampleLog WHERE SampleNumber = @SampleNumber", e).ToList()
        End Using
        log.Info($"Sample count: {Output.Count}")

        Select Case Output.Count
            Case > 1
                log.Error($"Multiple records for the sample sample exists. Number of records: {Output.Count}")
                Return Output.First
            Case 1
                Return Output.First
            Case 0
                Return New SampleStatus
            Case Else
                log.Fatal("Unrecognized state.")
                Throw New Exception("Sample presence check in an unrecognized state." & vbCrLf & e.SampleNumber & vbCrLf & e.AnalyteList(0).FilePath)
        End Select
    End Function
    Public Shared Function UploadSampleReturnInserted(e As ResultsLogAttributes) As SampleStatus

        Dim status As New SampleStatus
        Dim Upload As Integer = 0
        log.Info($"Upload sample: {e.SampleNumber}")
        Using cnn As IDbConnection = New SQLiteConnection(Helper.GetConnectionString("AbbottLLocalDb"))
            Upload = cnn.Execute("INSERT INTO [SampleLog] ([FileExtension],[SampleNumber]) values (@FileExtension, @SampleNumber)", e)
        End Using
        Select Case Upload
            Case 1
                log.Info($"Sample: {e.SampleNumber} upload successful, number of records inserted: {Upload}")
                log.Info("Fetch the uploaded data.")
                status = IsSamplePresent(e)
            Case 0
                log.Error($"Returned number of uploaded sample(s) is: {Upload}")
                Throw New Exception($"Number of samples inserted cannot be {Upload}")
        End Select
        Return status
    End Function
End Class

Public Class SampleStatus
    Public Sub New()
        Me.SamplePresent = False
    End Sub
    Private _Id As Integer
    Public Property SamplePresent As Boolean
    Public Property SampleNumber As String

    Public Property Id As Integer
        Get
            Return _Id
        End Get
        Set
            If Not Value = Nothing Then Me.SamplePresent = True
            _Id = Value
        End Set
    End Property
End Class
