Imports System.Data.SqlClient
Imports Dapper

Public Class SqlDataAccess
    Private Shared ReadOnly log As log4net.ILog = log4net.LogManager.GetLogger(Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    'Public Shared Function LoadRequests() As List(Of LisRequestDataModel)
    '    Using cnn As IDbConnection = New SQLiteConnection(Helper.GetConnectionString("localdb", True))
    '        Dim Output As List(Of LisRequestDataModel) = cnn.Query(Of LisRequestDataModel)("SELECT * FROM [AnalysisRequest]", New DynamicParameters)
    '        Return Output.ToList
    '    End Using
    'End Function
    'Public Shared Sub DeleteRequest(Barcode As String)
    '    Dim Parameter = New With {Key .Barcode = Barcode}
    '    Using cnn As IDbConnection = New SQLiteConnection(Helper.GetConnectionString("localdb", True))
    '        cnn.Execute("DELETE FROM [AnalysisRequest] WHERE Barcode = @Barcode", Parameter)
    '    End Using
    'End Sub

    Public Shared Function LoadDistinctBarcodes() As List(Of DistinctSampleId)
        log.Info("Loading Distinct Sample Ids")
        Using cnn As IDbConnection = New SqlConnection(Helper.GetConnectionString("Abbott"))
            Dim Output As List(Of DistinctSampleId) = cnn.Query(Of DistinctSampleId)("SELECT DISTINCT(SampleId) FROM dbo.InitialDataPrep")
            log.Info("Number of distinct sample Ids: " & Output.Count)
            Return Output
        End Using
    End Function

    Public Shared Function RunWildSQL(e As RunWildArgs) As Object
        log.Info("Running wild sql: " & e.WildSQL)
        Using cnn As IDbConnection = New SqlConnection(Helper.GetConnectionString("Abbott"))
            Dim Output As List(Of EventTimings) = cnn.Query(Of EventTimings)(e.WildSQL)
            log.Info("Completed Wild SQL!")
            Return Output
        End Using
    End Function

    Public Shared Sub UploadResultLogAttributes(e As List(Of ResultsLogAttributes))
        For Each ResulLog In e
            Using cnn As IDbConnection = New SqlConnection(Helper.GetConnectionString("Abbott"))
                cnn.Execute("INSERT INTO [AnalysisRequest] ([Barcode],[PatientNo],[PatientName],[Genders_id],[DateOfBirth],[created_at]) values (@Barcode,@PatientNo,@PatientName,@Genders_id,@DateOfBirth,@created_at)", ResulLog)
            End Using
        Next
    End Sub
End Class

