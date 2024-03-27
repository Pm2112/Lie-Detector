using UnityEngine;
using UnityEngine.UI;

public class CameraToTexture : MonoBehaviour
{
    public RawImage rawImage;
    public AspectRatioFitter aspectRatioFitter;

    void Start()
    {
        string frontCamName = GetFrontCameraName();
        if (frontCamName == null)
        {
            Debug.LogError("Front camera not found!");
            return;
        }

        WebCamTexture webCamTexture = new WebCamTexture(frontCamName, 1080, 2408);
        if (rawImage != null)
        {
            rawImage.texture = webCamTexture;
            rawImage.material.mainTexture = webCamTexture;
        }

        webCamTexture.Play();

        // Cập nhật tỷ lệ của AspectRatioFitter dựa trên tỷ lệ khung hình của camera
        aspectRatioFitter.aspectRatio = (float)webCamTexture.width / (float)webCamTexture.height;
    }

    void OnDestroy()
    {
        if (rawImage.texture is WebCamTexture webCamTexture)
        {
            webCamTexture.Stop();
        }
    }

    string GetFrontCameraName()
    {
        foreach (var device in WebCamTexture.devices)
        {
            if (device.isFrontFacing)
            {
                return device.name;
            }
        }
        return null;
    }
}
