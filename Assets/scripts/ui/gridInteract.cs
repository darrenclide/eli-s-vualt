/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(inventory))]
public class gridInteract : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    inventoryController invEntoryController;
    inventory inventory;
    public void OnPointerEnter(PointerEventData eventData)
    {
        invEntoryController.selectedItemGrid = inventory;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        invEntoryController.selectedItemGrid = null;
    }
    private void Awake()
    {
        invEntoryController = FindObjectOfType(typeof(inventoryController)) as inventoryController;
        inventory = GetComponent<inventory>();
    }
}
*/