using System;
using System.Collections.Generic;
using System.Linq;

public class Compound : IElement
{
    public List<IElement> Elements { get; set; }

    public string FullName => GetName();
    public string Symbol => GetSymbol();
    public double AtomicWeight => GetAtomicWeight();
    public int Charge => GetCharge();
    public bool IsMetal => false;

    public Compound()
    {
        Elements = new List<IElement>();
    }

    public void AddElement(IElement element)
    {
        Elements.Add(element);
    }

    public static string[] CountName = new string[] { "mono", "di", "tri", "tetra", "penta", "hexa", "hepta", "octa", "nona", "deca" };

    public string GetName() {
        var counted = Elements.GroupBy(e => e.FullName).Select(g => new { Name = g.Key, Count = g.Count() });
        var name = string.Join("", counted.Select(c => c.Count > 1 ? c.Name + CountName[c.Count] : c.Name));
        return name;
    }
    public string GetSymbol(bool richText = false) {
        var elements = Charge == 0 ? Elements.OrderBy(e => e.AtomicWeight) : Elements.AsEnumerable();

        var counted = elements.GroupBy(e => e is Compound compound ? compound.GetSymbol(richText) : e.Symbol)
        .Select(g => new { Symbol = g.Key, Count = g.Count() });
        var symbol = string.Join("", counted.Select(c => {
            var count = richText ? $"<sub>{c.Count}</sub>" : c.Count.ToString();
            return c.Count > 1 ? c.Symbol + count : c.Symbol;
        }));

        // var charge = richText ? (Charge != 0 ? $"<sup>{Charge}</sup>" : "") : "";
        // return symbol + charge;
        return symbol;
    }
    public int GetCharge() {
        return Elements.Sum(e => e.Charge);
    }
    public double GetAtomicWeight() {
        return Elements.Sum(e => e.AtomicWeight);
    }
}
