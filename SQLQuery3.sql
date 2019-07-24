insert into dbo.InitialDataPrep([MachineParameter],[LabTest],[RequestingSite],[SampleId],[PatientId],[Priority],[SampleType],[TestCode],[AssayName],[TubeExt],[IsCentrifuged],[AssayCode],[InstrumentType])
select distinct(m.MachineParameter),m.LabTest, h.ServiceLocation,h.Barcode,h.Patients_id+10 AS Patient_Id,h.[Priority],h.SampleType,h.TestCode,h.TestName,t.Code AS TubeExt,m.IsCetrifuged, m.ParamCode,m.Instrument
from dbo.SampleHistory h
inner join dbo.ParametersMap m on (m.TestCode = h.TestCode) AND (m.LabTest = h.TestName)
inner join dbo.SampleType t on t.SampleType = h.SampleType
WHERE (h.created_at BETWEEN '20190708' AND '20190716') AND (h.SampleStatus NOT  LIKE '%REJ%')
group by m.MachineParameter,m.LabTest, h.ServiceLocation,h.Barcode,h.[Priority],h.SampleStatus,h.SampleType,h.TestCode,h.TestName,h.Patients_id,t.Code, m.IsCetrifuged,m.ParamCode,m.Instrument
