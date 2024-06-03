using WebApplication1.DTO;
using WebApplication1.Entities;

namespace WebApplication1.Repositories;

public class PrescriptionRepository : IPrescriptionRepository
{
    private readonly HospitalDbContext _context;
    private readonly IMedicamentRepository _medRepository;
    public readonly IPatientRepository _patientRepository;

    public PrescriptionRepository(HospitalDbContext context, IMedicamentRepository medRepository, IPatientRepository patientRepository)
    {
        _context = context;
        _medRepository = medRepository;
        _patientRepository = patientRepository;
    }

    public async Task<Prescription?> CreatePrescription(PrescriptionDTO prescriptionDTO)
    {
        (Patient patient, List<MedicamentDTO> medicaments, DateTime date, DateTime dueDate) = prescriptionDTO;
        
        if (!await _patientRepository.DoesPatientExist(patient))
        {
            _patientRepository.AddPatient(patient);
        }
        
        var id = GetNewId();
        var prescription = new Prescription
        {
            IdPrescription = id,
            Date = date,
            DueDate = dueDate,
            IdPatient = patient.IdPatient,
            IdDoctor = 1
        };
        _context.Prescriptions.Add(prescription);

        return(prescription);

    }
    private int GetNewId()
    {
        return _context.Prescriptions.Max(x => x.IdPrescription) + 1;
    }
}