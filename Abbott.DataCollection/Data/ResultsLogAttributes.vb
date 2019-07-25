
Public Class ResultsLogAttributes

    Public Sub New(filepath As String)
        Me.FileExtension = filepath.Split(".")(1)
        Me.AnalyteList = New List(Of LogAnalyteSpecificData)
    End Sub
    Public Property SampleNumber As String
    Public Property FileExtension As String
    Public Property AnalyteList As List(Of LogAnalyteSpecificData)

End Class
