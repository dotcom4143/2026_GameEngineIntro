using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Card : MonoBehaviour
{

    public TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

        text.text = Random.Range(0,10).ToString();
    }

    void Update()
    {
        //transform.Rotate(0,2,0);
    }
}
