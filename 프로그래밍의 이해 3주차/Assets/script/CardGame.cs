using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class CardGame : MonoBehaviour
{
    public List<Card> cards;
    private Card firstCard = null;
    private Card secondCard = null;

    void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        List<int> randomPairNumbers = GeneratePairNumbers(cards.Count);

        for (int i = 0; i < cards.Count; ++i)
        {
            cards[i].SetCardNumber(randomPairNumbers[i]);
            cards[i].isFront = false;
        }
    }


    private void CheckCard()
    {
        if (firstCard.cardNumber == secondCard.cardNumber)
        {
            firstCard.isMatched = true;
            secondCard.isMatched = true;

            firstCard.ChangeColor(Color.magenta);
            secondCard.ChangeColor(Color.magenta);

            firstCard = null;
            secondCard = null;
        }
        else
        {
            Invoke("HideCard", 1.0f);
        }
    }

    private void HideCard()
    {
        firstCard.isFront = false;
        secondCard.isFront = false;

        firstCard = null;
        secondCard = null;
    }

    public void OnClickCard(Card card)
    {
        if (firstCard == null)
        {
            firstCard = card;
        }
        else
        {
            secondCard = card;
        }

        if (firstCard != null && secondCard != null)
        {
            CheckCard();
        }

    }


    List<int> GeneratePairNumbers(int cardCount)
    {
        int pairCount = cardCount / 2;
        List<int> newCardNumbers = new List<int>();

        for (int i = 0; i < pairCount; ++i)
        {
            newCardNumbers.Add(i);
            newCardNumbers.Add(i);
        }

        for (int i = newCardNumbers.Count - 1; i > 0; i--)
        {
            int rnd = Random.Range(0, i + 1);
            int temp = newCardNumbers[i];
            newCardNumbers[i] = newCardNumbers[rnd];
            newCardNumbers[rnd] = temp;
        }

        return newCardNumbers;
    }

}
