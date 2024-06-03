using WebApplication1.DTO;
using WebApplication1.Entities;

namespace WebApplication1.Repositories;

public interface IPrescriptionRepository
{
    public Task<Prescription?> CreatePrescription(PrescriptionDTO prescription);
}