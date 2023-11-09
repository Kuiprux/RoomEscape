using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickMove_Manage : RoomPart, IPointerClickHandler
{
    public string location;
    public void OnPointerClick(PointerEventData eventData) {
        room.gameManager.ChangeRoom(location);
    }
}
