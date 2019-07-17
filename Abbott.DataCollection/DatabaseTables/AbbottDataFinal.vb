Public Class AbbottDataFinal
    '   	[accepted_at] [datetime] NULL,
    '[collected_at] [datetime] NULL,
    '[TechnicalValidation] [datetime] NULL,
    '[result_at] [datetime]	NULL

    Public Property id As Integer
    Public Property ServiceLocation As String
    Public Property Patients_id As Integer
    Public Property Barcode As String
    Public Property SampleType As String
    Public Property TestCode As String
    Public Property TestName As String
    Public Property Priority As String
    Public Property Remarks As String
    Public Property created_at As DateTime?
    Public Property TubeExt As String
    Public Property IsCentriguged As Boolean
    Public Property InstrumentType As String
End Class
