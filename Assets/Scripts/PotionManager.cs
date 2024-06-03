using UnityEngine;

public class PotionManager : MonoBehaviour
{
    public GameObject Potion;
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void AddElement(ElementObject element) {
        // Add the element to the potion
        Debug.Log("Added element " + element.FullName);
    }
}
