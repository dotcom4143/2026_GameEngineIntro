using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card : MonoBehaviour
{
    public Color myColor;
    public Image cardImage;
    public TextMeshProUGUI numberText;
    public Sprite backSprite;

    private bool isFront = false;
    public bool isMatched = false;
    public float rotateSpeed = 12f;

    private CardGame gameManager;
    private Sprite rewardSprite;
    private Quaternion targetRotation;

    void Awake()
    {
        if (cardImage == null) cardImage = GetComponent<Image>();
        if (numberText == null) numberText = GetComponentInChildren<TextMeshProUGUI>();
        targetRotation = Quaternion.Euler(0, 180, 0);
    }

    public void Setup(Color col, int index, CardGame manager)
    {
        myColor = col;
        gameManager = manager;
        numberText.text = index.ToString();
        numberText.gameObject.SetActive(false);
        cardImage.sprite = backSprite;
        cardImage.color = Color.white;
    }

    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);

        if (Quaternion.Angle(transform.rotation, Quaternion.identity) < 90)
        {
            if (isMatched)
            {
                cardImage.sprite = rewardSprite;
                cardImage.color = Color.white;
            }
            else
            {
                cardImage.sprite = null;
                cardImage.color = myColor;
            }
            numberText.gameObject.SetActive(true);
        }
        else
        {
            cardImage.sprite = backSprite;
            cardImage.color = Color.white;
            numberText.gameObject.SetActive(false);
        }
    }

    public void Flip(bool toFront)
    {
        isFront = toFront;
        targetRotation = isFront ? Quaternion.identity : Quaternion.Euler(0, 180, 0);
    }

    public void SetMatched(Sprite winSprite)
    {
        isMatched = true;
        rewardSprite = winSprite;
    }

    public void ClickCard()
    {
        if (gameManager == null)
        {
            gameManager = Object.FindFirstObjectByType<CardGame>();
        }

        if (gameManager != null)
        {
            gameManager.OnCardClicked(this);
        }
    }
}