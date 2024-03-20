using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BtnGetResult : MonoBehaviour
{
    public Image resultImage; // Thêm tham chiếu này
    public GameObject panel; // Thêm tham chiếu này
    public GameObject OnePlayerPanel; // Thêm tham chiếu này
    public GameObject ResultPanel; // Thêm tham chiếu này
    public Sprite truthSprite; // Sprite cho "Nói thật"
    public Sprite lieSprite; // Sprite cho "Nói dối"
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RandomResult()
    {
        panel.SetActive(false); // Bật panel "Result"
        OnePlayerPanel.SetActive(false); // Tắt panel "Một người chơi"
        ResultPanel.SetActive(true); // Bật panel "Kết quả"
        // Random kết quả là nói dối hoặc nói thật
        int result = Random.Range(0, 2); // Tạo một số ngẫu nhiên là 0 hoặc 1

        //result = 0; // Tạm thời gán result = 1 để kiểm tra kết quả

        if (result == 0)
        {
            Debug.Log("Nói thật");
            resultImage.sprite = truthSprite; // Cập nhật Image với sprite "Nói thật"
        }
        else
        {
            Debug.Log("Nói dối");
            resultImage.sprite = lieSprite; // Cập nhật Image với sprite "Nói dối"
        }

        panel.SetActive(false); // Hiển thị panel

        // Hiển thị Image
        resultImage.gameObject.SetActive(true);

    }
}
