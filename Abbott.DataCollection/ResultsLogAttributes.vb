﻿
Public Class ResultsLogAttributes

    Public Sub New(filepath As String)
        Me.FilePath = filepath
        Me.FileExtension = Me.FilePath.Split(".")(1)
        Me.AnalyteList = New List(Of LogAnalyteSpecificData)
    End Sub
    Public Property FilePath As String
    Public Property SampleNumber As String
    Public Property FileExtension As String
    Public Property AnalyteList As List(Of LogAnalyteSpecificData)

End Class

Public Class LogAnalyteSpecificData

    Public Property MachineParameter As String
    Public Property TechnicalValidation As DateTime?
End Class