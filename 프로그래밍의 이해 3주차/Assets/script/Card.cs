using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public TextMeshProUGUI text;

    public int cardNumber;

    public float rotationSpeed;

    public bool isFront = false;
    public bool isMatched = false;

    private Sprite mySpriteImage;
    public Sprite defaultSprite;

    private Vector3 flipScale = new Vector3(-1, 1, 1);
    private Vector3 originScale = new Vector3(1, 1, 1);

    public CardGame cardGame;

    void Update()
    {
        if (isFront)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, originScale, rotationSpeed * Time.deltaTime);

            if (text != null)
            {
                text.gameObject.SetActive(true);
                text.transform.localScale = new Vector3(1, 1, 1);
            }

            if (mySpriteImage != null) GetComponent<Image>().sprite = mySpriteImage;
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, flipScale, rotationSpeed * Time.deltaTime);

            if (text != null)
            {
                text.gameObject.SetActive(false);
                text.transform.localScale = new Vector3(-1, 1, 1);
            }

            GetComponent<Image>().sprite = defaultSprite;
        }
    }

    public void ClickCard()
    {
        if (!isMatched)
        {
            cardGame.OnClickCard(this);
        }
    }

    public void SetStartRotation()
    {
        transform.localScale = flipScale;
        if (text != null) text.gameObject.SetActive(false);
    }

    public void SetCardNumber(int newNumber)
    {
        text = GetComponentInChildren<TextMeshProUGUI>();

        cardNumber = newNumber;

        text.text = cardNumber.ToString();
    }

    public void ChangeColor(Color newColor)
    {
        GetComponent<Image>().color = newColor;
    }

    public void Flip(bool isFront)
    {
        this.isFront = isFront;
    }

    public void SetImage(Sprite sprite)
    {
        mySpriteImage = sprite;
    }
}