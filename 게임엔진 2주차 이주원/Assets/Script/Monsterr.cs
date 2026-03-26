using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsterr : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //for (int i = 0; i < 10; i++)
        //{
        //    Debug.Log(i);
        //}

        int i = 0;

        while (i < 10)
        {
            i ++;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * 0.05f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * 0.05f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * 0.05f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * 0.05f;
        }
    }
}
