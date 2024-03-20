using UnityEngine;
using UnityEngine.UI; // Sử dụng để làm việc với UI
using UnityEngine.EventSystems; // Sử dụng để làm việc với sự kiện
using System.Collections;

public class ButtonHold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isHoldingButton = false;
    private float holdTime = 0f;
    public float requiredHoldTime = 1f; // Thời gian cần giữ nút là 10 giây
    public GameObject panel;
    public Image screen2;

    public void OnPointerDown(PointerEventData eventData)
    {
        // Bắt đầu giữ button
        isHoldingButton = true;
        holdTime = 0f;
        StartCoroutine(CountHoldTime());
        screen2.gameObject.SetActive(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Dừng giữ button
        isHoldingButton = false;
        screen2.gameObject.SetActive(false);
    }

    IEnumerator CountHoldTime()
    {
        Handheld.Vibrate();
        // Đếm thời gian giữ button
        while (isHoldingButton && holdTime < requiredHoldTime)
        {
            holdTime += Time.deltaTime;
            if (holdTime >= requiredHoldTime)
            {
                // Gọi hàm xử lý sau 10 giây giữ
                HandleLongPress();
            }
            yield return null;
        }


    }

    void HandleLongPress()
    {
        // Hàm xử lý sau khi giữ nút 10 giây
        // Gọi hàm RandomResult để xử lý kết quả ngẫu nhiên
        ActiveMessageOnePlayerPanel();
    }

    void ActiveMessageOnePlayerPanel()
    {
        panel.SetActive(true);
    }
}
