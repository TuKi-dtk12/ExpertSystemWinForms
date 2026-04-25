namespace ExpertSystemWinForms.Models;

public class DiagnosisRecord
{
    public string Id { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public List<string> SelectedSymptoms { get; set; } = new();
    public Dictionary<string, string> SymptomResponses { get; set; } = new(); // "yes", "no", "unknown"
    public List<DiagnosisResult> Results { get; set; } = new();
    
    public string DisplayText => $"{Date:dd/MM/yyyy HH:mm} - {SelectedSymptoms.Count} triệu chứng";
}

