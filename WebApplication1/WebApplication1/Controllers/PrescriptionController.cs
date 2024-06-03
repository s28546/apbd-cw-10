using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;
using WebApplication1.Repositories;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrescriptionController : ControllerBase
{
    private readonly IPrescriptionService _prescriptionService;
    private readonly IMedicamentService _medicamentService;

    public PrescriptionController(IPrescriptionService prescriptionService, IMedicamentService medicamentService)
    {
        _prescriptionService = prescriptionService;
        _medicamentService = medicamentService;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreatePrescription(PrescriptionDTO prescription)
    {
        if (prescription.medicaments.Count > 10)
            return BadRequest("Prescription can have max. of 10 medicamements");

        if (prescription.dueDate < prescription.date)
            return BadRequest("Prescription DueDate < Date");

        if (!await _medicamentService.DoAllMedsExist(prescription.medicaments))
            return BadRequest("Some of the medicaments on the prescription does not exist.");
        
        await _prescriptionService.CreatePrescription(prescription);

        return Created();
    }
}