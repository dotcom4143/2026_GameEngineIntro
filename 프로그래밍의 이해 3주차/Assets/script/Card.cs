using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [Header("데이터")]
    public int cardNum;
    public bool isMatched = false;
    public bool isFront = false;

    [Header("연결")]
    public Image frontImage; 
    private CardFlip flipScript;
    private CardGame gameManager;

    private void Awake()
    {
        flipScript = GetComponent<CardFlip>();
    }

    public void Setup(int num, Sprite sprite, Color color, CardGame manager)
    {
        cardNum = num;
        gameManager = manager;
        
        if (frontImage != null)
        {
            frontImage.sprite = sprite;
            frontImage.color = color;
        }

        // 초기 상태 설정
        isMatched = false;
        isFront = false;
    }

    // [에러 해결] 카드 뒤집기 명령을 처리하는 함수
    public void Flip(bool toFront)
    {
        isFront = toFront;
        if (flipScript != null)
        {
            flipScript.Flip(toFront);
        }
    }

    public void SetMatched()
    {
        isMatched = true;
    }

    public void OnCardClick()
    {
        if (gameManager != null)
        {
            gameManager.OnClickCard(this);
        }
    }
}