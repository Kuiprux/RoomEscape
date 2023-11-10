using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    List<bool> button_blue = new List<bool>();
    List<bool> button_red = new List<bool>();
    List<bool> button_yellow = new List<bool>();
    List<bool> button_purple = new List<bool>();

    int[] blue_button_exact = { 0, 1, 2, 3, 4, 5, 6 }; //8 ���׸�Ʈ ����
    int[] blue_button_react = { 3, 1, 0, 6, 5, 4, 4, 4 }; // �ݳ��� -> 6 {0,1,3,4,5,6}
    int[] red_button_exact = { 1, 2, 3, 4, 6 };   //3
    int[] red_button_react = { 0, 4, 2, 1, 6, 3, 5 }; // �ݳ��� -> 2 {1,2,4,5,6 }
    int[] yellow_button_exact = { 0, 2, 3, 6 };  //4
    int[] yellow_button_react = { 2, 4, 3, 2, 5, 0, 3 }; // �ݳ��� -> 1 {2, 3}
    int[] purple_button_exact = { 2, 3 };  //1
    int[] purple_button_react = { 5, 5, 0, 1, 5, 5, 5 }; // �ݳ��� -> 8 {0,1,3,4,6}

    //public List<GameObject> return_button_blue = new List<GameObject>();
    //public List<GameObject> return_button_red = new List<GameObject>();
    //public List<GameObject> return_button_gray = new List<GameObject>();
    //public List<GameObject> return_button_purple = new List<GameObject>();
    public List<GameObject> return_button_react = new List<GameObject>();



    bool OnOff(List<bool> button, int n)     //��ư�� �����ִ��� �ƴ��� 
    {
        if (button[n] == false) { return true; }
        else { return false; }

    }

    public void ClickButton_Blue(int n)
    {
        button_blue[n] = OnOff(button_blue, n);
        return_button_react[blue_button_react[n]].SetActive(button_blue[n]);

    }
    public void ClickButton_Red(int n)
    {
        button_red[n] = OnOff(button_red, n);
        return_button_react[red_button_react[n]].SetActive(button_red[n]);

    }
    public void ClickButton_Yellow(int n)
    {
        button_yellow[n] = OnOff(button_yellow, n);
        return_button_react[yellow_button_react[n]].SetActive(button_yellow[n]);

    }
    public void ClickButton_Purple(int n)
    {
        for (int i = 2; i < 7; i++)
        {
            return_button_react[i].SetActive(true);
        }
        button_purple[n] = OnOff(button_purple, n);
        return_button_react[purple_button_react[n]].SetActive(button_purple[n]);
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 7; i++)
        {
            button_blue.Add(false);
            button_red.Add(false);
            button_yellow.Add(false);
            button_purple.Add(false);
        }

        for (int i = 0; i < 7; i++)
        {
            return_button_react[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //    List<int> result = Segment(button_blue);
        //    Debug.Log("Segment(button_blue): " + string.Join(", ", result));

        //    if (Enumerable.SequenceEqual(red_button_exact, Segment(button_red)))
        //    {
        //        return_button.SetActive(false);
        //        return_Image.SetActive(true);
        //    }
        //    if (Enumerable.SequenceEqual(blue_button_exact, Segment(button_blue)))
        //    {
        //        print("Hellow");
        //        return_button.SetActive(false);
        //        return_Image.SetActive(true);
        //    }
        //    if (Enumerable.SequenceEqual(yellow_button_exact, Segment(button_yellow)))
        //    {
        //        return_button.SetActive(false);
        //        return_Image.SetActive(true);
        //    }
        //    if (Enumerable.SequenceEqual(purple_button_exact, Segment(button_purple)))
        //    {
        //        return_button.SetActive(false);
        //        return_Image.SetActive(true);
        //    }

    }

    static List<int> Segment(List<bool> button)
    {
        List<int> num_list = new List<int>();
        num_list.Clear();

        for (int i = 0; i < 7; i++)
        {
            if (button[i] == true) { num_list.Add(i); }
        }

        return num_list;
    }
}
