using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EyesPlayerStart : MonoBehaviour
{
    public Button myButton; // Đối tượng Button mà bạn muốn gắn hành động này
    public GameObject messagePanel;

    private void Start()
    {
        // Thêm listener cho button click
        myButton.onClick.AddListener(() => StartCoroutine(OnButtonClickRoutine()));
    }

    private IEnumerator OnButtonClickRoutine()
    {
        // Đợi 5 giây
        yield return new WaitForSeconds(2);

        // Gọi hàm xử lý sau 5 giây
        HandleAfter5Seconds();
    }

    private void HandleAfter5Seconds()
    {
        // Thực hiện hành động sau khi đợi 5 giây
        Debug.Log("5 giây đã trôi qua kể từ khi bạn click button!");
        messagePanel.SetActive(true);
    }
}
