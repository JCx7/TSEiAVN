using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler {

    public enum DRAGGBLE_TYPE {
        CHARACTER,
        OBJECT,
        RELATION_S,
        RELATION_D
    }

    private Transform parentTransform;
    public DRAGGBLE_TYPE type;

    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
        Debug.Log("end drag");
    }

    // Use this for initialization
    void Start () {
        parentTransform = transform.parent;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
