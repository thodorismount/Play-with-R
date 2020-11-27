using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject item; //itemBeingDragged
    Vector3 startPosition;
    Transform startParent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        item = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        var screenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        screenPoint.z = 102.0f;
        transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        item = null;
        if (transform.parent == startParent || transform.parent == transform.root)
        {
            transform.position = startPosition;
            transform.SetParent(startParent);
        }
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}