using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnRescan : MonoBehaviour
{

    public GameObject PlayerPanel; // Thêm tham chiếu này
    public GameObject ResultPanel; // Thêm tham chiếu này
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Rescan()
    {
        PlayerPanel.SetActive(true); // Bật panel "Một người chơi"
        ResultPanel.SetActive(false); // Tắt panel "Kết quả"
    }
}
