Imports CsvHelper.Configuration.Attributes
''' <summary>
''' This class contains fields required by Abbott for their calaculations.
''' </summary>
Public Class AbbottDataCollectionFormat

#Region "Properties"


    'Site where request and phebotomy is done.
    <Name("ServiceLocation")>
    Public Property RequestingSite As String

    'Identification of the phlebotomy occasion (Patient information/number need to be cryptated,
    'so that there Is no possibility To track the information To any individual. 
    'This can be done by adding And/Or multiplying any secret numbers To the patient number)
    <Name("Patients_id")>
    Public Property PatientId As Integer

    'Identification of Request or sample ID
    <Name("Barcode")>
    Public Property SampleId As String

    'Time of sample arrival to laboratory
    ' <Name("Patients_id")>
    Public Property ReceivedDateTime As DateTime?

    'Number or character as a prefix or suffix to Sample ID that can distinguish between different tube types (EDTA, serum, plasma etc.)
    <Name("TubeExt")>
    Public Property TubeExt As String

    'What type of sample this is (Coag, Wholeblood, Serum, plasma etc.)
    <Name("SampleType")>
    Public Property SampleType As String

    'If tube are pre-centrifuged or not before arrival to the laboratory (Yes or No)
    <Name("IsCetrifuged")>
    Public Property IsCentrifuged As Boolean

    'Assay Code
    <Name("ParamCode")>
    Public Property AssayCode As String

    'Assay Name
    <Name("TestName")>
    Public Property AssayName As String

    'Priority: STAT or Routine
    <Name("Priority")>
    Public Property Priority As String

    'Date and Time when the phlebotomy took place
    '<Name("Patients_id")>
    Public Property CollectionDateTime As DateTime?

    'Write Only Type of instrument performing the test
    <Name("Instrument")>
    Public Property InstrumentType As String

    'Date and Time for technical validation.
    '  <Name("Patients_id")>
    Public Property TechnicalValidationDateTime As DateTime?

    'Date and time when the result was reported to clinician/Clinical Validation
    ' <Name("Patients_id")>
    Public Property ResultDateTime As DateTime?

#End Region


End Class

