using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGame : MonoBehaviour
{
    [Header("프리팹 설정")]
    public GameObject cardPrefab;
    public Transform cardParent;
    
    [Header("카드 설정")]
    public int pairCount = 10;
    private int totalCardCount;

    [Header("데이터 설정")]
    public List<Sprite> cardSprites;
    private List<Card> allCards = new List<Card>();

    [Header("게임 로직 관련")]
    private Card firstCard = null;
    private Card secondCard = null;
    private bool isChecking = false;
    private int matchedCount = 0;

    void Start()
    {
        totalCardCount = pairCount * 2;
        GenerateCards();
    }

    private void GenerateCards()
    {
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
            int spriteIndex = cardNumber % cardSprites.Count;
            Sprite selectedSprite = cardSprites[spriteIndex];

            Random.InitState(cardNumber); 
            Color pairColor = Color.HSVToRGB(Random.value, 0.4f, 0.9f); 
            pairColor.a = 1f; 

            card.Setup(cardNumber, selectedSprite, pairColor, this);
            allCards.Add(card);
        }

        Random.InitState((int)System.DateTime.Now.Ticks);
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

            if (matchedCount == pairCount) Debug.Log("모든 카드를 맞췄습니다!");
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
}