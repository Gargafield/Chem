using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PotionManager : MonoBehaviour
{
    public GameObject Potion;
    public GameObject ReactionLabel;
    public GameObject ShakeButton;

    public Bag Bag { get; private set; } = new();

    void Awake()
    {
        ReactionLabel.SetActive(false);
        ShakeButton.GetComponent<Button>().interactable = false;
        ShakeButton.GetComponent<Button>().onClick.AddListener(OnShake);
        DontDestroyOnLoad(gameObject);
    }

    public void OnShake() {
        var reaction = Bag.CalculateReactions();
        
        ReactionLabel.SetActive(true);
        ReactionLabel.GetComponent<TextMeshProUGUI>().text = reaction?.GetSymbol(richText : true) ?? "No reaction";
        ShakeButton.GetComponent<Button>().interactable = false;
        Bag.Clear();

        StartCoroutine(Clear());
    }

    private IEnumerator Clear() {
        yield return new WaitForSeconds(5);
        ReactionLabel.SetActive(false);
        ReactionLabel.GetComponent<TextMeshProUGUI>().text = "";
    }

    public void AddElement(ElementObject element) {
        Bag.AddElement(element.GetElement());

        if (Bag.Elements.Count > 1) {
            ShakeButton.GetComponent<Button>().interactable = true;
        }
    }
}
