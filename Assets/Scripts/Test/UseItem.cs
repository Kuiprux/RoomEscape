using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : RoomPart
{
    public void WhenClicked() {
        Object a = room.inventoryManager;

        Debug.Log(room.inventoryManager.GetActiveItem());
        room.inventoryManager.UseActiveItem();
    }
}
