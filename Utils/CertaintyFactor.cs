namespace ExpertSystemWinForms.Utils;

public static class CertaintyFactor
{
    /// <summary>
    /// Kết hợp hai CF
    /// CF(A,B) = CF(A) + CF(B) * (1 - CF(A)) nếu cả hai dương
    /// </summary>
    public static double CombineCF(double cf1, double cf2)
    {
        if (cf1 >= 0 && cf2 >= 0)
        {
            return cf1 + cf2 * (1 - cf1);
        }
        else if (cf1 < 0 && cf2 < 0)
        {
            return cf1 + cf2 * (1 + cf1);
        }
        else
        {
            return (cf1 + cf2) / (1 - Math.Min(Math.Abs(cf1), Math.Abs(cf2)));
        }
    }

    /// <summary>
    /// Tính CF tổng hợp từ nhiều bằng chứng
    /// </summary>
    public static double CalculateCombinedCF(List<double> cfs)
    {
        if (cfs.Count == 0) return 0;
        if (cfs.Count == 1) return cfs[0];

        double result = cfs[0];
        for (int i = 1; i < cfs.Count; i++)
        {
            result = CombineCF(result, cfs[i]);
        }

        return result;
    }

    /// <summary>
    /// Tính CF cho bệnh dựa trên các triệu chứng
    /// </summary>
    public static double CalculateDiseaseCF(
        Dictionary<string, string> symptomResponses,
        Dictionary<string, double> diseaseSymptomsCF)
    {
        var positiveCFs = new List<double>();
        var negativeCFs = new List<double>();
        foreach (var (symptomId, baseCF) in diseaseSymptomsCF)
        {
            symptomResponses.TryGetValue(symptomId, out var response);

            if (response == "yes")
            {
                positiveCFs.Add(baseCF);
            }
            else if (response == "no")
            {
                negativeCFs.Add(-baseCF * 0.5); 
            }
        }
        double combinedPositiveCF = positiveCFs.Count > 0 ? CalculateCombinedCF(positiveCFs) : 0;
        double combinedNegativeCF = negativeCFs.Count > 0 ? CalculateCombinedCF(negativeCFs) : 0;
        if (positiveCFs.Count > 0 && negativeCFs.Count > 0)
        {
            return CombineCF(combinedPositiveCF, combinedNegativeCF);
        }
        else if (positiveCFs.Count > 0)
        {
            return combinedPositiveCF;
        }
        else if (negativeCFs.Count > 0)
        {
            return combinedNegativeCF;
        }
        return 0;
    }

    /// <summary>
    /// Chuyển đổi CF sang độ tin cậy
    /// </summary>
    public static string CfToConfidence(double cf)
    {
        double absCF = Math.Abs(cf);
        if (absCF >= 0.7) return "high";
        if (absCF >= 0.4) return "medium";
        return "low";
    }

    /// <summary>
    /// Chuyển CF sang phần trăm (0-100)
    /// </summary>
    public static double CfToPercentage(double cf)
    {
        return Math.Max(0, Math.Min(100, cf * 100));
    }
}

