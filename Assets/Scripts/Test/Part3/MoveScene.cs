using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveScene : RoomPart
{
    public void WhenClicked() {
        string ButtonName = EventSystem.current.currentSelectedGameObject.name;
        room.gameManager.ChangeRoom(ButtonName);
    }

    public void BackScene2(){
        room.gameManager.ChangeRoom("main_room2");
    }

    public void MovePass(){
        if(Text_pass.flag){
            room.gameManager.ChangeRoom("passed_room");
        }
        else{
            room.gameManager.ChangeRoom("pass_room");
        }
    }

    public void chkPassRoom(){
        if(Text_pass.flag){
            room.gameManager.ChangeRoom("passed_room");
        }
    }
}
