using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnTwoPlay : MonoBehaviour
{
    private float holdTimeButton1 = 0f;
    private float holdTimeButton2 = 0f;

    private bool isHoldingButton1 = false;
    private bool isHoldingButton2 = false;

    public float requiredHoldTime = 5f;

    private bool isFeatureActivated = false; // Biến kiểm soát mới

    // Phương thức mới để kích hoạt chức năng
    public void ActivateFeature()
    {
        isFeatureActivated = true;
        Debug.Log("Feature activated.");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isFeatureActivated) return; // Kiểm tra chức năng đã được kích hoạt hay chưa

        // Các điều kiện giống như trước đây
        if (eventData.pointerPress.name == "BtnUserOne")
        {
            isHoldingButton1 = true;
            StartCoroutine(CountHoldTimeButton1());
            Debug.Log("Button 1 pressed.");
        }
        else if (eventData.pointerPress.name == "BtnUserTwo")
        {
            isHoldingButton2 = true;
            StartCoroutine(CountHoldTimeButton2());
            Debug.Log("Button 2 pressed.");
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Các điều kiện giống như trước đây
        if (eventData.pointerPress.name == "BtnUserOne")
        {
            isHoldingButton1 = false;
            holdTimeButton1 = 0f;
            Debug.Log("Button 1 released.");
        }
        else if (eventData.pointerPress.name == "BtnUserTwo")
        {
            isHoldingButton2 = false;
            holdTimeButton2 = 0f;
            Debug.Log("Button 2 released.");
        }
    }

    IEnumerator CountHoldTimeButton1()
    {
        // Đếm thời gian giữ button 1
        while (isHoldingButton1)
        {
            holdTimeButton1 += Time.deltaTime;
            CheckHoldConditions();
            yield return null;
        }
    }

    IEnumerator CountHoldTimeButton2()
    {
        // Đếm thời gian giữ button 2
        while (isHoldingButton2)
        {
            holdTimeButton2 += Time.deltaTime;
            CheckHoldConditions();
            yield return null;
        }
    }

    void CheckHoldConditions()
    {
        // Kiểm tra điều kiện nhấn giữ
        if (isHoldingButton1 && isHoldingButton2 && holdTimeButton1 >= requiredHoldTime && holdTimeButton2 >= requiredHoldTime)
        {
            HandleLongPress();
        }
    }

    void HandleLongPress()
    {
        // Hàm xử lý khi cả hai button được giữ đủ thời gian
        Debug.Log("Both buttons held for 5 seconds.");
        // Thực hiện các hành động tiếp theo ở đây

        // Reset thời gian sau khi xử lý
        holdTimeButton1 = 0f;
        holdTimeButton2 = 0f;
        isHoldingButton1 = false;
        isHoldingButton2 = false;
    }
}
