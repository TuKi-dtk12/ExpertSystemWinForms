using ExpertSystemWinForms.Models;
using Newtonsoft.Json;

namespace ExpertSystemWinForms.Services;

public class DataService
{
    private static readonly string DataFolder = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "ExpertSystemWinForms");

    private static readonly string SymptomsFile = Path.Combine(DataFolder, "symptoms.json");
    private static readonly string DiseasesFile = Path.Combine(DataFolder, "diseases.json");
    private static readonly string HistoryFile = Path.Combine(DataFolder, "history.json");

    static DataService()
    {
        if (!Directory.Exists(DataFolder))
        {
            Directory.CreateDirectory(DataFolder);
        }
    }

    public static List<Symptom> LoadSymptoms()
    {
        if (File.Exists(SymptomsFile))
        {
            var json = File.ReadAllText(SymptomsFile);
            return JsonConvert.DeserializeObject<List<Symptom>>(json) ?? GetDefaultSymptoms();
        }
        return GetDefaultSymptoms();
    }

    public static void SaveSymptoms(List<Symptom> symptoms)
    {
        var json = JsonConvert.SerializeObject(symptoms, Formatting.Indented);
        File.WriteAllText(SymptomsFile, json);
    }

    public static List<Disease> LoadDiseases()
    {
        if (File.Exists(DiseasesFile))
        {
            var json = File.ReadAllText(DiseasesFile);
            return JsonConvert.DeserializeObject<List<Disease>>(json) ?? GetDefaultDiseases();
        }
        return GetDefaultDiseases();
    }

    public static void SaveDiseases(List<Disease> diseases)
    {
        var json = JsonConvert.SerializeObject(diseases, Formatting.Indented);
        File.WriteAllText(DiseasesFile, json);
    }

    public static List<DiagnosisRecord> LoadHistory()
    {
        if (File.Exists(HistoryFile))
        {
            var json = File.ReadAllText(HistoryFile);
            return JsonConvert.DeserializeObject<List<DiagnosisRecord>>(json) ?? new List<DiagnosisRecord>();
        }
        return new List<DiagnosisRecord>();
    }

    public static void SaveHistory(List<DiagnosisRecord> history)
    {
        var json = JsonConvert.SerializeObject(history, Formatting.Indented);
        File.WriteAllText(HistoryFile, json);
    }

    private static List<Symptom> GetDefaultSymptoms()
    {
        return new List<Symptom>
        {
            new() { Id = "s1", Name = "Sốt cao", Description = "Nhiệt độ cơ thể trên 38°C", Category = "Toàn thân" },
            new() { Id = "s2", Name = "Ho", Description = "Ho khan hoặc có đờm", Category = "Hô hấp" },
            new() { Id = "s3", Name = "Đau đầu", Description = "Đau đầu dai dẳng", Category = "Thần kinh" },
            new() { Id = "s4", Name = "Đau họng", Description = "Đau rát họng khi nuốt", Category = "Hô hấp" },
            new() { Id = "s5", Name = "Sổ mũi", Description = "Chảy nước mũi, nghẹt mũi", Category = "Hô hấp" },
            new() { Id = "s6", Name = "Đau cơ", Description = "Đau nhức cơ bắp toàn thân", Category = "Cơ xương khớp" },
            new() { Id = "s7", Name = "Mệt mỏi", Description = "Cảm giác mệt mỏi, uể oải", Category = "Toàn thân" },
            new() { Id = "s8", Name = "Buồn nôn", Description = "Cảm giác buồn nôn", Category = "Tiêu hóa" },
            new() { Id = "s9", Name = "Tiêu chảy", Description = "Đi ngoài phân lỏng nhiều lần", Category = "Tiêu hóa" },
            new() { Id = "s10", Name = "Đau bụng", Description = "Đau vùng bụng", Category = "Tiêu hóa" },
            new() { Id = "s11", Name = "Khó thở", Description = "Thở gấp, khó thở", Category = "Hô hấp" },
            new() { Id = "s12", Name = "Đau ngực", Description = "Đau vùng ngực", Category = "Tim mạch" },
            new() { Id = "s13", Name = "Nôn mửa", Description = "Nôn nhiều lần", Category = "Tiêu hóa" },
            new() { Id = "s14", Name = "Chóng mặt", Description = "Cảm giác mất thăng bằng", Category = "Thần kinh" },
            new() { Id = "s15", Name = "Phát ban", Description = "Nổi mẩn đỏ trên da", Category = "Da liễu" },
            new() { Id = "s16", Name = "Ngứa", Description = "Ngứa ngáy khắp cơ thể", Category = "Da liễu" },
            new() { Id = "s17", Name = "Đau khớp", Description = "Đau các khớp xương", Category = "Cơ xương khớp" },
            new() { Id = "s18", Name = "Sưng khớp", Description = "Khớp sưng phồng", Category = "Cơ xương khớp" },
            new() { Id = "s19", Name = "Rối loạn tiêu hóa", Description = "Khó tiêu, đầy hơi", Category = "Tiêu hóa" },
            new() { Id = "s20", Name = "Mất ngủ", Description = "Khó ngủ hoặc ngủ không sâu giấc", Category = "Thần kinh" },
            new() { Id = "s21", Name = "Lo âu", Description = "Cảm giác lo lắng, căng thẳng", Category = "Thần kinh" },
            new() { Id = "s22", Name = "Tim đập nhanh", Description = "Nhịp tim tăng cao bất thường", Category = "Tim mạch" },
            new() { Id = "s23", Name = "Đổ mồ hôi nhiều", Description = "Ra mồ hôi nhiều bất thường", Category = "Toàn thân" },
            new() { Id = "s24", Name = "Táo bón", Description = "Khó đi ngoài", Category = "Tiêu hóa" },
            new() { Id = "s25", Name = "Đau lưng", Description = "Đau vùng lưng", Category = "Cơ xương khớp" },
            new() { Id = "s26", Name = "Ho có máu", Description = "Ho ra máu", Category = "Hô hấp" },
            new() { Id = "s27", Name = "Sụt cân", Description = "Giảm cân không rõ nguyên nhân", Category = "Toàn thân" },
            new() { Id = "s28", Name = "Khàn giọng", Description = "Giọng nói khàn đục", Category = "Hô hấp" },
            new() { Id = "s29", Name = "Khó nuốt", Description = "Khó khăn khi nuốt thức ăn", Category = "Hô hấp" },
            new() { Id = "s30", Name = "Sốt nhẹ kéo dài", Description = "Sốt nhẹ kéo dài nhiều ngày", Category = "Toàn thân" },
            new() { Id = "s31", Name = "Ho khan", Description = "Ho không có đờm", Category = "Hô hấp" },
            new() { Id = "s32", Name = "Ho có đờm", Description = "Ho kèm đờm vàng/xanh", Category = "Hô hấp" },
            new() { Id = "s33", Name = "Mất mùi/vị", Description = "Mất khứu giác hoặc vị giác", Category = "Hô hấp" },
            new() { Id = "s34", Name = "Khó thở nghiêm trọng", Description = "Khó thở nặng, nguy hiểm", Category = "Hô hấp" },
            new() { Id = "s35", Name = "Môi tím tái", Description = "Môi chuyển màu tím, thiếu oxy", Category = "Hô hấp" },
            new() { Id = "s36", Name = "Sốt nhẹ", Description = "Nhiệt độ cơ thể 37.5-38°C", Category = "Toàn thân" },
            new() { Id = "s37", Name = "Đau cơ nhiều", Description = "Đau nhức cơ bắp nghiêm trọng", Category = "Cơ xương khớp" },
            new() { Id = "s38", Name = "Rét run", Description = "Cảm giác lạnh run người", Category = "Toàn thân" },
            new() { Id = "s39", Name = "Đau ngực khi ho", Description = "Đau ngực khi ho hoặc thở sâu", Category = "Hô hấp" },
            new() { Id = "s40", Name = "Hắt hơi", Description = "Hắt hơi liên tục", Category = "Hô hấp" },
            new() { Id = "s41", Name = "Đau tim", Description = "Đau thắt ngực, đau vùng tim", Category = "Tim mạch" },
            new() { Id = "s42", Name = "Huyết áp cao", Description = "Huyết áp tăng cao", Category = "Tim mạch" },
            new() { Id = "s43", Name = "Huyết áp thấp", Description = "Huyết áp giảm thấp", Category = "Tim mạch" },
            new() { Id = "s44", Name = "Ngất xỉu", Description = "Bất tỉnh, mất ý thức", Category = "Thần kinh" },
            new() { Id = "s45", Name = "Đau nửa đầu", Description = "Đau đầu một bên, dữ dội", Category = "Thần kinh" },
            new() { Id = "s46", Name = "Co giật", Description = "Co giật cơ thể, động kinh", Category = "Thần kinh" },
            new() { Id = "s47", Name = "Tê bì chân tay", Description = "Tê, mất cảm giác tay chân", Category = "Thần kinh" },
            new() { Id = "s48", Name = "Yếu cơ", Description = "Cơ bắp yếu, khó vận động", Category = "Cơ xương khớp" },
            new() { Id = "s49", Name = "Mất trí nhớ", Description = "Quên, mất trí nhớ tạm thời", Category = "Thần kinh" },
            new() { Id = "s50", Name = "Mờ mắt", Description = "Nhìn mờ, giảm thị lực", Category = "Mắt" },
            new() { Id = "s51", Name = "Đau mắt", Description = "Đau nhức mắt", Category = "Mắt" },
            new() { Id = "s52", Name = "Đỏ mắt", Description = "Mắt đỏ, viêm kết mạc", Category = "Mắt" },
            new() { Id = "s53", Name = "Chảy nước mắt", Description = "Nước mắt chảy nhiều", Category = "Mắt" },
            new() { Id = "s54", Name = "Ù tai", Description = "Nghe tiếng ù trong tai", Category = "Tai" },
            new() { Id = "s55", Name = "Đau tai", Description = "Đau nhức trong tai", Category = "Tai" },
            new() { Id = "s56", Name = "Chảy mủ tai", Description = "Tai chảy dịch mủ", Category = "Tai" },
            new() { Id = "s57", Name = "Đi tiểu nhiều", Description = "Tiểu tiện nhiều lần", Category = "Tiết niệu" },
            new() { Id = "s58", Name = "Đi tiểu buốt", Description = "Đau buốt khi tiểu", Category = "Tiết niệu" },
            new() { Id = "s59", Name = "Tiểu ra máu", Description = "Nước tiểu có máu", Category = "Tiết niệu" },
            new() { Id = "s60", Name = "Tiểu không tự chủ", Description = "Không kiểm soát được tiểu tiện", Category = "Tiết niệu" },
            new() { Id = "s61", Name = "Đau khi quan hệ", Description = "Đau khi quan hệ tình dục", Category = "Khác" },
            new() { Id = "s62", Name = "Khí hư bất thường", Description = "Dịch âm đạo bất thường", Category = "Khác" },
            new() { Id = "s63", Name = "Kinh nguyệt không đều", Description = "Chu kỳ kinh nguyệt rối loạn", Category = "Khác" },
            new() { Id = "s64", Name = "Đau bụng kinh", Description = "Đau bụng khi hành kinh", Category = "Tiêu hóa" },
            new() { Id = "s65", Name = "Sưng hạch", Description = "Hạch bạch huyết sưng to", Category = "Toàn thân" },
            new() { Id = "s66", Name = "Vàng da", Description = "Da và mắt chuyển màu vàng", Category = "Gan mật" },
            new() { Id = "s67", Name = "Nước tiểu sẫm màu", Description = "Nước tiểu màu vàng đậm", Category = "Gan mật" },
            new() { Id = "s68", Name = "Phân nhạt màu", Description = "Phân màu trắng, nhạt", Category = "Gan mật" },
            new() { Id = "s69", Name = "Nổi mụn nước", Description = "Mụn nước trên da", Category = "Da liễu" },
            new() { Id = "s70", Name = "Bong da", Description = "Da bong tróc, khô", Category = "Da liễu" },
            new() { Id = "s71", Name = "Rụng tóc", Description = "Tóc rụng nhiều bất thường", Category = "Da liễu" },
            new() { Id = "s72", Name = "Móng tay giòn", Description = "Móng tay dễ gãy, yếu", Category = "Da liễu" },
            new() { Id = "s73", Name = "Khát nước nhiều", Description = "Luôn cảm thấy khát", Category = "Nội tiết" },
            new() { Id = "s74", Name = "Đói nhiều", Description = "Luôn cảm thấy đói", Category = "Nội tiết" },
            new() { Id = "s75", Name = "Tăng cân", Description = "Tăng cân không rõ nguyên nhân", Category = "Nội tiết" },
            new() { Id = "s76", Name = "Sưng mặt", Description = "Mặt sưng phù", Category = "Nội tiết" },
            new() { Id = "s77", Name = "Bướu cổ", Description = "Cổ sưng to, bướu cổ", Category = "Nội tiết" },
            new() { Id = "s78", Name = "Run tay", Description = "Tay run không kiểm soát", Category = "Nội tiết" },
            new() { Id = "s79", Name = "Mất cảm giác ngon miệng", Description = "Không muốn ăn, chán ăn", Category = "Tiêu hóa" },
            new() { Id = "s80", Name = "Ợ nóng", Description = "Cảm giác nóng rát vùng ngực", Category = "Tiêu hóa" },
            new() { Id = "s81", Name = "Ợ hơi", Description = "Ợ hơi nhiều, đầy hơi", Category = "Tiêu hóa" },
            new() { Id = "s82", Name = "Đầy bụng", Description = "Cảm giác đầy bụng, khó tiêu", Category = "Tiêu hóa" },
            new() { Id = "s83", Name = "Chán ăn", Description = "Không muốn ăn, mất cảm giác ngon miệng", Category = "Tiêu hóa" },
            new() { Id = "s84", Name = "Đau răng", Description = "Đau nhức răng", Category = "Khác" },
            new() { Id = "s85", Name = "Chảy máu chân răng", Description = "Chảy máu khi đánh răng", Category = "Khác" },
            new() { Id = "s86", Name = "Hôi miệng", Description = "Hơi thở có mùi hôi", Category = "Khác" },
            new() { Id = "s87", Name = "Nấc cụt", Description = "Nấc cụt liên tục", Category = "Tiêu hóa" },
            new() { Id = "s88", Name = "Đau vai", Description = "Đau vùng vai", Category = "Cơ xương khớp" },
            new() { Id = "s89", Name = "Đau cổ", Description = "Đau vùng cổ, cứng cổ", Category = "Cơ xương khớp" },
            new() { Id = "s90", Name = "Đau gót chân", Description = "Đau vùng gót chân", Category = "Cơ xương khớp" },
            new() { Id = "s91", Name = "Chuột rút", Description = "Co thắt cơ đột ngột", Category = "Cơ xương khớp" },
            new() { Id = "s92", Name = "Cứng khớp", Description = "Khớp cứng, khó cử động", Category = "Cơ xương khớp" },
            new() { Id = "s93", Name = "Đau nhức xương", Description = "Đau trong xương", Category = "Cơ xương khớp" },
            new() { Id = "s94", Name = "Mất ngủ kéo dài", Description = "Mất ngủ kéo dài nhiều ngày", Category = "Thần kinh" },
            new() { Id = "s95", Name = "Ngủ nhiều", Description = "Ngủ quá nhiều, buồn ngủ", Category = "Thần kinh" },
            new() { Id = "s96", Name = "Hay quên", Description = "Trí nhớ kém, hay quên", Category = "Thần kinh" },
            new() { Id = "s97", Name = "Khó tập trung", Description = "Khó tập trung, mất tập trung", Category = "Thần kinh" },
            new() { Id = "s98", Name = "Cáu gắt", Description = "Dễ cáu gắt, nóng tính", Category = "Thần kinh" },
            new() { Id = "s99", Name = "Trầm cảm", Description = "Tâm trạng buồn, chán nản", Category = "Thần kinh" },
            new() { Id = "s100", Name = "Đau ngực trái", Description = "Đau vùng ngực bên trái", Category = "Tim mạch" },
            new() { Id = "s101", Name = "Đau ngực phải", Description = "Đau vùng ngực bên phải", Category = "Tim mạch" },
            new() { Id = "s102", Name = "Hồi hộp", Description = "Cảm giác hồi hộp, lo lắng", Category = "Tim mạch" },
            new() { Id = "s103", Name = "Choáng váng", Description = "Cảm giác choáng váng, sắp ngất", Category = "Thần kinh" },
            new() { Id = "s104", Name = "Đau bụng trên", Description = "Đau vùng bụng trên", Category = "Tiêu hóa" },
            new() { Id = "s105", Name = "Đau bụng dưới", Description = "Đau vùng bụng dưới", Category = "Tiêu hóa" },
            new() { Id = "s106", Name = "Đau bụng bên trái", Description = "Đau bụng bên trái", Category = "Tiêu hóa" },
            new() { Id = "s107", Name = "Đau bụng bên phải", Description = "Đau bụng bên phải", Category = "Tiêu hóa" },
            new() { Id = "s108", Name = "Đau bụng quanh rốn", Description = "Đau bụng vùng quanh rốn", Category = "Tiêu hóa" },
            new() { Id = "s109", Name = "Đau họng khi nuốt", Description = "Đau họng khi nuốt thức ăn", Category = "Hô hấp" },
            new() { Id = "s110", Name = "Nghẹt mũi", Description = "Mũi bị nghẹt, khó thở bằng mũi", Category = "Hô hấp" },
            new() { Id = "s111", Name = "Chảy nước mũi", Description = "Nước mũi chảy nhiều", Category = "Hô hấp" },
            new() { Id = "s112", Name = "Ho về đêm", Description = "Ho nhiều về ban đêm", Category = "Hô hấp" },
            new() { Id = "s113", Name = "Thở khò khè", Description = "Thở có tiếng khò khè", Category = "Hô hấp" },
            new() { Id = "s114", Name = "Đau khi thở", Description = "Đau khi hít thở sâu", Category = "Hô hấp" },
            new() { Id = "s115", Name = "Khó thở khi nằm", Description = "Khó thở khi nằm xuống", Category = "Hô hấp" },
            new() { Id = "s116", Name = "Đau đầu buổi sáng", Description = "Đau đầu khi thức dậy", Category = "Thần kinh" },
            new() { Id = "s117", Name = "Đau đầu sau gáy", Description = "Đau đầu vùng sau gáy", Category = "Thần kinh" },
            new() { Id = "s118", Name = "Đau đầu hai bên thái dương", Description = "Đau đầu hai bên", Category = "Thần kinh" },
            new() { Id = "s119", Name = "Nhức mắt", Description = "Nhức mắt, mỏi mắt", Category = "Mắt" },
            new() { Id = "s120", Name = "Mắt khô", Description = "Cảm giác khô mắt", Category = "Mắt" },
        };
    }

    private static List<Disease> GetDefaultDiseases()
    {
        return new List<Disease>
        {
            new()
            {
                Id = "d1",
                Name = "Cảm cúm",
                Description = "Bệnh nhiễm virus cúm thường gặp",
                Symptoms = new List<string> { "s1", "s31", "s37", "s3", "s4", "s5", "s6", "s7", "s40" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s1", 0.78 },      // Sốt cao - rất quan trọng
                    { "s31", 0.70 },     // Ho khan - quan trọng
                    { "s37", 0.66 },     // Đau cơ nhiều - đặc trưng
                    { "s3", 0.60 },      // Đau đầu
                    { "s4", 0.50 },      // Đau họng
                    { "s5", 0.45 },      // Sổ mũi
                    { "s6", 0.40 },      // Đau cơ (nhẹ)
                    { "s7", 0.35 },      // Mệt mỏi
                    { "s40", 0.30 },     // Hắt hơi
                },
                Severity = "medium",
                Treatment = "Nghỉ ngơi, uống nhiều nước, dùng thuốc hạ sốt. Nếu triệu chứng nặng cần đến bác sĩ."
            },
            new()
            {
                Id = "d2",
                Name = "Cảm lạnh thông thường",
                Description = "Nhiễm virus đường hô hấp trên",
                Symptoms = new List<string> { "s2", "s4", "s5", "s7" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s2", 0.8 },
                    { "s4", 0.7 },
                    { "s5", 0.6 },
                    { "s7", 0.5 },
                },
                Severity = "low",
                Treatment = "Nghỉ ngơi, uống nhiều nước ấm, vitamin C. Thường tự khỏi sau 5-7 ngày."
            },
            new()
            {
                Id = "d3",
                Name = "Viêm phế quản",
                Description = "Viêm đường dẫn khí đến phổi",
                Symptoms = new List<string> { "s2", "s1", "s11", "s12", "s7" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s2", 0.8 },
                    { "s1", 0.7 },
                    { "s11", 0.6 },
                    { "s12", 0.5 },
                    { "s7", 0.4 },
                },
                Severity = "high",
                Treatment = "Cần khám bác sĩ để được kê đơn thuốc. Có thể cần dùng kháng sinh."
            },
            new()
            {
                Id = "d4",
                Name = "Ngộ độc thực phẩm",
                Description = "Do ăn thực phẩm bị nhiễm khuẩn",
                Symptoms = new List<string> { "s8", "s9", "s10", "s1", "s7", "s13" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s8", 0.8 },
                    { "s9", 0.7 },
                    { "s10", 0.6 },
                    { "s1", 0.5 },
                    { "s7", 0.4 },
                    { "s13", 0.3 },
                },
                Severity = "medium",
                Treatment = "Uống nhiều nước, oresol. Nếu nặng cần nhập viện truyền dịch."
            },
            new()
            {
                Id = "d5",
                Name = "Viêm họng",
                Description = "Viêm niêm mạc họng",
                Symptoms = new List<string> { "s4", "s1", "s3", "s7", "s28" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s4", 0.8 },
                    { "s1", 0.7 },
                    { "s3", 0.6 },
                    { "s7", 0.5 },
                    { "s28", 0.4 },
                },
                Severity = "low",
                Treatment = "Súc miệng nước muối ấm, uống nhiều nước, thuốc giảm đau. Nếu kéo dài cần khám bác sĩ."
            },
            new()
            {
                Id = "d6",
                Name = "Viêm dạ dày cấp",
                Description = "Viêm niêm mạc dạ dày",
                Symptoms = new List<string> { "s10", "s8", "s13", "s19", "s7" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s10", 0.8 },
                    { "s8", 0.7 },
                    { "s13", 0.6 },
                    { "s19", 0.5 },
                    { "s7", 0.4 },
                },
                Severity = "medium",
                Treatment = "Ăn nhạt, uống thuốc giảm acid dạ dày. Tránh thức ăn cay, dầu mỡ."
            },
            new()
            {
                Id = "d7",
                Name = "Sốt xuất huyết",
                Description = "Do virus Dengue qua muỗi truyền",
                Symptoms = new List<string> { "s1", "s3", "s6", "s7", "s15", "s8", "s17" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s1", 0.8 },
                    { "s3", 0.7 },
                    { "s6", 0.6 },
                    { "s7", 0.5 },
                    { "s15", 0.4 },
                    { "s8", 0.3 },
                    { "s17", 0.2 },
                },
                Severity = "high",
                Treatment = "Cần nhập viện ngay lập tức. Theo dõi số lượng tiểu cầu, truyền dịch."
            },
            new()
            {
                Id = "d8",
                Name = "Viêm gan A",
                Description = "Viêm gan do virus Hepatitis A",
                Symptoms = new List<string> { "s1", "s7", "s8", "s10", "s19", "s27" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s1", 0.8 },
                    { "s7", 0.7 },
                    { "s8", 0.6 },
                    { "s10", 0.5 },
                    { "s19", 0.4 },
                    { "s27", 0.3 },
                },
                Severity = "high",
                Treatment = "Nghỉ ngơi tuyệt đối, ăn uống đủ dinh dưỡng. Cần theo dõi chức năng gan."
            },
            new()
            {
                Id = "d9",
                Name = "Viêm phổi",
                Description = "Nhiễm trùng phổi do vi khuẩn hoặc virus",
                Symptoms = new List<string> { "s32", "s1", "s11", "s39", "s38", "s7", "s23" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s32", 0.85 },     // Ho có đờm - rất đặc trưng
                    { "s1", 0.80 },      // Sốt cao - quan trọng
                    { "s11", 0.75 },     // Khó thở - đặc trưng
                    { "s39", 0.70 },     // Đau ngực khi ho - đặc trưng
                    { "s38", 0.65 },     // Rét run - gợi ý nhiễm trùng
                    { "s7", 0.50 },      // Mệt mỏi
                    { "s23", 0.40 },     // Đổ mồ hôi nhiều
                },
                Severity = "high",
                Treatment = "Cần khám bác sĩ ngay. Dùng kháng sinh theo chỉ định. Có thể cần nhập viện."
            },
            new()
            {
                Id = "d10",
                Name = "Viêm amidan",
                Description = "Viêm nhiễm amidan họng",
                Symptoms = new List<string> { "s4", "s1", "s3", "s7", "s29" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s4", 0.8 },
                    { "s1", 0.7 },
                    { "s3", 0.6 },
                    { "s7", 0.5 },
                    { "s29", 0.4 },
                },
                Severity = "medium",
                Treatment = "Uống thuốc kháng sinh theo đơn. Nghỉ ngơi, uống nhiều nước."
            },
            new()
            {
                Id = "d11",
                Name = "Dị ứng",
                Description = "Phản ứng dị ứng với chất lạ",
                Symptoms = new List<string> { "s15", "s16", "s5", "s11" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s15", 0.8 },
                    { "s16", 0.7 },
                    { "s5", 0.6 },
                    { "s11", 0.5 },
                },
                Severity = "medium",
                Treatment = "Dùng thuốc kháng histamin. Tránh xa tác nhân gây dị ứng. Nếu nặng cần cấp cứu."
            },
            new()
            {
                Id = "d12",
                Name = "Viêm khớp",
                Description = "Viêm các khớp xương",
                Symptoms = new List<string> { "s17", "s18", "s7", "s25" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s17", 0.8 },
                    { "s18", 0.7 },
                    { "s7", 0.6 },
                    { "s25", 0.5 },
                },
                Severity = "medium",
                Treatment = "Dùng thuốc giảm đau, chống viêm. Vật lý trị liệu. Tránh vận động mạnh."
            },
            new()
            {
                Id = "d13",
                Name = "Rối loạn lo âu",
                Description = "Rối loạn tâm lý lo âu",
                Symptoms = new List<string> { "s20", "s21", "s22", "s7", "s14", "s23" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s20", 0.8 },
                    { "s21", 0.7 },
                    { "s22", 0.6 },
                    { "s7", 0.5 },
                    { "s14", 0.4 },
                    { "s23", 0.3 },
                },
                Severity = "medium",
                Treatment = "Tư vấn tâm lý. Thư giãn, thiền định. Có thể cần thuốc theo đơn bác sĩ."
            },
            new()
            {
                Id = "d14",
                Name = "Hội chứng ruột kích thích",
                Description = "Rối loạn chức năng đường tiêu hóa",
                Symptoms = new List<string> { "s10", "s9", "s24", "s19", "s7" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s10", 0.8 },
                    { "s9", 0.7 },
                    { "s24", 0.6 },
                    { "s19", 0.5 },
                    { "s7", 0.4 },
                },
                Severity = "low",
                Treatment = "Ăn uống khoa học, tránh stress. Dùng thuốc điều hòa tiêu hóa."
            },
            new()
            {
                Id = "d15",
                Name = "Lao phổi",
                Description = "Do vi khuẩn lao Mycobacterium",
                Symptoms = new List<string> { "s2", "s26", "s1", "s27", "s7", "s30", "s23" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s2", 0.8 },
                    { "s26", 0.7 },
                    { "s1", 0.6 },
                    { "s27", 0.5 },
                    { "s7", 0.4 },
                    { "s30", 0.3 },
                    { "s23", 0.2 },
                },
                Severity = "high",
                Treatment = "Cần điều trị kháng lao dài hạn (6-9 tháng). Cách ly để tránh lây lan."
            },
            new()
            {
                Id = "d16",
                Name = "Viêm gan B",
                Description = "Viêm gan do virus Hepatitis B",
                Symptoms = new List<string> { "s7", "s8", "s10", "s19", "s27", "s30" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s7", 0.8 },
                    { "s8", 0.7 },
                    { "s10", 0.6 },
                    { "s19", 0.5 },
                    { "s27", 0.4 },
                    { "s30", 0.3 },
                },
                Severity = "high",
                Treatment = "Cần điều trị dài hạn với thuốc kháng virus. Theo dõi chức năng gan định kỳ."
            },
            new()
            {
                Id = "d17",
                Name = "Hen suyễn",
                Description = "Bệnh viêm mạn tính đường thở",
                Symptoms = new List<string> { "s11", "s2", "s12", "s7" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s11", 0.8 },
                    { "s2", 0.7 },
                    { "s12", 0.6 },
                    { "s7", 0.5 },
                },
                Severity = "high",
                Treatment = "Dùng thuốc xịt giãn phế quản. Tránh tác nhân kích thích. Có kế hoạch kiểm soát lâu dài."
            },
            new()
            {
                Id = "d18",
                Name = "Viêm xoang",
                Description = "Viêm các xoang mũi",
                Symptoms = new List<string> { "s3", "s5", "s4", "s7", "s14" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s3", 0.8 },
                    { "s5", 0.7 },
                    { "s4", 0.6 },
                    { "s7", 0.5 },
                    { "s14", 0.4 },
                },
                Severity = "low",
                Treatment = "Xông mũi, rửa mũi bằng nước muối. Dùng thuốc kháng sinh nếu cần."
            },
            new()
            {
                Id = "d19",
                Name = "Sốt vi rút",
                Description = "Nhiễm virus gây sốt thông thường",
                Symptoms = new List<string> { "s1", "s3", "s6", "s7" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s1", 0.8 },
                    { "s3", 0.7 },
                    { "s6", 0.6 },
                    { "s7", 0.5 },
                },
                Severity = "low",
                Treatment = "Nghỉ ngơi, uống nhiều nước, hạ sốt. Thường tự khỏi sau vài ngày."
            },
            new()
            {
                Id = "d20",
                Name = "Tiểu đường type 2",
                Description = "Rối loạn chuyển hóa đường huyết",
                Symptoms = new List<string> { "s7", "s27", "s14", "s19" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s7", 0.8 },
                    { "s27", 0.7 },
                    { "s14", 0.6 },
                    { "s19", 0.5 },
                },
                Severity = "high",
                Treatment = "Kiểm soát chế độ ăn, tập thể dục. Dùng thuốc hạ đường huyết. Theo dõi đường huyết thường xuyên."
            },
            new()
            {
                Id = "d21",
                Name = "COVID-19",
                Description = "Bệnh do virus SARS-CoV-2 gây ra",
                Symptoms = new List<string> { "s33", "s36", "s31", "s11", "s1", "s7", "s3", "s4" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s33", 0.95 },     // Mất mùi/vị - rất đặc hiệu, CF cao nhất
                    { "s36", 0.75 },     // Sốt nhẹ/vừa
                    { "s31", 0.70 },     // Ho khan
                    { "s11", 0.65 },     // Khó thở
                    { "s1", 0.60 },      // Sốt cao
                    { "s7", 0.55 },      // Mệt mỏi
                    { "s3", 0.50 },      // Đau đầu
                    { "s4", 0.45 },      // Đau họng
                },
                Severity = "high",
                Treatment = "Cách ly tại nhà, theo dõi triệu chứng. Nếu khó thở hoặc sốt cao kéo dài, cần đến cơ sở y tế ngay. Làm xét nghiệm COVID-19."
            },
            new()
            {
                Id = "d22",
                Name = "Cảnh báo khẩn cấp",
                Description = "Tình trạng nguy hiểm, cần cấp cứu ngay",
                Symptoms = new List<string> { "s34", "s35" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s34", 1.0 },      // Khó thở nghiêm trọng - CF tối đa
                    { "s35", 1.0 },      // Môi tím tái - CF tối đa
                },
                Severity = "high",
                Treatment = "ĐẾN BỆNH VIỆN NGAY LẬP TỨC! Gọi 115 hoặc đến phòng cấp cứu gần nhất. Đây là tình trạng nguy hiểm đến tính mạng."
            },
            new()
            {
                Id = "d23",
                Name = "Viêm mũi dị ứng",
                Description = "Viêm mũi do dị ứng",
                Symptoms = new List<string> { "s5", "s40", "s16", "s15", "s11" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s5", 0.80 },
                    { "s40", 0.75 },
                    { "s16", 0.70 },
                    { "s15", 0.65 },
                    { "s11", 0.50 },
                },
                Severity = "low",
                Treatment = "Tránh tác nhân gây dị ứng. Dùng thuốc kháng histamin. Rửa mũi bằng nước muối."
            },
            new()
            {
                Id = "d24",
                Name = "Viêm thanh quản",
                Description = "Viêm dây thanh âm",
                Symptoms = new List<string> { "s28", "s31", "s4", "s29", "s7" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s28", 0.85 },
                    { "s31", 0.75 },
                    { "s4", 0.70 },
                    { "s29", 0.65 },
                    { "s7", 0.50 },
                },
                Severity = "low",
                Treatment = "Nghỉ giọng, uống nhiều nước ấm. Tránh nói to. Có thể dùng thuốc giảm đau."
            },
            new()
            {
                Id = "d25",
                Name = "Viêm tai giữa",
                Description = "Nhiễm trùng tai giữa",
                Symptoms = new List<string> { "s3", "s1", "s14", "s7", "s28" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s3", 0.80 },
                    { "s1", 0.75 },
                    { "s14", 0.70 },
                    { "s7", 0.60 },
                    { "s28", 0.50 },
                },
                Severity = "medium",
                Treatment = "Cần khám bác sĩ. Dùng kháng sinh theo chỉ định. Có thể cần thuốc giảm đau."
            },
            new()
            {
                Id = "d26",
                Name = "Viêm ruột thừa",
                Description = "Viêm ruột thừa cấp tính",
                Symptoms = new List<string> { "s10", "s1", "s8", "s13", "s7" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s10", 0.90 },
                    { "s1", 0.80 },
                    { "s8", 0.75 },
                    { "s13", 0.70 },
                    { "s7", 0.60 },
                },
                Severity = "high",
                Treatment = "CẦN PHẪU THUẬT NGAY! Đến bệnh viện cấp cứu ngay lập tức. Không được trì hoãn."
            },
            new()
            {
                Id = "d27",
                Name = "Viêm túi mật",
                Description = "Viêm túi mật do sỏi hoặc nhiễm trùng",
                Symptoms = new List<string> { "s10", "s1", "s8", "s13", "s7" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s10", 0.85 },
                    { "s1", 0.75 },
                    { "s8", 0.70 },
                    { "s13", 0.65 },
                    { "s7", 0.55 },
                },
                Severity = "high",
                Treatment = "Cần khám bác sĩ ngay. Có thể cần phẫu thuật. Tránh ăn thức ăn nhiều dầu mỡ."
            },
            new()
            {
                Id = "d28",
                Name = "Viêm thận",
                Description = "Nhiễm trùng thận",
                Symptoms = new List<string> { "s1", "s10", "s7", "s25", "s23" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s1", 0.80 },
                    { "s10", 0.75 },
                    { "s7", 0.70 },
                    { "s25", 0.65 },
                    { "s23", 0.60 },
                },
                Severity = "high",
                Treatment = "Cần khám bác sĩ ngay. Dùng kháng sinh theo chỉ định. Uống nhiều nước."
            },
            new()
            {
                Id = "d29",
                Name = "Nhồi máu cơ tim",
                Description = "Tắc nghẽn động mạch vành tim",
                Symptoms = new List<string> { "s41", "s12", "s11", "s22", "s23", "s14", "s44" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s41", 0.95 },     // Đau tim - rất đặc hiệu
                    { "s12", 0.85 },     // Đau ngực
                    { "s11", 0.80 },     // Khó thở
                    { "s22", 0.75 },     // Tim đập nhanh
                    { "s23", 0.70 },     // Đổ mồ hôi nhiều
                    { "s14", 0.65 },     // Chóng mặt
                    { "s44", 0.60 },     // Ngất xỉu
                },
                Severity = "high",
                Treatment = "GỌI CẤP CỨU 115 NGAY LẬP TỨC! Đây là cấp cứu tim mạch. Không được trì hoãn."
            },
            new()
            {
                Id = "d30",
                Name = "Cao huyết áp",
                Description = "Huyết áp tăng cao mạn tính",
                Symptoms = new List<string> { "s42", "s3", "s22", "s14", "s11", "s7" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s42", 0.90 },     // Huyết áp cao - đặc hiệu
                    { "s3", 0.70 },      // Đau đầu
                    { "s22", 0.65 },     // Tim đập nhanh
                    { "s14", 0.60 },     // Chóng mặt
                    { "s11", 0.55 },     // Khó thở
                    { "s7", 0.50 },      // Mệt mỏi
                },
                Severity = "high",
                Treatment = "Theo dõi huyết áp thường xuyên. Dùng thuốc hạ huyết áp theo chỉ định. Giảm muối, tập thể dục."
            },
            new()
            {
                Id = "d31",
                Name = "Huyết áp thấp",
                Description = "Huyết áp giảm thấp",
                Symptoms = new List<string> { "s43", "s14", "s44", "s7", "s22" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s43", 0.85 },     // Huyết áp thấp - đặc hiệu
                    { "s14", 0.80 },     // Chóng mặt
                    { "s44", 0.75 },     // Ngất xỉu
                    { "s7", 0.70 },      // Mệt mỏi
                    { "s22", 0.65 },     // Tim đập nhanh
                },
                Severity = "medium",
                Treatment = "Uống nhiều nước, tăng lượng muối trong chế độ ăn. Tránh đứng lâu. Có thể cần thuốc."
            },
            new()
            {
                Id = "d32",
                Name = "Đau nửa đầu",
                Description = "Migraine, đau đầu một bên",
                Symptoms = new List<string> { "s45", "s8", "s14", "s50", "s7" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s45", 0.90 },     // Đau nửa đầu - rất đặc hiệu
                    { "s8", 0.75 },      // Buồn nôn
                    { "s14", 0.70 },     // Chóng mặt
                    { "s50", 0.65 },     // Mờ mắt
                    { "s7", 0.60 },      // Mệt mỏi
                },
                Severity = "medium",
                Treatment = "Nghỉ ngơi trong phòng tối, yên tĩnh. Dùng thuốc giảm đau. Tránh ánh sáng mạnh, tiếng ồn."
            },
            new()
            {
                Id = "d33",
                Name = "Động kinh",
                Description = "Rối loạn co giật",
                Symptoms = new List<string> { "s46", "s44", "s49", "s47", "s48" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s46", 0.95 },     // Co giật - rất đặc hiệu
                    { "s44", 0.80 },     // Ngất xỉu
                    { "s49", 0.75 },     // Mất trí nhớ
                    { "s47", 0.70 },     // Tê bì chân tay
                    { "s48", 0.65 },     // Yếu cơ
                },
                Severity = "high",
                Treatment = "Cần khám bác sĩ chuyên khoa thần kinh. Dùng thuốc chống động kinh. Tránh các yếu tố kích thích."
            },
            new()
            {
                Id = "d34",
                Name = "Viêm kết mạc",
                Description = "Đau mắt đỏ, viêm màng kết mạc",
                Symptoms = new List<string> { "s52", "s51", "s53", "s5", "s16" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s52", 0.90 },     // Đỏ mắt - rất đặc hiệu
                    { "s51", 0.85 },     // Đau mắt
                    { "s53", 0.80 },     // Chảy nước mắt
                    { "s5", 0.70 },      // Sổ mũi
                    { "s16", 0.65 },     // Ngứa
                },
                Severity = "low",
                Treatment = "Rửa mắt bằng nước muối sinh lý. Dùng thuốc nhỏ mắt kháng sinh. Tránh dụi mắt."
            },
            new()
            {
                Id = "d35",
                Name = "Viêm bàng quang",
                Description = "Nhiễm trùng bàng quang",
                Symptoms = new List<string> { "s58", "s57", "s59", "s10", "s1" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s58", 0.90 },     // Đi tiểu buốt - rất đặc hiệu
                    { "s57", 0.85 },     // Đi tiểu nhiều
                    { "s59", 0.80 },     // Tiểu ra máu
                    { "s10", 0.70 },     // Đau bụng
                    { "s1", 0.65 },      // Sốt cao
                },
                Severity = "medium",
                Treatment = "Uống nhiều nước. Dùng kháng sinh theo chỉ định. Tránh nhịn tiểu."
            },
            new()
            {
                Id = "d36",
                Name = "Sỏi thận",
                Description = "Sỏi trong thận hoặc đường tiết niệu",
                Symptoms = new List<string> { "s10", "s59", "s57", "s25", "s8", "s13" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s10", 0.90 },     // Đau bụng dữ dội - đặc hiệu
                    { "s59", 0.85 },     // Tiểu ra máu
                    { "s57", 0.80 },     // Đi tiểu nhiều
                    { "s25", 0.75 },     // Đau lưng
                    { "s8", 0.70 },      // Buồn nôn
                    { "s13", 0.65 },     // Nôn mửa
                },
                Severity = "high",
                Treatment = "Uống nhiều nước (2-3 lít/ngày). Dùng thuốc giảm đau. Có thể cần tán sỏi hoặc phẫu thuật."
            },
            new()
            {
                Id = "d37",
                Name = "Viêm gan C",
                Description = "Viêm gan do virus Hepatitis C",
                Symptoms = new List<string> { "s66", "s7", "s8", "s10", "s27", "s30" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s66", 0.90 },     // Vàng da - đặc hiệu
                    { "s7", 0.80 },      // Mệt mỏi
                    { "s8", 0.75 },      // Buồn nôn
                    { "s10", 0.70 },     // Đau bụng
                    { "s27", 0.65 },     // Sụt cân
                    { "s30", 0.60 },     // Sốt nhẹ kéo dài
                },
                Severity = "high",
                Treatment = "Cần điều trị với thuốc kháng virus. Theo dõi chức năng gan. Tránh rượu bia."
            },
            new()
            {
                Id = "d38",
                Name = "Eczema",
                Description = "Viêm da dị ứng, chàm",
                Symptoms = new List<string> { "s15", "s16", "s70", "s69", "s5" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s15", 0.85 },     // Phát ban
                    { "s16", 0.90 },     // Ngứa - rất đặc hiệu
                    { "s70", 0.80 },     // Bong da
                    { "s69", 0.75 },     // Nổi mụn nước
                    { "s5", 0.60 },      // Sổ mũi (dị ứng)
                },
                Severity = "low",
                Treatment = "Dưỡng ẩm da thường xuyên. Dùng thuốc bôi chống viêm. Tránh tác nhân gây dị ứng."
            },
            new()
            {
                Id = "d39",
                Name = "Nấm da",
                Description = "Nhiễm nấm trên da",
                Symptoms = new List<string> { "s15", "s16", "s70", "s69" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s15", 0.80 },     // Phát ban
                    { "s16", 0.85 },     // Ngứa - đặc hiệu
                    { "s70", 0.75 },     // Bong da
                    { "s69", 0.70 },     // Nổi mụn nước
                },
                Severity = "low",
                Treatment = "Dùng thuốc bôi chống nấm. Giữ vùng da khô ráo. Tránh dùng chung khăn, quần áo."
            },
            new()
            {
                Id = "d40",
                Name = "Suy giáp",
                Description = "Tuyến giáp hoạt động kém",
                Symptoms = new List<string> { "s7", "s75", "s77", "s79", "s20", "s76" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s7", 0.85 },      // Mệt mỏi - đặc hiệu
                    { "s75", 0.80 },     // Tăng cân
                    { "s77", 0.75 },     // Bướu cổ
                    { "s79", 0.70 },     // Mất cảm giác ngon miệng
                    { "s20", 0.65 },     // Mất ngủ
                    { "s76", 0.60 },     // Sưng mặt
                },
                Severity = "medium",
                Treatment = "Dùng thuốc hormone tuyến giáp thay thế. Theo dõi định kỳ. Chế độ ăn đủ i-ốt."
            },
            new()
            {
                Id = "d41",
                Name = "Cường giáp",
                Description = "Tuyến giáp hoạt động quá mức",
                Symptoms = new List<string> { "s22", "s78", "s27", "s73", "s74", "s77" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s22", 0.85 },     // Tim đập nhanh - đặc hiệu
                    { "s78", 0.80 },     // Run tay
                    { "s27", 0.75 },     // Sụt cân
                    { "s73", 0.70 },     // Khát nước nhiều
                    { "s74", 0.65 },     // Đói nhiều
                    { "s77", 0.60 },     // Bướu cổ
                },
                Severity = "high",
                Treatment = "Dùng thuốc ức chế tuyến giáp. Có thể cần phẫu thuật hoặc i-ốt phóng xạ. Theo dõi chặt chẽ."
            },
            new()
            {
                Id = "d42",
                Name = "Thoái hóa khớp",
                Description = "Thoái hóa sụn khớp",
                Symptoms = new List<string> { "s17", "s18", "s25", "s7", "s48" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s17", 0.85 },     // Đau khớp - đặc hiệu
                    { "s18", 0.80 },     // Sưng khớp
                    { "s25", 0.75 },     // Đau lưng
                    { "s7", 0.70 },      // Mệt mỏi
                    { "s48", 0.65 },     // Yếu cơ
                },
                Severity = "medium",
                Treatment = "Vật lý trị liệu. Dùng thuốc giảm đau, chống viêm. Giảm cân nếu béo phì. Tránh vận động quá sức."
            },
            new()
            {
                Id = "d43",
                Name = "Loãng xương",
                Description = "Xương yếu, dễ gãy",
                Symptoms = new List<string> { "s25", "s17", "s48", "s27", "s72" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s25", 0.80 },     // Đau lưng
                    { "s17", 0.75 },     // Đau khớp
                    { "s48", 0.70 },     // Yếu cơ
                    { "s27", 0.65 },     // Sụt cân
                    { "s72", 0.60 },     // Móng tay giòn
                },
                Severity = "medium",
                Treatment = "Bổ sung canxi và vitamin D. Tập thể dục nhẹ nhàng. Dùng thuốc chống loãng xương. Tránh té ngã."
            },
            new()
            {
                Id = "d44",
                Name = "Trào ngược dạ dày",
                Description = "Acid dạ dày trào ngược lên thực quản",
                Symptoms = new List<string> { "s80", "s4", "s8", "s19", "s10" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s80", 0.90 },     // Ợ nóng - rất đặc hiệu
                    { "s4", 0.75 },      // Đau họng
                    { "s8", 0.70 },      // Buồn nôn
                    { "s19", 0.65 },     // Rối loạn tiêu hóa
                    { "s10", 0.60 },     // Đau bụng
                },
                Severity = "medium",
                Treatment = "Tránh thức ăn cay, chua, dầu mỡ. Không nằm ngay sau khi ăn. Dùng thuốc giảm acid dạ dày."
            },
            new()
            {
                Id = "d45",
                Name = "Viêm loét dạ dày",
                Description = "Loét niêm mạc dạ dày",
                Symptoms = new List<string> { "s10", "s80", "s8", "s13", "s19" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s10", 0.90 },     // Đau bụng - đặc hiệu
                    { "s80", 0.85 },     // Ợ nóng
                    { "s8", 0.80 },      // Buồn nôn
                    { "s13", 0.75 },     // Nôn mửa
                    { "s19", 0.70 },     // Rối loạn tiêu hóa
                },
                Severity = "high",
                Treatment = "Dùng thuốc kháng acid, kháng sinh (nếu có H. pylori). Tránh rượu, thuốc lá. Ăn uống điều độ."
            },
            new()
            {
                Id = "d46",
                Name = "Viêm màng não",
                Description = "Nhiễm trùng màng não",
                Symptoms = new List<string> { "s1", "s3", "s46", "s14", "s44", "s7" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s1", 0.90 },      // Sốt cao - đặc hiệu
                    { "s3", 0.85 },      // Đau đầu dữ dội
                    { "s46", 0.80 },     // Co giật
                    { "s14", 0.75 },     // Chóng mặt
                    { "s44", 0.70 },     // Ngất xỉu
                    { "s7", 0.65 },      // Mệt mỏi
                },
                Severity = "high",
                Treatment = "CẦN CẤP CỨU NGAY! Đây là bệnh nguy hiểm. Dùng kháng sinh đường tĩnh mạch. Theo dõi chặt chẽ."
            },
            new()
            {
                Id = "d47",
                Name = "Viêm khớp dạng thấp",
                Description = "Bệnh tự miễn gây viêm khớp",
                Symptoms = new List<string> { "s17", "s18", "s7", "s1", "s15" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s17", 0.90 },     // Đau khớp - đặc hiệu
                    { "s18", 0.85 },     // Sưng khớp
                    { "s7", 0.80 },      // Mệt mỏi
                    { "s1", 0.75 },      // Sốt cao
                    { "s15", 0.70 },     // Phát ban
                },
                Severity = "high",
                Treatment = "Dùng thuốc chống viêm, ức chế miễn dịch. Vật lý trị liệu. Theo dõi định kỳ."
            },
            new()
            {
                Id = "d48",
                Name = "Bệnh gút",
                Description = "Viêm khớp do acid uric",
                Symptoms = new List<string> { "s17", "s18", "s1", "s7", "s12" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s17", 0.90 },     // Đau khớp đột ngột - đặc hiệu
                    { "s18", 0.85 },     // Sưng khớp
                    { "s1", 0.80 },      // Sốt cao
                    { "s7", 0.75 },      // Mệt mỏi
                    { "s12", 0.70 },     // Đau ngực (hiếm)
                },
                Severity = "medium",
                Treatment = "Dùng thuốc giảm đau, chống viêm. Tránh thức ăn giàu purin (thịt đỏ, hải sản). Uống nhiều nước."
            },
            new()
            {
                Id = "d49",
                Name = "Viêm tụy",
                Description = "Viêm tuyến tụy",
                Symptoms = new List<string> { "s10", "s8", "s13", "s1", "s7" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s10", 0.95 },     // Đau bụng dữ dội - rất đặc hiệu
                    { "s8", 0.85 },      // Buồn nôn
                    { "s13", 0.80 },     // Nôn mửa
                    { "s1", 0.75 },      // Sốt cao
                    { "s7", 0.70 },      // Mệt mỏi
                },
                Severity = "high",
                Treatment = "CẦN NHẬP VIỆN NGAY! Nhịn ăn, truyền dịch. Dùng thuốc giảm đau. Có thể cần phẫu thuật."
            },
            new()
            {
                Id = "d50",
                Name = "Viêm túi thừa",
                Description = "Viêm túi thừa đại tràng",
                Symptoms = new List<string> { "s10", "s1", "s9", "s24", "s7" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s10", 0.85 },     // Đau bụng
                    { "s1", 0.80 },      // Sốt cao
                    { "s9", 0.75 },      // Tiêu chảy
                    { "s24", 0.70 },     // Táo bón
                    { "s7", 0.65 },      // Mệt mỏi
                },
                Severity = "medium",
                Treatment = "Nghỉ ngơi, ăn thức ăn mềm. Dùng kháng sinh. Uống nhiều nước. Nếu nặng cần phẫu thuật."
            },
            new()
            {
                Id = "d51",
                Name = "Viêm mũi xoang",
                Description = "Viêm mũi và các xoang",
                Symptoms = new List<string> { "s5", "s3", "s4", "s28", "s7" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s5", 0.85 },
                    { "s3", 0.80 },
                    { "s4", 0.75 },
                    { "s28", 0.70 },
                    { "s7", 0.65 },
                },
                Severity = "low",
                Treatment = "Rửa mũi bằng nước muối. Dùng thuốc kháng sinh nếu cần. Xông mũi."
            },
            new()
            {
                Id = "d52",
                Name = "Viêm họng hạt",
                Description = "Viêm họng mạn tính",
                Symptoms = new List<string> { "s4", "s28", "s29", "s7", "s3" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s4", 0.85 },
                    { "s28", 0.80 },
                    { "s29", 0.75 },
                    { "s7", 0.70 },
                    { "s3", 0.65 },
                },
                Severity = "low",
                Treatment = "Súc miệng nước muối. Dùng thuốc kháng sinh. Tránh hút thuốc, uống rượu."
            },
            new()
            {
                Id = "d53",
                Name = "Viêm tai ngoài",
                Description = "Nhiễm trùng ống tai ngoài",
                Symptoms = new List<string> { "s55", "s16", "s56", "s54", "s14" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s55", 0.90 },
                    { "s16", 0.80 },
                    { "s56", 0.75 },
                    { "s54", 0.70 },
                    { "s14", 0.65 },
                },
                Severity = "low",
                Treatment = "Nhỏ thuốc tai kháng sinh. Giữ tai khô ráo. Tránh ngoáy tai."
            },
            new()
            {
                Id = "d54",
                Name = "Viêm bàng quang cấp",
                Description = "Nhiễm trùng bàng quang",
                Symptoms = new List<string> { "s58", "s57", "s59", "s10", "s1" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s58", 0.90 },
                    { "s57", 0.85 },
                    { "s59", 0.80 },
                    { "s10", 0.70 },
                    { "s1", 0.65 },
                },
                Severity = "medium",
                Treatment = "Uống nhiều nước. Dùng kháng sinh theo chỉ định. Tránh nhịn tiểu."
            },
            new()
            {
                Id = "d55",
                Name = "Viêm đường tiết niệu",
                Description = "Nhiễm trùng đường tiết niệu",
                Symptoms = new List<string> { "s58", "s57", "s59", "s10", "s1" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s58", 0.88 },
                    { "s57", 0.82 },
                    { "s59", 0.78 },
                    { "s10", 0.72 },
                    { "s1", 0.68 },
                },
                Severity = "medium",
                Treatment = "Uống nhiều nước. Dùng kháng sinh. Vệ sinh sạch sẽ. Tránh nhịn tiểu."
            },
            new()
            {
                Id = "d56",
                Name = "Viêm da tiếp xúc",
                Description = "Viêm da do tiếp xúc chất kích thích",
                Symptoms = new List<string> { "s15", "s16", "s69", "s70" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s15", 0.85 },
                    { "s16", 0.90 },
                    { "s69", 0.80 },
                    { "s70", 0.75 },
                },
                Severity = "low",
                Treatment = "Tránh tác nhân gây kích ứng. Dùng thuốc bôi chống viêm. Dưỡng ẩm da."
            },
            new()
            {
                Id = "d57",
                Name = "Nấm móng",
                Description = "Nhiễm nấm móng tay/chân",
                Symptoms = new List<string> { "s72", "s15", "s16", "s70" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s72", 0.90 },
                    { "s15", 0.75 },
                    { "s16", 0.80 },
                    { "s70", 0.70 },
                },
                Severity = "low",
                Treatment = "Dùng thuốc bôi chống nấm. Giữ móng khô ráo. Có thể cần thuốc uống."
            },
            new()
            {
                Id = "d58",
                Name = "Viêm kết mạc dị ứng",
                Description = "Viêm mắt do dị ứng",
                Symptoms = new List<string> { "s52", "s53", "s16", "s51", "s5" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s52", 0.85 },
                    { "s53", 0.80 },
                    { "s16", 0.75 },
                    { "s51", 0.70 },
                    { "s5", 0.65 },
                },
                Severity = "low",
                Treatment = "Tránh tác nhân gây dị ứng. Dùng thuốc nhỏ mắt kháng histamin. Chườm lạnh."
            },
            new()
            {
                Id = "d59",
                Name = "Đau dạ dày",
                Description = "Đau vùng thượng vị",
                Symptoms = new List<string> { "s10", "s80", "s8", "s19", "s7" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s10", 0.88 },
                    { "s80", 0.85 },
                    { "s8", 0.78 },
                    { "s19", 0.72 },
                    { "s7", 0.68 },
                },
                Severity = "medium",
                Treatment = "Ăn uống điều độ, tránh thức ăn cay nóng. Dùng thuốc giảm acid. Tránh stress."
            },
            new()
            {
                Id = "d60",
                Name = "Hội chứng tiền kinh nguyệt",
                Description = "Triệu chứng trước kỳ kinh",
                Symptoms = new List<string> { "s64", "s21", "s20", "s10", "s7" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s64", 0.85 },
                    { "s21", 0.80 },
                    { "s20", 0.75 },
                    { "s10", 0.70 },
                    { "s7", 0.65 },
                },
                Severity = "low",
                Treatment = "Tập thể dục nhẹ. Chế độ ăn lành mạnh. Có thể dùng thuốc giảm đau. Giảm stress."
            },
            new()
            {
                Id = "d61",
                Name = "Viêm âm đạo",
                Description = "Nhiễm trùng âm đạo",
                Symptoms = new List<string> { "s62", "s61", "s16", "s57" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s62", 0.90 },
                    { "s61", 0.85 },
                    { "s16", 0.80 },
                    { "s57", 0.75 },
                },
                Severity = "medium",
                Treatment = "Vệ sinh sạch sẽ. Dùng thuốc đặt âm đạo. Tránh mặc quần áo chật. Khám phụ khoa."
            },
            new()
            {
                Id = "d62",
                Name = "Viêm tuyến tiền liệt",
                Description = "Viêm tuyến tiền liệt",
                Symptoms = new List<string> { "s58", "s57", "s10", "s7", "s1" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s58", 0.85 },
                    { "s57", 0.80 },
                    { "s10", 0.75 },
                    { "s7", 0.70 },
                    { "s1", 0.65 },
                },
                Severity = "medium",
                Treatment = "Dùng kháng sinh. Uống nhiều nước. Tránh ngồi lâu. Tắm nước ấm."
            },
            new()
            {
                Id = "d63",
                Name = "Thiếu máu",
                Description = "Giảm số lượng hồng cầu",
                Symptoms = new List<string> { "s7", "s14", "s11", "s22", "s27" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s7", 0.85 },
                    { "s14", 0.80 },
                    { "s11", 0.75 },
                    { "s22", 0.70 },
                    { "s27", 0.65 },
                },
                Severity = "medium",
                Treatment = "Bổ sung sắt, vitamin B12. Ăn thực phẩm giàu sắt. Khám để tìm nguyên nhân."
            },
            new()
            {
                Id = "d64",
                Name = "Cảm lạnh",
                Description = "Nhiễm virus đường hô hấp trên",
                Symptoms = new List<string> { "s5", "s40", "s4", "s31", "s7", "s36" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s5", 0.85 },
                    { "s40", 0.80 },
                    { "s4", 0.75 },
                    { "s31", 0.70 },
                    { "s7", 0.65 },
                    { "s36", 0.60 },
                },
                Severity = "low",
                Treatment = "Nghỉ ngơi, uống nhiều nước ấm. Vitamin C. Thường tự khỏi sau 5-7 ngày."
            },
            new()
            {
                Id = "d65",
                Name = "Viêm amidan cấp",
                Description = "Viêm amidan do vi khuẩn",
                Symptoms = new List<string> { "s4", "s1", "s29", "s3", "s7" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s4", 0.90 },
                    { "s1", 0.85 },
                    { "s29", 0.80 },
                    { "s3", 0.75 },
                    { "s7", 0.70 },
                },
                Severity = "medium",
                Treatment = "Dùng kháng sinh. Súc miệng nước muối. Nghỉ ngơi. Uống nhiều nước."
            },
            new()
            {
                Id = "d66",
                Name = "Đau lưng cấp",
                Description = "Đau lưng đột ngột",
                Symptoms = new List<string> { "s25", "s48", "s7", "s88" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s25", 0.90 },
                    { "s48", 0.80 },
                    { "s7", 0.70 },
                    { "s88", 0.65 },
                },
                Severity = "medium",
                Treatment = "Nghỉ ngơi, chườm nóng/lạnh. Dùng thuốc giảm đau. Vật lý trị liệu. Tránh nâng vật nặng."
            },
            new()
            {
                Id = "d67",
                Name = "Đau cổ vai gáy",
                Description = "Đau vùng cổ, vai, gáy",
                Symptoms = new List<string> { "s89", "s88", "s25", "s92", "s7" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s89", 0.90 },
                    { "s88", 0.85 },
                    { "s25", 0.80 },
                    { "s92", 0.75 },
                    { "s7", 0.70 },
                },
                Severity = "low",
                Treatment = "Xoa bóp, chườm nóng. Dùng thuốc giảm đau. Vật lý trị liệu. Tránh ngồi lâu."
            },
            new()
            {
                Id = "d68",
                Name = "Chuột rút cơ",
                Description = "Co thắt cơ đột ngột",
                Symptoms = new List<string> { "s91", "s6", "s7" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s91", 0.95 },
                    { "s6", 0.80 },
                    { "s7", 0.70 },
                },
                Severity = "low",
                Treatment = "Kéo giãn cơ nhẹ nhàng. Massage. Bổ sung kali, magie. Uống đủ nước."
            },
            new()
            {
                Id = "d69",
                Name = "Đau răng",
                Description = "Đau nhức răng",
                Symptoms = new List<string> { "s84", "s85", "s86", "s3" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s84", 0.95 },
                    { "s85", 0.80 },
                    { "s86", 0.75 },
                    { "s3", 0.70 },
                },
                Severity = "low",
                Treatment = "Khám nha sĩ. Dùng thuốc giảm đau. Vệ sinh răng miệng sạch sẽ. Súc miệng nước muối."
            },
            new()
            {
                Id = "d70",
                Name = "Viêm lợi",
                Description = "Viêm nướu răng",
                Symptoms = new List<string> { "s85", "s86", "s84", "s15" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s85", 0.90 },
                    { "s86", 0.85 },
                    { "s84", 0.80 },
                    { "s15", 0.75 },
                },
                Severity = "low",
                Treatment = "Vệ sinh răng miệng kỹ. Súc miệng nước muối. Khám nha sĩ. Dùng chỉ nha khoa."
            },
            new()
            {
                Id = "d71",
                Name = "Đau dạ dày cấp",
                Description = "Đau dạ dày đột ngột",
                Symptoms = new List<string> { "s104", "s80", "s8", "s13", "s19" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s104", 0.90 },
                    { "s80", 0.85 },
                    { "s8", 0.80 },
                    { "s13", 0.75 },
                    { "s19", 0.70 },
                },
                Severity = "medium",
                Treatment = "Ăn nhạt, uống thuốc giảm acid. Tránh thức ăn cay, dầu mỡ. Nghỉ ngơi."
            },
            new()
            {
                Id = "d72",
                Name = "Viêm đại tràng",
                Description = "Viêm niêm mạc đại tràng",
                Symptoms = new List<string> { "s10", "s9", "s24", "s19", "s7" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s10", 0.88 },
                    { "s9", 0.85 },
                    { "s24", 0.80 },
                    { "s19", 0.75 },
                    { "s7", 0.70 },
                },
                Severity = "medium",
                Treatment = "Chế độ ăn kiêng. Dùng thuốc chống viêm. Tránh stress. Uống nhiều nước."
            },
            new()
            {
                Id = "d73",
                Name = "Hội chứng ruột kích thích",
                Description = "Rối loạn chức năng đại tràng",
                Symptoms = new List<string> { "s10", "s9", "s24", "s82", "s19" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s10", 0.85 },
                    { "s9", 0.80 },
                    { "s24", 0.75 },
                    { "s82", 0.80 },
                    { "s19", 0.70 },
                },
                Severity = "low",
                Treatment = "Chế độ ăn FODMAP. Tránh stress. Tập thể dục. Dùng thuốc điều hòa tiêu hóa."
            },
            new()
            {
                Id = "d74",
                Name = "Đầy hơi",
                Description = "Đầy bụng, khó tiêu",
                Symptoms = new List<string> { "s82", "s81", "s19", "s10" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s82", 0.90 },
                    { "s81", 0.85 },
                    { "s19", 0.80 },
                    { "s10", 0.75 },
                },
                Severity = "low",
                Treatment = "Ăn chậm, nhai kỹ. Tránh thức ăn gây đầy hơi. Uống trà gừng. Vận động nhẹ."
            },
            new()
            {
                Id = "d75",
                Name = "Viêm mũi dị ứng",
                Description = "Dị ứng mũi",
                Symptoms = new List<string> { "s110", "s111", "s40", "s5", "s16" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s110", 0.90 },
                    { "s111", 0.85 },
                    { "s40", 0.80 },
                    { "s5", 0.75 },
                    { "s16", 0.70 },
                },
                Severity = "low",
                Treatment = "Tránh tác nhân gây dị ứng. Dùng thuốc kháng histamin. Rửa mũi bằng nước muối."
            },
            new()
            {
                Id = "d76",
                Name = "Hen phế quản",
                Description = "Bệnh hen suyễn",
                Symptoms = new List<string> { "s113", "s11", "s31", "s12", "s7" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s113", 0.95 },
                    { "s11", 0.90 },
                    { "s31", 0.85 },
                    { "s12", 0.80 },
                    { "s7", 0.75 },
                },
                Severity = "high",
                Treatment = "Dùng thuốc xịt giãn phế quản. Tránh tác nhân kích thích. Có kế hoạch kiểm soát lâu dài."
            },
            new()
            {
                Id = "d77",
                Name = "Viêm phế quản cấp",
                Description = "Viêm đường dẫn khí cấp tính",
                Symptoms = new List<string> { "s32", "s31", "s11", "s1", "s7" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s32", 0.88 },
                    { "s31", 0.85 },
                    { "s11", 0.80 },
                    { "s1", 0.75 },
                    { "s7", 0.70 },
                },
                Severity = "medium",
                Treatment = "Nghỉ ngơi, uống nhiều nước. Dùng thuốc giảm ho. Có thể cần kháng sinh."
            },
            new()
            {
                Id = "d78",
                Name = "Đau đầu căng thẳng",
                Description = "Đau đầu do căng thẳng",
                Symptoms = new List<string> { "s3", "s118", "s21", "s20", "s7" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s3", 0.90 },
                    { "s118", 0.85 },
                    { "s21", 0.80 },
                    { "s20", 0.75 },
                    { "s7", 0.70 },
                },
                Severity = "low",
                Treatment = "Thư giãn, massage. Dùng thuốc giảm đau. Tránh stress. Tập thể dục nhẹ."
            },
            new()
            {
                Id = "d79",
                Name = "Đau đầu do thiếu ngủ",
                Description = "Đau đầu vì thiếu ngủ",
                Symptoms = new List<string> { "s116", "s20", "s7", "s3" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s116", 0.90 },
                    { "s20", 0.85 },
                    { "s7", 0.80 },
                    { "s3", 0.75 },
                },
                Severity = "low",
                Treatment = "Ngủ đủ giấc (7-8 tiếng). Tạo thói quen ngủ tốt. Tránh caffeine trước khi ngủ."
            },
            new()
            {
                Id = "d80",
                Name = "Mỏi mắt",
                Description = "Mắt mỏi, nhức mắt",
                Symptoms = new List<string> { "s119", "s50", "s120", "s3" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s119", 0.90 },
                    { "s50", 0.85 },
                    { "s120", 0.80 },
                    { "s3", 0.75 },
                },
                Severity = "low",
                Treatment = "Nghỉ mắt thường xuyên. Nhỏ thuốc mắt. Điều chỉnh ánh sáng. Khám mắt định kỳ."
            },
            new()
            {
                Id = "d81",
                Name = "Khô mắt",
                Description = "Mắt khô, thiếu nước mắt",
                Symptoms = new List<string> { "s120", "s119", "s51", "s53" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s120", 0.95 },
                    { "s119", 0.85 },
                    { "s51", 0.80 },
                    { "s53", 0.75 },
                },
                Severity = "low",
                Treatment = "Nhỏ nước mắt nhân tạo. Tránh gió, khói. Uống đủ nước. Chớp mắt thường xuyên."
            },
            new()
            {
                Id = "d82",
                Name = "Viêm mũi họng",
                Description = "Viêm mũi và họng",
                Symptoms = new List<string> { "s4", "s5", "s110", "s111", "s7" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s4", 0.88 },
                    { "s5", 0.85 },
                    { "s110", 0.80 },
                    { "s111", 0.75 },
                    { "s7", 0.70 },
                },
                Severity = "low",
                Treatment = "Súc miệng nước muối. Rửa mũi. Nghỉ ngơi. Uống nhiều nước ấm."
            },
            new()
            {
                Id = "d83",
                Name = "Ho kéo dài",
                Description = "Ho mãn tính",
                Symptoms = new List<string> { "s31", "s32", "s112", "s28", "s7" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s31", 0.85 },
                    { "s32", 0.80 },
                    { "s112", 0.75 },
                    { "s28", 0.70 },
                    { "s7", 0.65 },
                },
                Severity = "medium",
                Treatment = "Khám bác sĩ để tìm nguyên nhân. Tránh khói thuốc. Dùng thuốc giảm ho. Uống nhiều nước."
            },
            new()
            {
                Id = "d84",
                Name = "Đau bụng do khó tiêu",
                Description = "Đau bụng vì khó tiêu",
                Symptoms = new List<string> { "s10", "s82", "s81", "s19", "s8" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s10", 0.88 },
                    { "s82", 0.85 },
                    { "s81", 0.80 },
                    { "s19", 0.75 },
                    { "s8", 0.70 },
                },
                Severity = "low",
                Treatment = "Ăn chậm, nhai kỹ. Tránh thức ăn nhiều dầu mỡ. Uống trà gừng. Nghỉ ngơi sau ăn."
            },
            new()
            {
                Id = "d85",
                Name = "Đau bụng do táo bón",
                Description = "Đau bụng vì táo bón",
                Symptoms = new List<string> { "s10", "s24", "s82", "s19", "s7" },
                SymptomsCF = new Dictionary<string, double>
                {
                    { "s10", 0.90 },
                    { "s24", 0.95 },
                    { "s82", 0.85 },
                    { "s19", 0.80 },
                    { "s7", 0.75 },
                },
                Severity = "low",
                Treatment = "Ăn nhiều chất xơ. Uống nhiều nước. Tập thể dục. Có thể dùng thuốc nhuận tràng."
            },
        };
    }
}

