
public interface IElement {
    string FullName { get; }
    string Symbol { get; }
    string GetSymbol(bool richText);
    double AtomicWeight { get; }
    int Charge { get; }
    bool IsMetal { get; }

}

public class Element : IElement
{
    public string FullName { get; }
    public string Symbol { get; }
    public int AtomicNumber { get; }
    public double AtomicWeight { get; }
    public int Charge { get; }
    public bool IsMetal { get; }

    public string GetSymbol(bool richText = false)
    {
        var charge = Charge == 0 ? "" : Charge.ToString();
        return richText ? $"{Symbol}<sub>{charge}</sub>" : Symbol;
    }   

    public Element(string fullName, string symbol, int atomicNumber, double atomicWeight, int charge, bool isMetal)
    {
        FullName = fullName;
        Symbol = symbol;
        AtomicNumber = atomicNumber;
        AtomicWeight = atomicWeight;
        Charge = charge;
        IsMetal = isMetal;
    }
}
