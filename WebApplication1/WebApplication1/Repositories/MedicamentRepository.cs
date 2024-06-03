using Microsoft.EntityFrameworkCore;
using WebApplication1.DTO;
using WebApplication1.Entities;

namespace WebApplication1.Repositories;

public class MedicamentRepository : IMedicamentRepository
{
    private readonly HospitalDbContext _context;

    public MedicamentRepository(HospitalDbContext context)
    {
        _context = context;
    }
    
    public async Task<bool> DoesMedicamentExist(int idMedicament)
    {
        return _context.Medicaments.Any(m => m.IdMedicament == idMedicament);
    }
}