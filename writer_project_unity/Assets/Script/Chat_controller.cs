using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chat_controller : MonoBehaviour
{
    // Start is called before the first frame update
    public Text NameS1;
    public Text TextS1;
    private bool Click = true; 

    public void Click_Text()
    {
        Click = false;
    }
    IEnumerator Chatting(Text text ,string narrator, string narration)
    {
        NameS1.text = narrator;
        string writertext = "";
        for(int i=0; i< narration.Length;i++)
        {
            writertext += narration[i];
            text.text = writertext;
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
        yield return StartCoroutine(Chatting(TextS1, "주인공", "대사 출력 구현하기 연습 중 입니다"));

        yield return StartCoroutine(Next());
        yield return StartCoroutine(Chatting(TextS1, "주인공", "안녕하세요?"));

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
