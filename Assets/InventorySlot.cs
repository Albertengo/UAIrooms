using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;

        if (dropped != null && transform.childCount == 0)
        {
            dropped.transform.SetParent(transform); // ¡mover al nuevo slot!
            dropped.transform.localPosition = Vector3.zero; // ¡centrar dentro del slot!
        }
        //var drag = eventData.pointerDrag;
        //if (drag != null && transform.childCount == 0)
        //{
        //    drag.transform.SetParent(transform);
        //    drag.transform.localPosition = Vector3.zero;
        //}
        //if (transform.childCount == 0)
        //{
        //    InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();

        //    inventoryItem.transform.SetParent(transform);
        //    inventoryItem.transform.localPosition = Vector3.zero;
        //}
    }
}
