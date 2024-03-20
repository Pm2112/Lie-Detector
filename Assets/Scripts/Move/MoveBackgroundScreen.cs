using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;

public class MoveBackgroundScreen : MonoBehaviour
{
    private RectTransform rect;
    public float Screen1X;
    public float Screen2X;
    public float Screen3X;

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
    public void MoveBackgroundScreen1()
    {
        rect.DOAnchorPos(new Vector2(Screen1X, 0), duration);
    }

    public void MoveBackgroundScreen2()
    {
        rect.DOAnchorPos(new Vector2(Screen2X, 0), duration);
    }

    public void MoveBackgroundScreen3()
    {
        rect.DOAnchorPos(new Vector2(Screen3X, 0), duration);
    }
}
