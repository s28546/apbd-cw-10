using WebApplication1.DTO;
using WebApplication1.Repositories;

namespace WebApplication1.Services;

public class MedicamentService : IMedicamentService
{
    private readonly IMedicamentRepository _medicamentRepository;

    public MedicamentService(IMedicamentRepository medicamentRepository)
    {
        _medicamentRepository = medicamentRepository;
    }
    
    public async Task<bool> DoAllMedsExist(List<MedicamentDTO> medicamentDtos)
    {
        foreach (var medicamentDto in medicamentDtos)
        {
            if (!await _medicamentRepository.DoesMedicamentExist(medicamentDto.IdMedicament))
            {
                return false;
            }
        }
        return true;
    }
}