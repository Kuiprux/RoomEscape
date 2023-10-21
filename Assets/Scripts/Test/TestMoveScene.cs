using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMoveScene : RoomPart
{
    public void WhenClicked() {
        room.gameManager.ChangeRoom("test_room1");
    }
}
