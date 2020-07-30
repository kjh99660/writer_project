using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchScenes : MonoBehaviour
{
    // Start is called before the first frame update
    public Text NameS2;
    public Text TextS2;
    private bool Click = true;
    private int Line = -1;
    private List<Dictionary<string, object>> chapter;

    public void Click_Text()
    {
        Click = false;
    }
    IEnumerator Chatting(Text text, string narrator, string narration)//채팅 진행 코루틴 , 한 프레임마다 한 글자씩 생성
    {
        NameS2.text = narrator;
        string writertext = "";
        for (int i = 0; i < narration.Length; i++)
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
    IEnumerator Watch()
    {
        NameS2.gameObject.SetActive(true);
        TextS2.gameObject.SetActive(true);
        Line = 3;
        yield return StartCoroutine(Chatting(TextS2, chapter[Line]["search1"].ToString(), chapter[Line]["search2"].ToString()));
        for (int i = 0; i < 6; i++)
        {
            yield return StartCoroutine(Next());
            yield return StartCoroutine(Chatting(TextS2, chapter[Line]["search1"].ToString(), chapter[Line]["search2"].ToString()));
        }
        yield return StartCoroutine(Next());
        NameS2.gameObject.SetActive(false);
        TextS2.gameObject.SetActive(false);
        //글씨 지우는 작업 추가 필요
    }
    IEnumerator Blanket()
    {
        NameS2.gameObject.SetActive(true);
        TextS2.gameObject.SetActive(true);
        Line = 0;
        yield return StartCoroutine(Chatting(TextS2, chapter[Line]["search1"].ToString(), chapter[Line]["search2"].ToString()));
        for (int i = 0; i < 2; i++)
        {
            yield return StartCoroutine(Next());
            yield return StartCoroutine(Chatting(TextS2, chapter[Line]["search1"].ToString(), chapter[Line]["search2"].ToString()));
        }
        yield return StartCoroutine(Next());
        NameS2.gameObject.SetActive(false);
        TextS2.gameObject.SetActive(false);
        //글씨 지우는 작업 추가 필요
    }
    
    public void ClickBlanket()
    {
        StartCoroutine(Blanket());
    }
    public void ClickWatch()
    {
        StartCoroutine(Watch());
    }

    void Start()
    {
        chapter = CSVfileReader.Read("search_1");
    }
    void Update()
    {
        
    }
}
