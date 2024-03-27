using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnGetResultTwoPlayer : MonoBehaviour
{
    public Image resultUserOneImage; // Thêm tham chiếu này
    public Image resultUserTwoImage; // Thêm tham chiếu này
    public GameObject messagePanel; // Thêm tham chiếu này
    public GameObject TwoPlayerPanel; // Thêm tham chiếu này
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
        messagePanel.SetActive(false); // Bật panel "Result"
        TwoPlayerPanel.SetActive(false); // Tắt panel "Một người chơi"
        ResultPanel.SetActive(true); // Bật panel "Kết quả"
        // Random kết quả là nói dối hoặc nói thật
        int resultOnePlayer = Random.Range(0, 2); // Tạo một số ngẫu nhiên là 0 hoặc 1
        int resultTwoPlayer = Random.Range(0, 2); // Tạo một số ngẫu nhiên là 0 hoặc 1

        //result = 0; // Tạm thời gán result = 1 để kiểm tra kết quả

        if (resultOnePlayer == 0)
        {
            Debug.Log("Nói thật");
            resultUserOneImage.sprite = truthSprite; // Cập nhật Image với sprite "Nói thật"
        }
        else
        {
            Debug.Log("Nói dối");
            resultUserOneImage.sprite = lieSprite; // Cập nhật Image với sprite "Nói dối"
        }

        if (resultTwoPlayer == 0)
        {
            Debug.Log("Nói thật");
            resultUserTwoImage.sprite = truthSprite; // Cập nhật Image với sprite "Nói thật"
        }
        else
        {
            Debug.Log("Nói dối");
            resultUserTwoImage.sprite = lieSprite; // Cập nhật Image với sprite "Nói dối"
        }

        messagePanel.SetActive(false); // Hiển thị panel

        // Hiển thị Image
        resultUserOneImage.gameObject.SetActive(true);
        resultUserTwoImage.gameObject.SetActive(true);

    }
}
