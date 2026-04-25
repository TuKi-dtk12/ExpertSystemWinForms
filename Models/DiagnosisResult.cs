using ExpertSystemWinForms.Models;

namespace ExpertSystemWinForms.Models;

public class DiagnosisResult
{
    public Disease Disease { get; set; } = new();
    public double MatchPercentage { get; set; }
    public double CertaintyFactor { get; set; } // CF tổng hợp
    public string Confidence { get; set; } = "low"; // "low", "medium", "high"
}

