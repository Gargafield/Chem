using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ingredient : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] public ElementObject Element;


    private GameObject _ingredientPrefab;
    public void OnBeginDrag(PointerEventData eventData) {
        _ingredientPrefab = transform.parent.gameObject;
    }

    public void OnEndDrag(PointerEventData eventData) {
        transform.position = _ingredientPrefab.transform.position;
    }

    public void OnDrag(PointerEventData eventData) {
        transform.position = Input.mousePosition;
    }

    void Awake()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = Element.Symbol;
    }
}
