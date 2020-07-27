using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Search : MonoBehaviour
{
    // Start is called before the first frame update
    public Text NameS2;
    public Text TextS2;
    private bool Click = true;
    private bool NextChapter = false;
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
            if (Input.GetKey(KeyCode.Escape)) NextChapter = true;//챕터 넘기기 용 esc 누르면 다음 챕터 대사로 넘어감
            yield return null;
        }
    }//대기하는 코루틴
    IEnumerator Texting()
    {//대사 출력하는 곳
        for (int i = 0; i < 7; i++)//Prologue
        {
            if (NextChapter == true) break;//챕터 넘기기 용
            yield return StartCoroutine(Next());
            yield return StartCoroutine(Chatting(TextS2, chapter[Line]["c1"].ToString(), chapter[Line]["sc1"].ToString()));
        }

    
    }

    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
