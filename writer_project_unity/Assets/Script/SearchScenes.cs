using System;
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
    private List<Dictionary<string, object>> chapter2;
    private List<Dictionary<string, object>> chapter1;

    private int[] chapter2Check = new int[2] { 0, 0 };
    private int[] chapter1Check = new int[3] { 0, 0, 0 };

    private Button WatchButton;
    private Button BlanketButton;
    private Button LakeButton;
    private Button LandButton;
    private Button WillowButton;

    //모든 물건에 bool 변수를 넣어야함
    void Start()
    {
        chapter2 = CSVfileReader.Read("search_2");
        chapter1 = CSVfileReader.Read("search_1");

        WatchButton = GameObject.Find("Chapter2Object").transform.GetChild(1).GetComponent<Button>();
        BlanketButton = GameObject.Find("Chapter2Object").transform.GetChild(0).GetComponent<Button>();

        LakeButton = GameObject.Find("Chapter1Object").transform.GetChild(0).GetComponent<Button>();
        WillowButton = GameObject.Find("Chapter1Object").transform.GetChild(1).GetComponent<Button>();
        LandButton = GameObject.Find("Chapter1Object").transform.GetChild(2).GetComponent<Button>();
    }
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

    //챕터 1 조사 내용
    IEnumerator Willow()//버드나무
    {
        LakeButton.interactable = false;
        LandButton.interactable = false;
        NameS2.gameObject.SetActive(true);
        TextS2.gameObject.SetActive(true);
        Line = 0;
        yield return StartCoroutine(Chatting(TextS2, chapter1[Line]["search1"].ToString(), chapter1[Line]["search2"].ToString()));
        yield return StartCoroutine(Next());
        yield return StartCoroutine(Chatting(TextS2, chapter1[Line]["search1"].ToString(), chapter1[Line]["search2"].ToString()));
        yield return StartCoroutine(Next());
        NameS2.gameObject.SetActive(false);
        TextS2.gameObject.SetActive(false);
        LakeButton.interactable = true;
        LandButton.interactable = true;
        chapter1Check[0] = 1;
    }
    IEnumerator Lake()
    {
        WillowButton.interactable = false;
        LandButton.interactable = false;
        NameS2.gameObject.SetActive(true);
        TextS2.gameObject.SetActive(true);
        Line = 2;
        yield return StartCoroutine(Chatting(TextS2, chapter1[Line]["search1"].ToString(), chapter1[Line]["search2"].ToString()));
        yield return StartCoroutine(Next());
        NameS2.gameObject.SetActive(false);
        TextS2.gameObject.SetActive(false);
        WillowButton.interactable = true;
        LandButton.interactable = true;
        chapter1Check[1] = 1;
    }
    IEnumerator Land()
    {
        WillowButton.interactable = false;
        LakeButton.interactable = false;
        NameS2.gameObject.SetActive(true);
        TextS2.gameObject.SetActive(true);
        Line = 3;
        yield return StartCoroutine(Chatting(TextS2, chapter1[Line]["search1"].ToString(), chapter1[Line]["search2"].ToString()));
        yield return StartCoroutine(Next());
        yield return StartCoroutine(Chatting(TextS2, chapter1[Line]["search1"].ToString(), chapter1[Line]["search2"].ToString()));
        yield return StartCoroutine(Next());
        NameS2.gameObject.SetActive(false);
        TextS2.gameObject.SetActive(false);
        WillowButton.interactable = true;
        LakeButton.interactable = true;
        chapter1Check[2] = 1;
    }

    //챕터 2 조사 내용
    IEnumerator Watch()
    {
        BlanketButton.interactable = false;
        NameS2.gameObject.SetActive(true);
        TextS2.gameObject.SetActive(true);
        Line = 3;
        yield return StartCoroutine(Chatting(TextS2, chapter2[Line]["search1"].ToString(), chapter2[Line]["search2"].ToString()));
        for (int i = 0; i < 6; i++)
        {
            yield return StartCoroutine(Next());
            yield return StartCoroutine(Chatting(TextS2, chapter2[Line]["search1"].ToString(), chapter2[Line]["search2"].ToString()));
        }
        yield return StartCoroutine(Next());
        NameS2.gameObject.SetActive(false);
        TextS2.gameObject.SetActive(false);
        BlanketButton.interactable = true;
        chapter2Check[0] = 1;
    }
    IEnumerator Blanket()
    {
        WatchButton.interactable = false;
        NameS2.gameObject.SetActive(true);
        TextS2.gameObject.SetActive(true);
        Line = 0;
        yield return StartCoroutine(Chatting(TextS2, chapter2[Line]["search1"].ToString(), chapter2[Line]["search2"].ToString()));
        for (int i = 0; i < 2; i++)
        {
            yield return StartCoroutine(Next());
            yield return StartCoroutine(Chatting(TextS2, chapter2[Line]["search1"].ToString(), chapter2[Line]["search2"].ToString()));
        }
        yield return StartCoroutine(Next());
        NameS2.gameObject.SetActive(false);
        TextS2.gameObject.SetActive(false);
        WatchButton.interactable = true;
        chapter2Check[1] = 1;
    }
    public void ChapterOneEnter()
    {
        LakeButton.gameObject.SetActive(true);
        WillowButton.gameObject.SetActive(true);
        LandButton.gameObject.SetActive(true);
    }
    public void ChapterTwoEnter()
    {
        WatchButton.gameObject.SetActive(true);
        BlanketButton.gameObject.SetActive(true);
    }
    public void ChapterOneOut()
    {

        LakeButton.gameObject.SetActive(false);
        WillowButton.gameObject.SetActive(false);
        LandButton.gameObject.SetActive(false);
    }
    public void ChapterTwoOut()
    {
        WatchButton.gameObject.SetActive(false);
        BlanketButton.gameObject.SetActive(false);
    }
    public void ClickBlanket()
    {
        StartCoroutine(Blanket());
    }
    public void ClickWatch()
    {
        StartCoroutine(Watch());
    }
    public void ClickWillow()
    {
        StartCoroutine(Willow());
    }
    public void ClickLake()
    {
        StartCoroutine(Lake());
    }
    public void ClickLand()
    {
        StartCoroutine(Land());
    }

    void Update()
    {
        for (int i = 0; i < chapter2Check.Length; i++)//2chapter search clear
        {
            if (chapter2Check[i] == 0) break;
            if (i == chapter2Check.Length - 1)
            {
                //다음으로 넘어가는 대사 출력
            }
        }

        for (int i = 0; i< chapter1Check.Length; i++)//1chapter search clear
        {
            if (chapter1Check[i] == 0) break;
            if(i == chapter1Check.Length -1)
            {
                GameObject.Find("Main Camera").transform.position = new Vector3(0, 0, -10);
            }
        }
    }
}
