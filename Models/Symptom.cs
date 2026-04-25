namespace ExpertSystemWinForms.Models;

public class Symptom
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = "Khác"; // Danh mục triệu chứng
    
    public string DisplayText => $"{Name} - {Description}";
}

