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
        ShakeButton.SetActive(false);
        ShakeButton.GetComponent<Button>().onClick.AddListener(OnShake);
        DontDestroyOnLoad(gameObject);
    }

    public void OnShake() {
        var reactions = Bag.CalculateReactions();

        Debug.Log("Reactions:");
        foreach (var _ in reactions) {
            Debug.Log(_);
        }
        var reaction = reactions.FirstOrDefault();

        ReactionLabel.SetActive(true);
        ReactionLabel.GetComponent<TextMeshProUGUI>().text = reaction?.GetSymbol(richText : true) ?? "No reaction";
        ShakeButton.SetActive(false);
        Bag.Clear();

        Task.Delay(5000).ContinueWith(_ => {
            ReactionLabel.SetActive(false);
            ReactionLabel.GetComponent<TextMeshProUGUI>().text = "";
        });
    }

    public void AddElement(ElementObject element) {
        Bag.AddElement(element.GetElement());

        if (Bag.Elements.Count > 1) {
            ShakeButton.SetActive(true);
        }
    }
}
