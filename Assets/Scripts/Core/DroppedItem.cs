using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DroppedItem : RoomPart, IPointerClickHandler
{
    public string itemId;
    [HideInInspector]

    public void OnPointerClick(PointerEventData eventData) {
        room.AcquireItem(itemId);
        Destroy(gameObject);
    }
}
