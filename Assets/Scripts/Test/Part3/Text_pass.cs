using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Text_pass : MonoBehaviour
{
    public static bool flag=false;
    public Text ScriptText;
    string number="";
    string ButtonName="";

    public void Reset()
    {
        number="";
        ScriptText.text=number;
    }


    public void Plus()
    {
        ButtonName = EventSystem.current.currentSelectedGameObject.name;
        switch(ButtonName){
            case "Btn0": number+="0";break;
            case "Btn1": number+="1";break;
            case "Btn2": number+="2";break;
            case "Btn3": number+="3";break;
            case "Btn4": number+="4";break;
            case "Btn5": number+="5";break;
            case "Btn6": number+="6";break;
            case "Btn7": number+="7";break;
            case "Btn8": number+="8";break;
            case "Btn9": number+="9";break;
        }
        ScriptText.text = number;
        //Debug.Log(number);
    }

    public void Check(){
        if(number=="1234"){
            ScriptText.text="Clear";
            flag=true;
        }
        else{
            ScriptText.text="Fail";
            Invoke("Reset",3);
        }
    }
}
