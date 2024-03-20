using UnityEngine;
using UnityEngine.UI;

public class CameraToTexture : MonoBehaviour
{
    public RawImage rawImage;

    void Start()
    {
        // Tìm camera trước
        string frontCamName = GetFrontCameraName();
        if (frontCamName == null)
        {
            Debug.LogError("Front camera not found!");
            return;
        }

        // Khởi tạo WebCamTexture với camera trước
        WebCamTexture webCamTexture = new WebCamTexture(frontCamName);

        if (rawImage != null) // Đối với UI
        {
            rawImage.texture = webCamTexture;
            rawImage.material.mainTexture = webCamTexture;
        }

        webCamTexture.Play();
    }

    void OnDestroy()
    {
        // Đảm bảo dừng camera khi đối tượng bị hủy
        if (rawImage.texture is WebCamTexture webCamTexture)
        {
            webCamTexture.Stop();
        }
    }

    // Hàm này trả về tên của camera trước nếu có
    string GetFrontCameraName()
    {
        foreach (var device in WebCamTexture.devices)
        {
            if (device.isFrontFacing)
            {
                return device.name;
            }
        }
        return null; // Trả về null nếu không tìm thấy camera trước
    }
}
