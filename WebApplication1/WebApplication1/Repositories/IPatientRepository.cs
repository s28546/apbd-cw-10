using WebApplication1.DTO;
using WebApplication1.Entities;

namespace WebApplication1.Repositories;

public interface IPatientRepository
{
    public Task<bool> DoesPatientExist(Patient patient);

    public void AddPatient(PatientDTO patient);
}