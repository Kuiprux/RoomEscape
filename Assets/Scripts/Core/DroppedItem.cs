using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DroppedItem : MonoBehaviour, IPointerClickHandler
{
    public string itemId;
    [HideInInspector]
    public GameObject room;

    public void OnPointerClick(PointerEventData eventData) {
        room.GetComponent<Room>().AcquireItem(itemId);
        Destroy(gameObject);
    }
}
