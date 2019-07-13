''' <summary>
''' This class contains fields required by Abbott for their calaculations.
''' </summary>
Public Class AbbottDataCollectionFormat

#Region "Properties"


    'Site where request and phebotomy is done.
    Public Property RequestingSite As String

    'Identification of the phlebotomy occasion (Patient information/number need to be cryptated,
    'so that there Is no possibility To track the information To any individual. 
    'This can be done by adding And/Or multiplying any secret numbers To the patient number)
    Public Property PatientId As Integer
        Get
            Return _PatientId
        End Get
        Set
            _PatientId = Value * 2 'The so called 'cryptated' acheived by multiplying by two
        End Set
    End Property

    'Identification of Request or sample ID
    Public Property SampleId As String

    'Time of sample arrival to laboratory
    Public Property ReceivedDateTime As DateTime?

    'Number or character as a prefix or suffix to Sample ID that can distinguish between different tube types (EDTA, serum, plasma etc.)
    Public Property TubeExt As String

    'What type of sample this is (Coag, Wholeblood, Serum, plasma etc.)
    Public Property SampleType As String

    'If tube are pre-centrifuged or not before arrival to the laboratory (Yes or No)
    Public Property IsCentrifuged As Boolean

    'Assay Code
    Public Property AssayCode As String

    'Assay Name
    Public Property AssayName As String

    'Priority: STAT or Routine
    Public Property Priority As Priority

    'Date and Time when the phlebotomy took place
    Public Property CollectionDateTime As DateTime?

    'Write Only Type of instrument performing the test
    Public WriteOnly Property InstrumentType As String
        Set
            _InstrumentType = Value
        End Set
    End Property

    'Write only ID of instrument performing the test
    Public WriteOnly Property InstrumentID As String
        Set
            _InstrumentID = Value
        End Set
    End Property

    'ReadOnly Indtrument Id and Instrument type as required by Abbott. Either one is fine... actually.
    Public ReadOnly Property InstrumentIdAndInstrumentType As String
        Get
            Return _InstrumentID & "/" & _InstrumentType
        End Get
    End Property

    'Date and Time for technical validation.
    Public Property TechnicalValidationDateTime As DateTime?

    'Date and time when the result was reported to clinician/Clinical Validation
    Public Property ResultDateTime As DateTime?

#End Region

#Region "Backend properties"
    Private _PatientId As Integer
    Private _InstrumentType As String
    Private _InstrumentID As String
#End Region

End Class

