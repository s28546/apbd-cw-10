using WebApplication1.DTO;
using WebApplication1.Entities;

namespace WebApplication1.Repositories;

public class PrescriptionRepository : IPrescriptionRepository
{
    private readonly HospitalDbContext _context;

    public PrescriptionRepository(HospitalDbContext context)
    {
        _context = context;
    }

    public async Task<Prescription?> CreatePrescription(PrescriptionDTO prescriptionDTO)
    {
        var prescription = new Prescription
        {
            Date = prescriptionDTO.date,
            DueDate = prescriptionDTO.dueDate,
            IdPatient = prescriptionDTO.patient.IdPatient,
            IdDoctor = prescriptionDTO.idDoctor
        };

        foreach (var medicamentDTO in prescriptionDTO.medicaments)
        {
            var prescriptionMedicament = new PrescriptionMedicament
            {
                IdMedicament = medicamentDTO.IdMedicament,
                Dose = medicamentDTO.Dose,
                Details = medicamentDTO.Details
            };

            prescription.Medicaments.Add(prescriptionMedicament);
        }

        _context.Prescriptions.Add(prescription);
        await _context.SaveChangesAsync();

        return prescription;
    }
}