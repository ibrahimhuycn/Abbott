Imports System.Configuration

Public Class Helper
    Private Shared ReadOnly log As log4net.ILog = log4net.LogManager.GetLogger(Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Public Shared Function GetConnectionString(ByVal Optional name As String = "Abbott") As String
        Dim ConnString As String = ConfigurationManager.ConnectionStrings(name).ConnectionString
        log.Info("Connection String" & ConnString)
        Return ConfigurationManager.ConnectionStrings(name).ConnectionString
    End Function
End Class
