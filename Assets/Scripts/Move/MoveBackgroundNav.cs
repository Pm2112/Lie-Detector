using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MoveBackgroundNav : MonoBehaviour
{
    private RectTransform rect;
    public Image textimage1;
    public Image textimage2;
    public Image textimage3;
    public RawImage camerra;
    // Start is called before the first frame update
    void Start()
    {
        rect = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private float duration = 0.3f; // Thời gian di chuyển

    // Hàm này sẽ được gọi khi button được click
    public void MoveBackgroundOnePlayer()
    {
        rect.DOAnchorPos(new Vector2(-346, 8.5f), duration);
        textimage1.gameObject.SetActive(true);
        textimage2.gameObject.SetActive(false);
        textimage3.gameObject.SetActive(false);
        camerra.gameObject.SetActive(false);
    }
    public void MoveBackgroundTwoPlayer()
    {
        rect.DOAnchorPos(new Vector2(0, 8.5f), duration);
        textimage1.gameObject.SetActive(false);
        textimage2.gameObject.SetActive(true);
        textimage3.gameObject.SetActive(false);
        camerra.gameObject.SetActive(false);
    }
    public void MoveBackgroundEyesPlayer()
    {
        rect.DOAnchorPos(new Vector2(346, 8.5f), duration);
        textimage1.gameObject.SetActive(false);
        textimage2.gameObject.SetActive(false);
        textimage3.gameObject.SetActive(true);

    }
}
