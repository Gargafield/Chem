using System.Collections.Generic;
using UnityEngine;

public class BackBarGenerator : MonoBehaviour
{
   [SerializeField] public List<ElementObject> Elements;
    [SerializeField] public GameObject Prefab;

    public void Awake() {
        Prefab.SetActive(false);
        foreach (ElementObject element in Elements) {
            Prefab.GetComponent<Slot>().Element = element;
            
            GameObject slot = Instantiate(Prefab, Vector3.zero, Quaternion.identity);
            slot.transform.SetParent(transform);
            slot.SetActive(true);
        }
    }
}
