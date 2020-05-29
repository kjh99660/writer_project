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
    private int Line = -1;
    //private CSVfileReader CSVfileReader = GameObject.Find("CSVReader").GetComponent<CSVfileReader>();
    private List<Dictionary<string, object>> chapter;
    public void Click_Text()
    {
        Click = false;
    }
    IEnumerator Chatting(Text text ,string narrator, string narration)//채팅 진행 코루틴 , 한 프레임마다 한 글자씩 생성
    {
        NameS1.text = narrator;
        string writertext = "";
        for(int i=0; i< narration.Length;i++)
        {
            writertext += narration[i];
            text.text = writertext;
            yield return null;
        }
    }
    IEnumerator Next()
    {
        Click = true;
        Line++;
        while (Click)
        {
            yield return null;
        }
    }//대기하는 코루틴
    IEnumerator Texting()
    {//대사 출력하는 곳
        for(int i = 0; i< 7;i++)//Prologue
        {
            yield return StartCoroutine(Next());
            yield return StartCoroutine(Chatting(TextS1, chapter[Line]["c1"].ToString(), chapter[Line]["sc1"].ToString()));
        }
        for (int i = 0; i< 39; i++)//1챕터
        {
            yield return StartCoroutine(Next());
            yield return StartCoroutine(Chatting(TextS1, chapter[Line]["c1"].ToString(), chapter[Line]["sc1"].ToString()));
        }
        Line = -1;
        chapter = CSVfileReader.Read("scenario_2");
        for (int i = 0; i<81; i++)//2챕터
        {
            yield return StartCoroutine(Next());
            yield return StartCoroutine(Chatting(TextS1, chapter[Line]["c2"].ToString(), chapter[Line]["sc2"].ToString()));
        }
        Line = -1;
        chapter = CSVfileReader.Read("scenario_3Before");
        for(int i = 0; i<25; i++)//3챕터 이야기 조사 전
        {
            yield return StartCoroutine(Next());
            yield return StartCoroutine(Chatting(TextS1, chapter[Line]["c3"].ToString(), chapter[Line]["sc3"].ToString()));
        }
        // 조사 하는 스토리
        Line = -1;
        chapter = CSVfileReader.Read("scenario_3After");
        for (int i = 0; i < 43; i++)//3챕터 이야기 조사 후
        {
            yield return StartCoroutine(Next());
            yield return StartCoroutine(Chatting(TextS1, chapter[Line]["c3"].ToString(), chapter[Line]["sc3"].ToString()));
        }

    }
    void Start()
    {
        chapter = CSVfileReader.Read("scenario");      
        StartCoroutine(Texting());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
