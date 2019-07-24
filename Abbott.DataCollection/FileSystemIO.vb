Imports System.IO

Public Class FileSystemIO
    Public Shared Function GetFileNames(path As String) As List(Of String)
        Return Directory.EnumerateFiles(path).ToList
    End Function
End Class