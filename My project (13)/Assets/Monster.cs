using UnityEngine;

public class Monster : MonoBehaviour
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
            Debug.Log("*");
            i++;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //transform.position += Vector3.right * 0.03f;
        //transform.Translate(Vector3.right * 0.03f);

        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * 0.03f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * 0.03f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * 0.03f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * 0.03f);
        }
    }
}
