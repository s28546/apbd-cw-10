using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly HospitalDbContext _context;

    public PatientRepository(HospitalDbContext context)
    {
        _context = context;
    }

    public async Task<bool> DoesPatientExist(int patientId)
    {
        return await _context.Patients.AnyAsync(p => p.IdPatient == patientId);

    }
    
    public async Task AddPatient(Patient patient)
    {
        _context.Patients.Add(patient);
        await _context.SaveChangesAsync();
    }
}