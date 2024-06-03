﻿namespace WebApplication1.Entities;

public class Prescription
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public int IdPatient { get; set; }
    public int IdDoctor { get; set; }

    public virtual ICollection<PrescriptionMedicament> Medicaments { get; set; } = new List<PrescriptionMedicament>();
    
    public virtual Doctor Doctor { get; set; }
    public virtual Patient Patient { get; set; }
}