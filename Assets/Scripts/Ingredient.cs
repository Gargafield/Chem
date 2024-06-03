using System;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ingredient : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] public ElementObject Element;
    
    private PotionManager _potionManager;
    private bool _isDragging;
    private Vector3? _targetPosition;
    private Quaternion _targetRotation;
    
    void Start() {
        _potionManager = GameObject.Find("Managers").GetComponent<PotionManager>();
        _ingredientPrefab = transform.parent.gameObject;
        _targetPosition = null;
        
        Debug.Log("Ingredient started");
        Debug.Log(_targetPosition);
        
        GetComponentInChildren<TextMeshProUGUI>().text = Element.Symbol;
    }

    private GameObject _ingredientPrefab;
    public void OnBeginDrag(PointerEventData eventData) {
        _isDragging = true;
        _ingredientPrefab = transform.parent.gameObject;
    }

    public void OnEndDrag(PointerEventData eventData) {
        _isDragging = false;
        _targetPosition = _ingredientPrefab.transform.position;
        _targetRotation = Quaternion.identity;
    }

    public void OnDrag(PointerEventData eventData) {
        _targetPosition = Input.mousePosition;
    }
    
    public void Update() {
        if (_isDragging) {
            RotateDraggedIngredient();
        }
        
        // Lerp the position and rotation
        if (_targetPosition != null && _targetPosition != transform.position)
            transform.position = Vector3.Lerp(transform.position, _targetPosition.Value, 14f * Time.deltaTime);
        if (_targetRotation != transform.rotation)
            transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, 7f * Time.deltaTime);
    }
    
    private void RotateDraggedIngredient() {
        _targetRotation = Quaternion.identity;
        
        var potion = _potionManager.Potion;
        var distScaled = Math.Abs(potion.transform.position.x - transform.position.x) / Screen.width;
        
        if (distScaled < 0.2 && distScaled > 0.045) {
            var direction = potion.transform.position - transform.position;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            
            angle = Mathf.Clamp(angle, -180, 0);
            
            if (angle < -90) {
                _targetRotation = Quaternion.AngleAxis(angle - 180, Vector3.forward);
            } else {
                _targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
    }
}
