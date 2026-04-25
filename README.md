# Hệ Chuyên Gia Chẩn Đoán Bệnh - WinForms

Ứng dụng chẩn đoán bệnh thông minh dựa trên triệu chứng, được chuyển đổi từ React sang WinForms C#.

## Tính năng

1. **Chẩn Đoán Bệnh**
   - Chọn triệu chứng (Forward Chaining)
   - Tính toán Certainty Factor (CF)
   - Suy diễn lùi (Backward Chaining) để tăng độ chính xác
   - Hiển thị kết quả với độ tin cậy

2. **Quản Lý Cơ Sở Tri Thức**
   - Thêm, sửa, xóa triệu chứng
   - Thêm, sửa, xóa bệnh
   - Gán Certainty Factor cho từng triệu chứng

3. **Lịch Sử Chẩn Đoán**
   - Xem lại các lần chẩn đoán trước
   - Xem chi tiết kết quả
   - Xóa lịch sử

## Công nghệ

- .NET 8.0
- Windows Forms
- Newtonsoft.Json (lưu trữ dữ liệu)

## Yêu cầu hệ thống

- Windows 10 trở lên
- .NET 8.0 Runtime

## Cài đặt và chạy

1. Mở project trong Visual Studio hoặc JetBrains Rider
2. Build project: `dotnet build`
3. Chạy ứng dụng: `dotnet run` hoặc F5 trong Visual Studio

## Cấu trúc dự án

```
ExpertSystemWinForms/
├── Models/              # Các model dữ liệu
│   ├── Symptom.cs
│   ├── Disease.cs
│   ├── DiagnosisRecord.cs
│   └── DiagnosisResult.cs
├── Forms/               # Các form
│   ├── DiagnosisForm.cs
│   ├── BackwardChainingForm.cs
│   ├── KnowledgeBaseForm.cs
│   ├── DiagnosisHistoryForm.cs
│   ├── SymptomEditForm.cs
│   └── DiseaseEditForm.cs
├── Services/            # Services
│   └── DataService.cs   # Quản lý lưu trữ dữ liệu
├── Utils/               # Utilities
│   └── CertaintyFactor.cs
├── MainForm.cs          # Form chính
└── Program.cs           # Entry point
```

## Dữ liệu

Dữ liệu được lưu trong thư mục AppData của người dùng:
- `%AppData%\ExpertSystemWinForms\symptoms.json`
- `%AppData%\ExpertSystemWinForms\diseases.json`
- `%AppData%\ExpertSystemWinForms\history.json`

## Lưu ý

- Kết quả chẩn đoán chỉ mang tính chất tham khảo
- Cần đến cơ sở y tế để được bác sĩ thăm khám chính xác

