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
    public bool isFront = true;
    public bool isMatched = false;
    private Quaternion flipRotation = Quaternion.Euler(0, 180f, 0);
    private Quaternion originRotation = Quaternion.Euler(0, 0, 0);
    public CardGame cardGame;
    
    void Update()
    {
        if (isFront)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, originRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, flipRotation, rotationSpeed * Time.deltaTime);
        }
    }

    public void ClickCard()
    {
        if (!isMatched)
        {
            cardGame.OnClickCard(this);
            isFront = !isFront;
        }


    }

    public void SetCardNumber(int newNumber)
    {
        text = GetComponentInChildren <TextMeshProUGUI>();

        cardNumber = newNumber;

        text.text = cardNumber.ToString();
    }

    public void ChangeColor(Color newColor)
    {
        GetComponent<Image>().color = newColor;
    }

}
