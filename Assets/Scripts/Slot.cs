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
        Ingredient.transform.SetParent(transform);
        Ingredient.SetActive(true);
    }

    void Update() {
        
    }
}
