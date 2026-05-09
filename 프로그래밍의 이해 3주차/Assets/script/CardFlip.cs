using UnityEngine;

public class CardFlip : MonoBehaviour
{
    [Header("연결 설정")]
    public Transform cardVisual; 
    public GameObject frontContent; 
    public GameObject backContent;  

    [Header("회전 설정")]
    public float rotateSpeed = 10f;
    public bool isFront = false;

    void Update()
    {
        if (cardVisual == null) return;

        Quaternion targetRotation = isFront ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);
        cardVisual.rotation = Quaternion.Slerp(cardVisual.rotation, targetRotation, Time.deltaTime * rotateSpeed);

        float yAngle = cardVisual.rotation.eulerAngles.y;
        if (yAngle > 180) yAngle -= 360;
        bool showFront = Mathf.Abs(yAngle) > 90f; 

        if (frontContent != null) frontContent.SetActive(showFront);
        if (backContent != null) backContent.SetActive(!showFront);
    }

    public void ClickCard() { isFront = !isFront; }
    public void Flip(bool toFront) { isFront = toFront; }
}