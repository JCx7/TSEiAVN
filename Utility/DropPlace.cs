using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropPlace : MonoBehaviour, IDropHandler {

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Drop on" + gameObject);
        GameObject item = eventData.pointerDrag;
        if (item.GetComponent<Draggable>() != null) {
            GameObject newItemOnSegement = null;
            switch (item.GetComponent<Draggable>().type) {
                case Draggable.DRAGGBLE_TYPE.CHARACTER:
                    newItemOnSegement = Instantiate(Resources.Load(@"UIComponents\CharacterOnSegement")) as GameObject;
                    break;
                case Draggable.DRAGGBLE_TYPE.OBJECT:
                    newItemOnSegement = Instantiate(Resources.Load(@"UIComponents\ObjectOnSegement")) as GameObject;
                    break;
                case Draggable.DRAGGBLE_TYPE.RELATION_D:
                    newItemOnSegement = Instantiate(Resources.Load(@"UIComponents\DoubleRelationOnSegement")) as GameObject;
                    break;
                case Draggable.DRAGGBLE_TYPE.RELATION_S:
                    newItemOnSegement = Instantiate(Resources.Load(@"UIComponents\SingleRelationOnSegement")) as GameObject;
                    break;
            }
            newItemOnSegement.transform.SetParent(GameObject.Find("SegementPanel").transform);
        }if (item.GetComponent<DraggableOnSegement>() != null) {
//            eventData.pointerDrag.transform.position = Vector3.zero;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
