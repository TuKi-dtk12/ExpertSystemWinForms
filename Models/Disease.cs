namespace ExpertSystemWinForms.Models;

public class Disease
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<string> Symptoms { get; set; } = new();
    public Dictionary<string, double> SymptomsCF { get; set; } = new(); // Certainty Factor cho mỗi triệu chứng (0-1)
    public string Severity { get; set; } = "medium"; // "low", "medium", "high"
    public string Treatment { get; set; } = string.Empty;
    
    public string DisplayText => $"{Name} - {Description}";
}

