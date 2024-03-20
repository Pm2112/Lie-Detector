using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MoveIconNav : MonoBehaviour
{
    private RectTransform rect;
    public Image textimage;
    private float duration = 0.3f; // Thời gian di chuyển

    void Start()
    {
        rect = gameObject.GetComponent<RectTransform>();
    }

    // Gọi phương thức này khi bạn muốn cập nhật vị trí dựa trên trạng thái của textimage
    void Update()
    {
        if (textimage.gameObject.activeSelf) // Kiểm tra nếu textimage active
        {
            rect.DOAnchorPos(new Vector2(-100, 0), duration);
        }
        else
        {
            rect.DOAnchorPos(new Vector2(0, 0), duration);
        }
    }

    // Nếu có sự kiện hoặc hành động nào đó làm thay đổi trạng thái của textimage, 
    // bạn nên gọi UpdatePosition() từ sự kiện hoặc hành động đó.
}
