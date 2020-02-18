using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chat_controller : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Name;
    public Text Text;
    public GameObject Next_button;
    private bool Click = true; 

    public void Click_Text()
    {
        Click = false;
    }
    IEnumerator Chatting(string narrator, string narration)
    {
        Name.text = narrator;
        string writertext = "";
        for(int i=0; i< narration.Length;i++)
        {
            writertext += narration[i];
            Text.text = writertext;
            yield return null;
        }
    }//한 프레임마다 한 글자씩 생성
    IEnumerator Next()
    {
        Click = true;
        while (Click)
        {
            yield return null;
        }
    }//대기하는 코루틴
    IEnumerator Texting()
    {//대사 출력하는 곳
        yield return StartCoroutine(Next());
        yield return StartCoroutine(Chatting("주인공", "대사 출력 구현하기 연습 중 입니다"));

        yield return StartCoroutine(Next());
        yield return StartCoroutine(Chatting("주인공","안녕하세요?"));

        yield return StartCoroutine(Next());

    }
    void Start()
    {
        StartCoroutine(Texting());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
