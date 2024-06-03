using WebApplication1.Entities;

namespace WebApplication1.DTO;

public record PrescriptionDTO(PatientDTO patient, int idDoctor, List<MedicamentDTO> medicaments, DateTime date, DateTime dueDate);