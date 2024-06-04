using UnityEngine;

[CreateAssetMenu(menuName = "Element", fileName = "New Element")]
public class ElementObject : ScriptableObject
{
    public string FullName;
    public string Symbol;
    public int AtomicNumber;
    public double AtomicWeight;
    public int Charge;
    public bool IsMetal;

    public Element GetElement()
    {
        return new Element(FullName, Symbol, AtomicNumber, AtomicWeight, Charge, IsMetal);
    }
}
