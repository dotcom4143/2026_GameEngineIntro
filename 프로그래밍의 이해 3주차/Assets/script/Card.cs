using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int cardNum;

    public bool isMatched = false;
    public bool isFront = false;

    private CardGame cardGame;
    private CardFlip flipper;

    public TextMeshProUGUI numberText;
    public Image frontImage;

    void Awake()
    {
        flipper = GetComponent<CardFlip>();
        if (numberText == null) numberText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Setup(int num, Sprite sprite, CardGame game)
    {
        cardNum = num;
        cardGame = game;
        
        if (numberText != null) numberText.text = cardNum.ToString();
        if (frontImage != null) frontImage.sprite = sprite;
    }

    public void ClickCard()
    {
        if (isMatched || isFront || cardGame.IsChecking()) return;
        
        cardGame.OnClickCard(this);
    }

    public void Flip(bool toFront)
    {
        isFront = toFront;
        flipper.Flip(toFront);
    }

    public void SetMatched()
    {
        isMatched = true;
        if (frontImage != null) frontImage.color = Color.yellow;
    }
}