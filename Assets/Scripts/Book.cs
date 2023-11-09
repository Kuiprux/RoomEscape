using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    public GameObject red_book_image;
    public GameObject blue_book_image;
    public GameObject purple_book_image;
    public GameObject gray_book_image;




    public void IsBookClick(string color)
    {
        if (color == "Red") { red_book_image.SetActive(true); }
        if (color == "Blue") { blue_book_image.SetActive(true); }
        if (color == "Purple") { purple_book_image.SetActive(true); }
        if (color == "Gray") { gray_book_image.SetActive(true); }



    }

    public void IsBookReturn(string color)
    {
        if (color == "Red") { red_book_image.SetActive(false); }
        if (color == "Blue") { blue_book_image.SetActive(false); }
        if (color == "Purple") { purple_book_image.SetActive(false); }
        if (color == "Gray") { gray_book_image.SetActive(false); }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
