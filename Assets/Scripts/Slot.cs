using TMPro;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public GameObject Prefab; 
    public ElementObject Element;
    public GameObject Ingredient;
    
    void Awake() {
        Prefab.GetComponent<Ingredient>().Element = Element;
        
        
        
        Prefab.SetActive(false);
        
        Ingredient = Instantiate(Prefab, Vector3.zero, Quaternion.identity);
        Debug.Log("Ingredient created");
        Ingredient.transform.SetParent(transform);
        Debug.Log("Ingredient parented");
        
        Ingredient.SetActive(true);
        Debug.Log("Ingredient activated");
    }

    void Update() {
        
    }
}
