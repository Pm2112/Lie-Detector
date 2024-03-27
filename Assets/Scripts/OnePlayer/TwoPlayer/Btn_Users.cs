using UnityEngine;
using UnityEngine.EventSystems; // Sử dụng để xử lý sự kiện UI
using System.Collections;
using UnityEngine.UI;

public class Btn_User : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static bool isButton1Pressed = false;
    public static bool isButton2Pressed = false;

    private static float buttonPressTime = 0f;
    private static Coroutine pressCoroutine = null;

    public string buttonID; // Thiết lập ID cho mỗi button trong Inspector, ví dụ: "Button1", "Button2"
    public Image errosImage; // Thêm tham chiếu này
    public GameObject messagePanel; // Thêm tham chiếu này


    private void Update()
    {
        if (isButton1Pressed && isButton2Pressed)
        {
            // Nếu cả hai button đều được nhấn, bắt đầu đếm giờ
            if (pressCoroutine == null)
            {
                errosImage.gameObject.SetActive(false); // Ẩn Image
                pressCoroutine = StartCoroutine(CheckBothButtonsPressed());
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (buttonID == "Button1")
        {
            isButton1Pressed = true;
            OnButtonPressed();
        }
        else if (buttonID == "Button2")
        {
            isButton2Pressed = true;
            OnButtonPressed();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (buttonID == "Button1")
        {
            isButton1Pressed = false;
            OnButtonReleased();
        }
        else if (buttonID == "Button2")
        {
            isButton2Pressed = false;
            OnButtonReleased();
        }

        // Khi một trong hai button được thả, hủy đếm giờ và reset
        if (pressCoroutine != null)
        {
            StopCoroutine(pressCoroutine);
            pressCoroutine = null;
            buttonPressTime = 0f;
        }
    }

    IEnumerator CheckBothButtonsPressed()
    {
        while (isButton1Pressed && isButton2Pressed)
        {
            buttonPressTime += Time.deltaTime;
            if (buttonPressTime >= 5f) // 5 giây
            {
                BothButtonsHeld();
                yield break; // Kết thúc coroutine khi đã đạt điều kiện
            }
            yield return null;
        }
    }

    void OnButtonPressed()
    {
        // Hàm xử lý khi một button được nhấn giữ
        errosImage.gameObject.SetActive(true); // Hiển thị Image
    }

    void OnButtonReleased()
    {
        // Hàm xử lý khi thả button
        errosImage.gameObject.SetActive(false); // Ẩn Image
        BothButtonsHeld(); // Gọi hàm này để kiểm tra kết quả test xong xóa
    }

    void BothButtonsHeld()
    {
        // Hàm xử lý khi cả hai button được nhấn giữ trong 5 giây
        messagePanel.SetActive(true); // Bật panel "Result"
    }
}
