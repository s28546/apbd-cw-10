using WebApplication1.DTO;
using WebApplication1.Repositories;

namespace WebApplication1.Services;

public interface IMedicamentService
{
    public Task<bool> DoAllMedsExist(List<MedicamentDTO> medicamentDtos);
}


