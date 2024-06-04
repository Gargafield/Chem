
using System.Collections.Generic;
using System.Linq;

public class Reaction
{
    public List<IElement> Elements { get; set; }
    public int Charge => Elements.Sum(e => e.Charge);

    public Reaction()
    {
        Elements = new List<IElement>();
    }

    public void AddElement(IElement compound)
    {
        Elements.Add(compound);
    }

    public Compound GetProduct() {
        return new Compound() {
            Elements = Elements
        };
    }

    public string GetSymbol(bool richText = false)
    {
        return string.Join(" + ", Elements.Select(e => {
            return e.GetSymbol(richText);
        })) + " -> " + GetProduct().GetSymbol(richText);
    }
}
