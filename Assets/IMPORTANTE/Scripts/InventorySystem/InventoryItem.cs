using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //private Item item;

    private CanvasGroup canvasGroup;
    private Transform originalParent;

    //[Header("UI")]
    [SerializeField] Image image;

    //[HideInInspector] public Transform parentAfterDrag;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null )
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }

    //private void Start()
    //{
    //    //InitialiseItem(item);
    //}

    //public void InitialiseItem(Item newItem)
    //{
    //    item = newItem;
    //    image.sprite = newItem.image;
    //}

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        //image.raycastTarget = false;
        //parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        if (transform.parent == transform.root)
        {
            transform.SetParent(originalParent);
            transform.localPosition = Vector3.zero;
        }

        //image.raycastTarget = true;
        //transform.SetParent(parentAfterDrag);
        //transform.localPosition = Vector3.zero;
    }
}