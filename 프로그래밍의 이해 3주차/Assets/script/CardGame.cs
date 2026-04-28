using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class CardGame : MonoBehaviour
{
    public List<Card> cards;
    public List<Sprite> sprites;

    private Card firstCard = null;
    private Card secondCard = null;

    private bool isChecking = false;

    public int cardPairNum;
    private int maxPairNum = 14;
    private int minPairNum = 1;

    void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        isChecking = false;
        List<int> randomPairNumbers = GeneratePairNumbers(cards.Count);

        for (int i = 0; i < cards.Count; ++i)
        {
            int num = randomPairNumbers[i];
            cards[i].SetCardNumber(num);

            if (num < sprites.Count)
            {
                cards[i].SetImage(sprites[num]);
            }

            cards[i].isFront = false;
            cards[i].isMatched = false;
            cards[i].ChangeColor(Color.white);
            cards[i].SetStartRotation();
        }
    }

    private void CheckCard()
    {
        if (firstCard.cardNumber == secondCard.cardNumber)
        {
            firstCard.isMatched = true;
            secondCard.isMatched = true;

            firstCard.ChangeColor(Color.black);
            secondCard.ChangeColor(Color.black);

            firstCard = null;
            secondCard = null;
            isChecking = false;
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
        isChecking = false;
    }

    public void OnClickCard(Card card)
    {
        if (isChecking || card.isMatched || card == firstCard) return;

        card.isFront = true;

        if (firstCard == null)
        {
            firstCard = card;
        }
        else
        {
            secondCard = card;
            isChecking = true;
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