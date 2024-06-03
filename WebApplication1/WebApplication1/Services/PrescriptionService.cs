using WebApplication1.DTO;
using WebApplication1.Entities;
using WebApplication1.Repositories;

namespace WebApplication1.Services;

public class PrescriptionService : IPrescriptionService
{
    private readonly IPrescriptionRepository _prescriptionRepository;

    public PrescriptionService(IPrescriptionRepository prescriptionRepository)
    {
        _prescriptionRepository = prescriptionRepository;
    }

    public async Task<Prescription?> CreatePrescription(PrescriptionDTO prescriptionDTO)
    {
        return await _prescriptionRepository.CreatePrescription(prescriptionDTO);
    }
}