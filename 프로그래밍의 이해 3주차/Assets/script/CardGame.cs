using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGame : MonoBehaviour
{
    public int totalCardCount = 20; 

    public GameObject cardPrefab;
    public Transform cardParent; 
    public List<Sprite> cardSprites;

    private List<Card> allCards = new List<Card>();

    private Card firstCard = null;
    private Card secondCard = null;

    private bool isChecking = false;
    private int matchedCount = 0;

    void Start()
    {
        GenerateCards();
    }

    private void GenerateCards()
    {
        int pairCount = totalCardCount / 2;
        List<int> cardIndices = new List<int>();

        for (int i = 0; i < pairCount; i++)
        {
            cardIndices.Add(i);
            cardIndices.Add(i);
        }

        for (int i = 0; i < cardIndices.Count; i++)
        {
            int rnd = Random.Range(0, cardIndices.Count);
            int temp = cardIndices[i];
            cardIndices[i] = cardIndices[rnd];
            cardIndices[rnd] = temp;
        }

        for (int i = 0; i < totalCardCount; i++)
        {
            GameObject go = Instantiate(cardPrefab, cardParent);
            Card card = go.GetComponent<Card>();
            
            int cardNumber = cardIndices[i];
            card.Setup(cardNumber, cardSprites[cardNumber], this);
            allCards.Add(card);
        }

        StartCoroutine(RevealAllRoutine());
    }

    IEnumerator RevealAllRoutine()
    {
        isChecking = true;
        yield return new WaitForSeconds(0.5f);
        foreach (var c in allCards) c.Flip(true);
        yield return new WaitForSeconds(2.0f);
        foreach (var c in allCards) c.Flip(false);
        isChecking = false;
    }

    public void OnClickCard(Card card)
    {
        if (isChecking || card == firstCard || card.isMatched || card.isFront) return;

        card.Flip(true);

        if (firstCard == null)
        {
            firstCard = card;
        }
        else
        {
            secondCard = card;
            StartCoroutine(CheckMatchRoutine());
        }
    }

    IEnumerator CheckMatchRoutine()
    {
        isChecking = true;

        if (firstCard.cardNum == secondCard.cardNum)
        {
            matchedCount++;
            firstCard.SetMatched();
            secondCard.SetMatched();

            if (matchedCount == totalCardCount / 2) Debug.Log("Clear!");
        }
        else
        {
            yield return new WaitForSeconds(1.0f);
            firstCard.Flip(false);
            secondCard.Flip(false);
        }

        firstCard = null;
        secondCard = null;
        isChecking = false;
    }

    public bool IsChecking() => isChecking;
}