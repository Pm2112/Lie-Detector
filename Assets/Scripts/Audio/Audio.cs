using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource audioSource; // Đối tượng AudioSource để kiểm tra
    private float lastVolume; // Lưu trữ giá trị volume trước đó để so sánh

    void Start()
    {
        if (audioSource != null)
        {
            lastVolume = audioSource.volume; // Khởi tạo giá trị volume ban đầu
        }
    }

    void Update()
    {
        if (audioSource != null && audioSource.volume != lastVolume)
        {
            // Volume đã thay đổi
            Debug.Log("Volume changed to: " + audioSource.volume);
            OnVolumeChange(audioSource.volume); // Gọi hàm xử lý sự kiện volume thay đổi

            lastVolume = audioSource.volume; // Cập nhật giá trị volume mới
        }
    }

    // Hàm này sẽ được gọi khi volume thay đổi
    void OnVolumeChange(float newVolume)
    {
        // Thêm mã xử lý tại đây
    }
}
