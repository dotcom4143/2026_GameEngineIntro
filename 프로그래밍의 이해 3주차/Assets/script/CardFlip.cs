using UnityEngine;
using UnityEngine.UI;

public class CardFlip : MonoBehaviour
{
    [Header("회전 설정")]
    public float rotateSpeed = 10f;
    private Quaternion targetRotation;
    private Quaternion flipRotation = Quaternion.Euler(0, 180f, 0);
    private Quaternion originRotation = Quaternion.Euler(0, 0, 0);

    [Header("컴포넌트 연결")]
    public GameObject frontContent;
    public GameObject backContent;

    private void Awake()
    {
        targetRotation = flipRotation;
        transform.rotation = flipRotation;
        UpdateVisibility(180f);
    }

    private void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

        UpdateVisibility(transform.rotation.eulerAngles.y);
    }

    public void Flip(bool toFront)
    {
        targetRotation = toFront ? originRotation : flipRotation;
    }

    private void UpdateVisibility(float yAngle)
    {
        if (yAngle > 180) yAngle -= 360;

        bool showFront = Mathf.Abs(yAngle) < 90f;

        if (frontContent != null) frontContent.SetActive(showFront);
        if (backContent != null) backContent.SetActive(!showFront);
    }
}