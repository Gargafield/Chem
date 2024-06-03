using UnityEngine;
using UnityEngine.UI;

public class Particle : MonoBehaviour
{
    public ElementObject Element;
        
    void Start()
    {
        GetComponent<Image>().color = GenerateColor(Element);
        GetComponent<Rigidbody2D>().gravityScale = 10;
    }
    
    public Color GenerateColor(ElementObject element) {
        // Generate a color based on the char of the symbol
        var hash = element.Symbol.GetHashCode() * 0.5f;
        var h = hash % 360;
        var s = 100;
        var v = 100;
        return Color.HSVToRGB(h / 360f, s / 100f, v / 100f);
    }
    
    void Update()
    {
        if (transform.position.y < -100) {
            Destroy(gameObject);
        }
    }
}
