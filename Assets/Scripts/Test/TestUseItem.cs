using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUseItem : RoomPart
{
    public void WhenClicked() {
        Debug.Log(room.inventoryManager.GetActiveItem());
        room.inventoryManager.UseActiveItem();
    }
}
