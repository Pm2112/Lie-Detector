using UnityEngine;
using UnityEngine.UI; // Để sử dụng UI components như Button
using UnityEngine.Events; // Để sử dụng UnityEvent
using System.Collections;


public class CameraPermissionRequester : MonoBehaviour
{
    public Button requestPermissionButton; // Tham chiếu đến Button từ Inspector

    // Khởi tạo UnityEvent để có thể thêm các response trong Inspector
    public UnityEvent onPermissionGranted;
    public UnityEvent onPermissionDenied;
    public UnityEvent onPermissionDeniedAndDontAskAgain;

    void Start()
    {
        // Gán sự kiện cho button
        if (requestPermissionButton != null)
        {
            requestPermissionButton.onClick.AddListener(RequestCameraPermission);
        }
    }

    public void RequestCameraPermission()
    {
        StartCoroutine(RequestCameraPermissionCoroutine());
    }

    private IEnumerator RequestCameraPermissionCoroutine()
    {
        // Yêu cầu quyền camera
        NativeCamera.Permission permission = NativeCamera.RequestPermission(false);

        while (permission == NativeCamera.Permission.ShouldAsk)
        {
            // Chờ quyền được người dùng phản hồi
            yield return null;
            permission = NativeCamera.CheckPermission(false);
        }

        // Xử lý tùy thuộc vào quyền đã được cấp hay không
        if (permission == NativeCamera.Permission.Granted)
        {
            Debug.Log("Camera permission granted");
            onPermissionGranted?.Invoke();
        }
        else if (permission == NativeCamera.Permission.Denied)
        {
            Debug.Log("Camera permission denied");
            onPermissionDenied?.Invoke();
        }
    }
}
