using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGame : MonoBehaviour
{
    public int totalCardCount = 20; // 인스펙터에서 설정
    public GameObject cardPrefab;
    public Transform cardParent; // Grid Layout Group이 붙은 오브젝트
    public List<Sprite> rewardSprites;

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
        List<Color> colorPairs = new List<Color>();

        // 1. 랜덤 색상 페어 생성
        for (int i = 0; i < pairCount; i++)
        {
            Color randomColor = Random.ColorHSV(0f, 1f, 0.6f, 0.9f, 0.7f, 1f);
            colorPairs.Add(randomColor);
            colorPairs.Add(randomColor);
        }

        // 2. 리스트 셔플
        for (int i = 0; i < colorPairs.Count; i++)
        {
            int rnd = Random.Range(0, colorPairs.Count);
            Color temp = colorPairs[i];
            colorPairs[i] = colorPairs[rnd];
            colorPairs[rnd] = temp;
        }

        // 3. 프리팹 생성 및 데이터 주입
        for (int i = 0; i < totalCardCount; i++)
        {
            GameObject go = Instantiate(cardPrefab, cardParent);
            Card card = go.GetComponent<Card>();
            card.Setup(colorPairs[i], i, this);
            allCards.Add(card);
        }

        StartCoroutine(RevealAllRoutine());
    }

    IEnumerator RevealAllRoutine()
    {
        isChecking = true;
        yield return new WaitForSeconds(0.5f);
        foreach (var c in allCards) c.Flip(true);
        yield return new WaitForSeconds(2.5f);
        foreach (var c in allCards) c.Flip(false);
        isChecking = false;
    }

    public void OnCardClicked(Card card)
    {
        if (isChecking || card == firstCard || card.isMatched) return;

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

        if (firstCard.myColor == secondCard.myColor)
        {
            matchedCount++;
            Sprite randomWinSprite = rewardSprites[Random.Range(0, rewardSprites.Count)];
            firstCard.SetMatched(randomWinSprite);
            secondCard.SetMatched(randomWinSprite);

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
}