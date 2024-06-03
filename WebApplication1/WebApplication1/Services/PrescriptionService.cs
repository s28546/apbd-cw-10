using WebApplication1.DTO;
using WebApplication1.Entities;
using WebApplication1.Repositories;

namespace WebApplication1.Services;

public class PrescriptionService : IPrescriptionService
{
    private readonly IPrescriptionRepository _prescriptionRepository;
    private readonly IPatientRepository _patientRepository;
    
    public PrescriptionService(IPrescriptionRepository prescriptionRepository, IPatientRepository patientRepository)
    {
        _prescriptionRepository = prescriptionRepository;
        _patientRepository = patientRepository;
    }

    public async Task<Prescription?> CreatePrescription(PrescriptionDTO prescriptionDTO)
    {
        var patientDTO = prescriptionDTO.patient;
        var patientExists = await _patientRepository.DoesPatientExist(patientDTO.IdPatient);

        if (!patientExists)
        {
            var newPatient = new Patient
            {
                IdPatient = patientDTO.IdPatient,
                FirstName = patientDTO.FirstName,
                LastName = patientDTO.LastName,
                BirthDate = DateTime.UtcNow
            };

            await _patientRepository.AddPatient(newPatient);
        }
        return await _prescriptionRepository.CreatePrescription(prescriptionDTO);
    }
}