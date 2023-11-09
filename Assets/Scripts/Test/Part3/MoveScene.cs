using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveScene : RoomPart
{
    public void WhenClicked() { //뒤로가기 버튼 만들때 사용(없어도 됨)
        string ButtonName = EventSystem.current.currentSelectedGameObject.name;
        room.gameManager.ChangeRoom(ButtonName);
    }

    public void MovePass(){ // Test_pass 스크립트에 있는 flag를 통해서 금고 이동위치 정함
        if(Text_pass.flag){
            room.gameManager.ChangeRoom("passed_room");
        }
        else{
            room.gameManager.ChangeRoom("pass_room");
        }
    }

    public void chkPassRoom(){
        if(Text_pass.flag){ // 금고 여는 버튼을 누를 때 사용
            room.gameManager.ChangeRoom("passed_room");
        }
    }
}
