using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    private PotionManager _potionManager;
    
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Particle") {
            var element = collider.gameObject.GetComponent<Particle>().Element;
            _potionManager.AddElement(element);
            Destroy(collider.gameObject);
        }
    }
    
    void Awake()
    {
        _potionManager = GameObject.Find("Managers").GetComponent<PotionManager>();
    }
}
