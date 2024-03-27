using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnStart : MonoBehaviour
{
    public Image Bg_Start;
    public Button Btn_Start;
    public Button Btn_UserOne;
    public Button Btn_UserTwo;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        Bg_Start.gameObject.SetActive(true);
        Btn_Start.gameObject.SetActive(false);
        Btn_UserOne.gameObject.SetActive(true);
        Btn_UserTwo.gameObject.SetActive(true);
    }
}
