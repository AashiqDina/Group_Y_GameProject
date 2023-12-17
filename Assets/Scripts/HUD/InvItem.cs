using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InvItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // Start is called before the first frame update

    public Transform newParent;
    public Image img;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBeginDrag(PointerEventData e){
        Debug.Log("Begin Dragging");
        newParent = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        img.raycastTarget = false;
    }
    public void OnDrag(PointerEventData e){
        Debug.Log("Dragging");
        transform.position = Mouse.current.position.ReadValue();
    }
    public void OnEndDrag(PointerEventData e){
        Debug.Log("End Dragging");
        transform.SetParent(newParent);
        img.raycastTarget = true;
    }


}
