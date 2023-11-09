using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login_Manager : MonoBehaviour
{
    public GameObject LoginView;
    public GameObject Warning;
    Image image;
    Color color;
    public InputField inputField_Pw;
    public string password;
    
    void Start()
    {
        color = LoginView.GetComponent<Image>().color;
    }
    // Start is called before the first frame update
    public void Login()
    {
    if (inputField_Pw.text == password)
        {
            inputField_Pw.gameObject.SetActive(false);
            StartCoroutine(LoginWithDelay(0.01f));
        }
        else
        {
            Warning.SetActive(true);
        }
    }

private IEnumerator LoginWithDelay(float delay)
    {
        for (float i = 1f; i >= 0f; i -= 0.02f)
        {
            color = LoginView.GetComponent<Image>().color;
            color.a = i;
            LoginView.GetComponent<Image>().color = color;

            yield return new WaitForSeconds(delay);
        }

        LoginView.SetActive(false);
    }

    public void Hide()
    {
        Warning.SetActive(false);
    }

}
