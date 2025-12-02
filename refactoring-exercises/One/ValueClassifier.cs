namespace One;

public class ValueClassifier
{
    private const int SpecialErrorValue = -9999;
    private const int HighThreshold = 10;
    
    public void PrintClassification(int value)
    {
        string classification = ClassifyValue(value);
        Console.WriteLine(classification);
    }
    
    public string ClassifyValue(int value)
    {
        if (IsSpecialErrorCase(value))
        {
            return "CASO RARO";
        }
        
        if (IsHighValue(value))
        {
            return "ALTO";
        }
        
        if (IsMediumValue(value))
        {
            return "MÉDIO";
        }
        
        return "BAIXO";
    }

    private bool IsSpecialErrorCase(int value)
    {
        return value == SpecialErrorValue;
    }

    private bool IsHighValue(int value)
    {
        return value > HighThreshold;
    }

    private bool IsMediumValue(int value)
    {
        return value == HighThreshold;
    }
}