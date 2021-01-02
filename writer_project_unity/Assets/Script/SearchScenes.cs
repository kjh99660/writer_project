﻿using System;
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
    private GameObject Camera;
    private List<Dictionary<string, object>> chapter3;
    private List<Dictionary<string, object>> chapter2;
    private List<Dictionary<string, object>> chapter1;

    private int[] chapter3Check = new int[2] { 0, 0 };
    private int[] chapter1Check = new int[3] { 0, 0, 0 };
    private bool ChapterOneHalf = false;
    private bool ChapterTwoHalf = false;

    private Button WatchButton;
    private Button BlanketButton;

    private Button LakeButton;
    private Button LandButton;
    private Button WillowButton;
    private Button BranchButton;

    private Button FrameButton;
    private Button FirePlaceButton;
    private Button CupButton;
    private Button CoatButton;

    private GameObject Chapter1Object;
    private GameObject Chapter2Object;
    private GameObject Chapter3Object;

    private readonly WaitForSeconds NextLetter = new WaitForSeconds(0.04f);
    //모든 물건에 bool 변수를 넣어야함 -> 17,18 line
    void Start()
    {
        Camera = GameObject.Find("Main Camera");
        chapter3 = CSVfileReader.Read("search_3");
        chapter2 = CSVfileReader.Read("search_2");
        chapter1 = CSVfileReader.Read("search_1");

        Chapter1Object = GameObject.Find("Chapter1Object");
        Chapter2Object = GameObject.Find("Chapter2Object");
        Chapter3Object = GameObject.Find("Chapter3Object");

        WatchButton = Chapter3Object.transform.GetChild(1).GetComponent<Button>();
        BlanketButton = Chapter3Object.transform.GetChild(0).GetComponent<Button>();

        FirePlaceButton = Chapter2Object.transform.GetChild(0).GetComponent<Button>();
        FrameButton = Chapter2Object.transform.GetChild(1).GetComponent<Button>();
        CoatButton = Chapter2Object.transform.GetChild(2).GetComponent<Button>();
        CupButton = Chapter2Object.transform.GetChild(3).GetComponent<Button>();

        LakeButton = Chapter1Object.transform.GetChild(0).GetComponent<Button>();
        WillowButton = Chapter1Object.transform.GetChild(1).GetComponent<Button>();
        LandButton = Chapter1Object.transform.GetChild(2).GetComponent<Button>();
        BranchButton = Chapter1Object.transform.GetChild(3).GetComponent<Button>();
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
            yield return null;//NextLetter
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
    IEnumerator Texting(List<Dictionary<string, object>> TextFile, int LineNumber, int LoopTime)
    {
        NameS2.gameObject.SetActive(true);
        TextS2.gameObject.SetActive(true);
        Line = LineNumber;
        for (int i = 0; i < LoopTime; i++)
        {
            yield return StartCoroutine(Chatting(TextS2, TextFile[Line]["search1"].ToString(), TextFile[Line]["search2"].ToString()));
            yield return StartCoroutine(Next());
        }
        NameS2.gameObject.SetActive(false);
        TextS2.gameObject.SetActive(false);

    }

    //챕터 1 조사 내용
    IEnumerator Willow()//버드나무
    {
        LakeButton.interactable = false;
        LandButton.interactable = false;
        yield return StartCoroutine(Texting(chapter1, 0, 1));
        LakeButton.interactable = true;
        LandButton.interactable = true;
        chapter1Check[0] = 1;
    }
    IEnumerator Lake()
    {
        WillowButton.interactable = false;
        LandButton.interactable = false;
        yield return StartCoroutine(Texting(chapter1, 2, 1));
        WillowButton.interactable = true;
        LandButton.interactable = true;
        chapter1Check[1] = 1;
    }
    IEnumerator Land()
    {
        LakeButton.interactable = false;
        WillowButton.interactable = false;
        yield return StartCoroutine(Texting(chapter1, 3, 1));
        LakeButton.interactable = true;
        WillowButton.interactable = true;
        chapter1Check[2] = 1;
    }
    
    //챕터 1 두번째 조사 내용
    IEnumerator Branch()
    {
        yield return StartCoroutine(Texting(chapter1, 5, 1));
        Camera.transform.position = new Vector3(0, 0, -10);
    }
    IEnumerator NotUse()
    {
        yield return StartCoroutine(Texting(chapter1, 6, 1));
    }
    //챕터 2 조사 내용
    IEnumerator Coat()
    {
        yield return StartCoroutine(Texting(chapter2, 3, 1));
        Camera.transform.position = new Vector3(0, 0, -10);
    }
    IEnumerator Cup()
    {
        yield return StartCoroutine(Texting(chapter2, 2, 1));
    }
    IEnumerator Frame()
    {
        yield return StartCoroutine(Texting(chapter2, 1, 1));
    }
    IEnumerator FirePlace()
    {
        yield return StartCoroutine(Texting(chapter2, 0, 1));
    }
    IEnumerator Noting()
    {
        yield return StartCoroutine(Texting(chapter2, 4, 1));
    }
    IEnumerator GasRange()
    {
        yield return StartCoroutine(Texting(chapter2, 5, 1));
    }
    IEnumerator Sink()
    {
        yield return StartCoroutine(Texting(chapter2, 6, 1));
    }
    //챕터 3 조사 내용
    IEnumerator Watch()
    {
        BlanketButton.interactable = false;
        yield return StartCoroutine(Texting(chapter3, 3, 6));
        BlanketButton.interactable = true;
        chapter3Check[0] = 1;
    }
    IEnumerator Blanket()
    {
        WatchButton.interactable = false;
        yield return StartCoroutine(Texting(chapter3, 0, 2));
        WatchButton.interactable = true;
        chapter3Check[1] = 1;
    }
    //조사 변경 함수
    public void ChapterOneEnter()
    {
        //첫 배경 활성화
        LakeButton.gameObject.SetActive(true);
        WillowButton.gameObject.SetActive(true);
        LandButton.gameObject.SetActive(true);
    }
    public void ChangeOne_2Search()//나뭇가지를 눌러야 넘어가는 씬
    {
        //나뭇가지 및 배경 활성화
        BranchButton.gameObject.SetActive(true);
    }
    public void ChapterTwoEnter()
    {
        LakeButton.gameObject.SetActive(false);
        WillowButton.gameObject.SetActive(false);
        LandButton.gameObject.SetActive(false);
        BranchButton.gameObject.SetActive(false);
        //배경 활성화
        CoatButton.gameObject.SetActive(true);
        FrameButton.gameObject.SetActive(true);
        CupButton.gameObject.SetActive(true);
        FirePlaceButton.gameObject.SetActive(true);
    }
    public void ChapterTwoHalfEnter()
    {
        ChapterTwoHalf = true;
        //좌우 이동 가능한 배경 , 아이 코트 사라짐
        //새로운 오브젝트 추가
    }
    public void ChapterThreeEnter()
    {
        BranchButton.gameObject.SetActive(true);
        WatchButton.gameObject.SetActive(true);
        BlanketButton.gameObject.SetActive(true);
    }
    //물건 코루틴
    //챕터 1
    public void ClickWillow()
    {
        if (ChapterOneHalf)
        {
            StartCoroutine(NotUse());
        }
        else StartCoroutine(Willow());
    }
    public void ClickLake()
    {
        if (ChapterOneHalf)
        {
            StartCoroutine(NotUse());
        }
        else StartCoroutine(Lake());
    }
    public void ClickLand()
    {
        if (ChapterOneHalf)
        {
            StartCoroutine(NotUse());
        }
        else StartCoroutine(Land());
    }
    public void ClickBranch() => StartCoroutine(Branch());

    //챕터 2
    public void ClickCoat()
    {
        if(ChapterTwoHalf)
        {
            StartCoroutine(Noting());
        }
        else StartCoroutine(Coat());
    }
    public void ClickCup()
    {
        if (ChapterTwoHalf)
        {
            StartCoroutine(Noting());
        }
        else StartCoroutine(Cup());
    }
    public void ClickFirePlace()
    {
        if (ChapterTwoHalf)
        {
            StartCoroutine(Noting());
        }
        else StartCoroutine(FirePlace());
    }
    public void ClickFrame()
    {
        if (ChapterTwoHalf)
        {
            StartCoroutine(Noting());
        }
        else StartCoroutine(Frame());
    }
    //[별장 주방] - 왼쪽
    //public void GasRange() => StartCoroutine(GasRange());

    //챕터 3
    public void ClickBlanket() => StartCoroutine(Blanket());
    public void ClickWatch() => StartCoroutine(Watch());

    //챕터 클리어 
    public void ChapterOneSearchClear()
    {
        for (int i = 0; i < chapter1Check.Length; i++)//1chapter search clear
        {
            if (chapter1Check[i] == 0) return ;
        }
        foreach (int check in chapter1Check) chapter1Check[check] = 0;
        Camera.transform.position = new Vector3(0, 0, -10);
        ChapterOneHalf = true;
        return ;
    }

    void Update()
    {
        for (int i = 0; i < chapter3Check.Length; i++)//3chapter search clear
        {
            if (chapter3Check[i] == 0) break;
            if (i == chapter3Check.Length - 1)
            {
                //다음으로 넘어가는 대사 출력
            }
        }
        ChapterOneSearchClear();
    }
}
