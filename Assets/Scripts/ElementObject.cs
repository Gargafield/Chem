using UnityEngine;

[CreateAssetMenu(menuName = "Element", fileName = "New Element")]
public class ElementObject : ScriptableObject
{
    public string FullName;
    public string Symbol;
    public int AtomicNumber;
    public double AtomicWeight;
    public int Charge;
}
