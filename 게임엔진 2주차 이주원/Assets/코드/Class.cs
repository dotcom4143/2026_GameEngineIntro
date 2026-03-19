using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Human man = new Human();
        man.name = "주원";
        man.age = 20;
        man.height = 176.4f;
        man.kg = 76f;
        man.Hp = 100;

        

        Human man2 = new Human();
        man2.name = "대학생";
        man2.age = 20;
        man2.height = 180f;
        man2.kg = 80f;
        man.Hp = 100;

        man.Introduce(); // man2로 바꾸면 답변이 바뀜


        Debug.Log(man2.Hp);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

public class Human
{
    public string name;
    public float height;
    public float kg;
    public int age;
    public int Hp;

    void Walk()
    {
        Debug.Log("걷기");
    }

    void Eat()
    {
        Debug.Log("먹기");
    }
    void Sleep()
    {
        Debug.Log("자기");
    }



    public void Introduce()
    {
        Debug.Log("안녕하세요. 제 이름은 : " + name + "입니다");
    }

}
