using System.Collections.Generic;
using System.Linq;

public class Bag
{
    public List<Element> Elements { get; private set; }

    public Bag()
    {
        Elements = new List<Element>();
    }

    public void AddElement(Element element)
    {
        Elements.Add(element);
    }

    public void Clear()
    {
        Elements.Clear();
    }

    public List<Reaction> CalculateReactions() {
        var ordered = Elements.OrderBy(e => e.AtomicNumber);
        var metals = ordered.Where(e => e.IsMetal).GroupBy(e => e.FullName).Select(g => new Compound() {
            Elements = g.ToList<IElement>()
        }).ToList().OrderBy(c => c.GetCharge()).ToList();
        var nonMetals = ordered.Where(e => !e.IsMetal).ToList();
        
        var suffixes = CalculateSuffixes(nonMetals);
        
        var reactions = new List<Reaction>();
        var reaction = new Reaction();

        foreach (var metal in metals) {
            reaction.AddElement(metal);
            
            while (reaction.Charge != 0 && suffixes.Count > 0) {
                var suffix = suffixes.First();
                suffixes.Remove(suffix);
                reaction.AddElement(suffix);
            }

            if (reaction.Charge == 0) {
                reactions.Add(reaction);
                reaction = new Reaction();
            }
        }

        foreach (var suffix in suffixes) {
            reaction.AddElement(suffix);
        }

        if (reaction.Elements.Count > 0) {
            reactions.Add(reaction);
        }

        return reactions;
    }

    private List<Compound> CalculateSuffixes(List<Element> nonMetals)
    {
        var suffixes = new List<Compound>();
        var suffix = new Compound();
        
        var bases = nonMetals.Where(e => e.Charge < 0).OrderBy(e => e.AtomicNumber).ToList();
        var other = nonMetals.Where(e => e.Charge > 0).OrderBy(e => e.AtomicNumber).ToList();

        foreach (var element in bases) {
            nonMetals.Remove(element);
            suffix.AddElement(element);

            while (suffix.Charge != 0 && other.Count > 0) {
                var next = other.First();
                other.Remove(next);
                suffix.AddElement(next);
            }

            if (suffix.Charge == 0) {
                suffixes.Add(suffix);
                suffix = new Compound();
            }
        }

        if (suffix.Elements.Count > 0) {
            suffixes.Add(suffix);
        }

        return suffixes;
    }
}
