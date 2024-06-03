using UnityEngine;

public class PotionManager : MonoBehaviour
{
    public GameObject Potion;
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
