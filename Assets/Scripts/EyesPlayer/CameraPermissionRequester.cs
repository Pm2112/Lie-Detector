using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckCameraPermission : MonoBehaviour
{
    public RawImage camerra;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Gọi hàm này để kiểm tra và yêu cầu quyền camera cho chụp ảnh
    public void CheckAndRequestCameraPermissionForPictures()
    {
        StartCoroutine(CheckAndRequestCameraPermissionCoroutine(true));
    }

    // Gọi hàm này để kiểm tra và yêu cầu quyền camera cho quay video
    public void CheckAndRequestCameraPermissionForVideos()
    {
        StartCoroutine(CheckAndRequestCameraPermissionCoroutine(false));
    }

    private IEnumerator CheckAndRequestCameraPermissionCoroutine(bool isPicturePermission)
    {
        // Kiểm tra quyền camera hiện tại cho chụp ảnh hoặc quay video
        NativeCamera.Permission permission = NativeCamera.CheckPermission(isPicturePermission);

        if (permission == NativeCamera.Permission.ShouldAsk || permission == NativeCamera.Permission.Denied)
        {
            // Nếu cần phải hỏi, yêu cầu quyền camera
            permission = NativeCamera.RequestPermission(isPicturePermission);

            // Đợi người dùng phản hồi
            while (permission == NativeCamera.Permission.ShouldAsk)
            {
                yield return new WaitForSeconds(0.1f);
                permission = NativeCamera.CheckPermission(isPicturePermission);
            }
        }

        // Kiểm tra kết quả sau khi yêu cầu quyền
        if (permission == NativeCamera.Permission.Granted)
        {
            Debug.Log("Quyền camera đã được cấp.");
            // Quyền đã được cấp, tiếp tục thực hiện công việc với camera
            camerra.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("Quyền camera bị từ chối hoặc không thể yêu cầu quyền.");
            // Quyền bị từ chối, xử lý tình huống này
            camerra.gameObject.SetActive(false);
        }
    }
}
