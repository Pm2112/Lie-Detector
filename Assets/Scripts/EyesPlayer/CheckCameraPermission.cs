using UnityEngine;
using System.Collections;

public class CameraPermissionCheck : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(CheckCameraPermissionCoroutine());
    }

    IEnumerator CheckCameraPermissionCoroutine()
    {
        // Kiểm tra quyền camera
        var permissionCheck = NativeGallery.CheckPermission();

        // Nếu chưa được cấp quyền hoặc cần hỏi, thì yêu cầu quyền
        if (permissionCheck == NativeGallery.Permission.ShouldAsk)
        {
            NativeGallery.RequestPermission();
        }

        // Đợi cho đến khi người dùng phản hồi
        while (NativeGallery.CheckPermission() == NativeGallery.Permission.ShouldAsk)
        {
            yield return new WaitForSeconds(0.1f);
        }

        // Kiểm tra lại sau khi có phản hồi
        permissionCheck = NativeGallery.CheckPermission();

        if (permissionCheck == NativeGallery.Permission.Denied)
        {
            Debug.Log("Camera permission was denied by the user.");
        }
        else if (permissionCheck == NativeGallery.Permission.Granted)
        {
            Debug.Log("Camera permission granted.");
        }
        else
        {
            Debug.Log("Camera permission is not determined.");
        }
    }
}
