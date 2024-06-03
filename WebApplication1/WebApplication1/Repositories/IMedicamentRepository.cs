using WebApplication1.DTO;

namespace WebApplication1.Repositories;

public interface IMedicamentRepository
{
    public Task<bool> DoesMedicamentExist(int idMedicament);
}