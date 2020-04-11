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
    IEnumerator Texting()//Prologue
    {//대사 출력하는 곳
        yield return StartCoroutine(Next());
        yield return StartCoroutine(Chatting(TextS1, "", "그녀는 남자의 뒤로 다가가.."));

        yield return StartCoroutine(Next());
        yield return StartCoroutine(Chatting(TextS1, "", "칼을 서서히 들었다..."));

        yield return StartCoroutine(Next());
        yield return StartCoroutine(Chatting(TextS1, "", "똑똑"));

        yield return StartCoroutine(Next());
        yield return StartCoroutine(Chatting(TextS1, "나", "무슨 소리지?"));

        yield return StartCoroutine(Next());
        yield return StartCoroutine(Chatting(TextS1, "", "나는 문을 열었다"));

        yield return StartCoroutine(Next());
        yield return StartCoroutine(Chatting(TextS1, "아이", "저 좀 도와주세요..."));

        yield return StartCoroutine(Next());
        yield return StartCoroutine(Chatting(TextS1, "", "나는 아이에게 따뜻한 우유를 주었다."));

        yield return StartCoroutine(Next());
        yield return StartCoroutine(Chatting(TextS1, "", "내가 아이를 처음 보았을 때 창백한 얼굴과 불완전한 형체를 한 아이의 모습에 놀랐다."));

        yield return StartCoroutine(Next());
        yield return StartCoroutine(Chatting(TextS1, "", "아이는 나의 표정을 보고선 곧이어 다급한 목소리로 자신의 이야기를 쏟아내기 시작했다."));

        yield return StartCoroutine(Next());
        yield return StartCoroutine(Chatting(TextS1, "", ""));

        yield return StartCoroutine(Next());
        yield return StartCoroutine(Chatting(TextS1, "", "나는 아이에게 따뜻한 우유를 주었다."));

        yield return StartCoroutine(Next());
        yield return StartCoroutine(Chatting(TextS1, "", "나는 아이에게 따뜻한 우유를 주었다."));

        yield return StartCoroutine(Next());
        yield return StartCoroutine(Chatting(TextS1, "", "나는 아이에게 따뜻한 우유를 주었다."));
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
