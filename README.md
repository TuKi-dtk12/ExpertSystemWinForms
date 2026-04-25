# Expert System for Disease Diagnosis - WinForms

An intelligent disease diagnosis application based on symptoms, converted from React to WinForms C#.

## Features

1. **Disease Diagnosis**
   - Symptom Selection (Forward Chaining)
   - Certainty Factor (CF) Calculation
   - Backward Chaining for improved accuracy
   - Display results with confidence scores

2. **Knowledge Base Management**
   - Add, edit, and delete symptoms
   - Add, edit, and delete diseases
   - Assign Certainty Factor for each symptom

3. **Diagnosis History**
   - Review previous diagnoses
   - View detailed results
   - Delete history records

## Technology

- .NET 8.0
- Windows Forms
- Newtonsoft.Json (data storage)

## System Requirements

- Windows 10 or higher
- .NET 8.0 Runtime

## Installation and Usage

1. Open the project in Visual Studio or JetBrains Rider
2. Build the project: `dotnet build`
3. Run the application: `dotnet run` or F5 in Visual Studio

## Project Structure

```
ExpertSystemWinForms/
├── Models/              # Data models
│   ├── Symptom.cs
│   ├── Disease.cs
│   ├── DiagnosisRecord.cs
│   └── DiagnosisResult.cs
├── Forms/               # UI Forms
│   ├── DiagnosisForm.cs
│   ├── BackwardChainingForm.cs
│   ├── KnowledgeBaseForm.cs
│   ├── DiagnosisHistoryForm.cs
│   ├── SymptomEditForm.cs
│   └── DiseaseEditForm.cs
├── Services/            # Services
│   └── DataService.cs   # Data storage management
├── Utils/               # Utilities
│   └── CertaintyFactor.cs
├── MainForm.cs          # Main form
└── Program.cs           # Entry point
```

## Data

Data is stored in the user's AppData folder:
- `%AppData%\ExpertSystemWinForms\symptoms.json`
- `%AppData%\ExpertSystemWinForms\diseases.json`
- `%AppData%\ExpertSystemWinForms\history.json`

## Notes

- Diagnosis results are for reference purposes only
- Please visit a medical facility for accurate diagnosis by a doctor

