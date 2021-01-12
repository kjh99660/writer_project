﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Chat_controller : MonoBehaviour
{
    public Text NameS1;
    public Text TextS1;
    public GameObject Camera;
    public GameObject Manu;
    public GameObject HelpPanel;
    private bool Click = true;
    private bool NextChapter = false;
    private int Line = 0;
    private List<Dictionary<string, object>> chapter;

    private SearchScenes Search;//조사 관련
    private Help HelpUI;//도움말 관련
    private Background Background;//배경 관련
    private EffectManager Effect;//이펙트 관련
    private CharacterKid Kid;//아이 이미지
    private CharacterBoy Boy;//소년 이미지    

    private readonly WaitForSeconds NextLetter = new WaitForSeconds(0.04f);
    void Start()
    {
        chapter = CSVfileReader.Read("scenario");

        HelpUI = GameObject.Find("Helps").GetComponent<Help>();
        Background = GameObject.Find("BackGroundMain").GetComponent<Background>();
        Effect = GameObject.Find("Effect").GetComponent<EffectManager>();
        Kid = GameObject.Find("Standing").transform.GetChild(0).GetComponent<CharacterKid>();
        Boy = GameObject.Find("Standing").transform.GetChild(1).GetComponent<CharacterBoy>();
        Search = GameObject.Find("SearchController").GetComponent<SearchScenes>();

        StartCoroutine(Texting());
    }
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
            if (Input.GetKey(KeyCode.Escape)) NextChapter = true;//챕터 넘기기 용 esc 누르면 다음 챕터 대사로 넘어감
            yield return null;
        }
    }//대기하는 코루틴
    IEnumerator Texting()
    {//대사 출력하는 곳
        for (int i = 0; i< 9;i++)//Prologue
        {
            if (NextChapter == true) break;//챕터 넘기기 용
            Debug.Log(i);
            //기본 이미지 novel로 시작
            if (i == 0)
            {
                Manu.SetActive(false);
                Effect.LightOff();
            }
            if (i == 1) Effect.FadeIn();
            if (i == 4) Effect.LightOff();
            if (i == 5)
            {
                Background.ChangeToLibrary();
                Effect.FadeIn();
            }
            if (i == 6)
            {
                HelpUI.HelpImageOn();
            }
            if (i == 7)
            {
                Manu.SetActive(true);
                Background.ChangeToLibrary();
            }
            yield return StartCoroutine(Chatting(TextS1, chapter[Line]["c1"].ToString(), chapter[Line]["sc1"].ToString()));
            yield return StartCoroutine(Next());

        }

        for (int i = 0; i< 49; i++)//1챕터 + 프롤로그 초반
        {
            if (NextChapter == true) break;
            Debug.Log(i);
            if (i == 0)
            {
                Effect.LightOff();
                Effect.FadeIn();
                Background.ChangeToHallway();
            }
            //if(i == 1) //CG1
            if (i == 2)
            {
                Effect.LightOff();
                Effect.FadeIn();
                Background.ChangeToHallway_anim();
                Background.Rain_ani.SetActive(true);
            }
            if (i == 3)
            {
                Background.Rain_ani.SetActive(false);
                Manu.SetActive(false);
                Effect.FadeOut();
            }
            if (i == 4)//1장 시작
            {
                Manu.SetActive(true);
                Effect.FadeIn();
                Background.ChangeToLivingRoom();
                Kid.ChangeToBasicBasic(Kid.GetSpriteView());
            }
            if(i == 5)
            {
                Kid.ChangeToNoting(Kid.GetSpriteView());
                //CG
            }
            if (i == 15) Kid.ChangeToCrossDownArm(Kid.GetSpriteView());
            if (i == 19) Kid.ChangeToNoting(Kid.GetSpriteView());
            if (i == 20)
            {
                //cg
            }
            if (i == 22)
            {
                Effect.FadeOut();
                Manu.SetActive(false);               
            }
            if (i == 23)
            {
                Manu.SetActive(true);
                Background.ChangeToLake();
                Effect.FadeIn();
            }
            if (i == 24) Kid.ChangeToBasicBasic(Kid.GetSpriteView());
            if (i == 25) Kid.ChangeToNoting(Kid.GetSpriteView());
            if (i == 26)
            {
                Search.ChapterOneEnter();
                Camera.transform.position = new Vector3(25, 0, -10);//호수탐색
            }
            if(i == 30)
            {
                Search.ChangeOne_2Search();//다음 탐색 준비 - 호수 배경 오브젝트와 사람 인영
                //호수 배경에 나뭇가지 오브젝트와 사람 인영 오브젝트 추가
            }
            if(i == 35)
            {
                Camera.transform.position = new Vector3(25, 0, -10);
                //나뭇가지를 탐색하는 내용
                //호수 전경에 나뭇가지를 눌러야 다음으로 넘어가진다.
            }
            if (i == 47) Boy.ChangeToBasicDownArm(Boy.GetSpriteView());
            if (i == 48) Effect.LightOff();

            yield return StartCoroutine(Chatting(TextS1, chapter[Line]["c1"].ToString(), chapter[Line]["sc1"].ToString()));
            yield return StartCoroutine(Next());
        }

        NextChapter = false;//챕터 넘기기 용

        Line = 0;
        chapter = CSVfileReader.Read("scenario_2");
        for (int i = 0; i<91; i++)//2챕터
        {
            if (NextChapter == true) break;
            Debug.Log(i);
            if(i == 0)
            {
                Effect.LightOff();
                if (!Manu.activeSelf) Manu.SetActive(true);
                Background.ChangeToFireplace();//별장 난로앞 – 아이 코트, 머그컵 없음
            }
            if (i == 1) Effect.FadeIn();
            if (i == 2) Boy.ChangeToBasicBasic(Boy.GetSpriteView());
            if (i == 3) Boy.ChangeToNoting(Boy.GetSpriteView());
            if (i == 5) Boy.ChangeToBasicUpArm(Boy.GetSpriteView());
            if (i == 9) Boy.ChangeToHappyBasic(Boy.GetSpriteView());
            if (i == 15) Boy.ChangeToCrossDownArm(Boy.GetSpriteView());
            if (i == 18) Boy.ChangeToBasicUpArm(Boy.GetSpriteView());
            if (i == 19)
            {
                Boy.ChangeToNoting(Boy.GetSpriteView());
                Kid.ChangeToBasicUpArm(Kid.GetSpriteView());
            }
            if(i == 23)
            {
                Kid.ChangeToNoting(Kid.GetSpriteView());
                Boy.ChangeToCrossDownArm(Boy.GetSpriteView());
            }
            if(i == 25)
            {
                Boy.ChangeToNoting(Boy.GetSpriteView());
                Kid.ChangeToBasicDownArm(Kid.GetSpriteView());
            }
            if(i == 27)
            {
                Kid.ChangeToNoting(Kid.GetSpriteView());
                Boy.ChangeToCrossDownArm(Boy.GetSpriteView());
            }
            if(i == 31)
            {
                Boy.ChangeToNoting(Boy.GetSpriteView());
                Kid.ChangeToCrossDownArm(Kid.GetSpriteView());
            }
            if(i == 32)
            {
                Kid.ChangeToNoting(Kid.GetSpriteView());
                Boy.ChangeToCrossDownArm(Boy.GetSpriteView());
            }
            if (i == 33) Boy.ChangeToNoting(Boy.GetSpriteView());
            if (i == 35)
            {
                //[별장 난로 앞 배경 – 머그컵 추가]
            }
            if (i == 36) Boy.ChangeToBasicBasic(Boy.GetSpriteView());            
            if (i == 37) Boy.ChangeToNoting(Boy.GetSpriteView());            
            if (i == 39) Boy.ChangeToHappyBasic(Boy.GetSpriteView());           
            if( i == 40) Boy.ChangeToNoting(Boy.GetSpriteView());            
            if(i == 42)
            {
                Search.ChapterTwoEnter();
                Camera.transform.position = new Vector3(25, 0, -10);//별장 탐색
            }
            if (i == 44) Boy.ChangeToCrossUpArm(Boy.GetSpriteView());
            if (i == 46) Boy.ChangeToBasicUpArm(Boy.GetSpriteView());
            if (i == 47) Boy.ChangeToCrossUpArm(Boy.GetSpriteView());
            if (i == 48) Boy.ChangeToNoting(Boy.GetSpriteView());
            if(i == 50)
            {
                //CG
            }
            if(i == 51) Effect.Flash();
            if(i == 52)
            {
                HelpPanel.SetActive(true);
                //아이 코트 사라짐
            }
            if (i == 54) Boy.ChangeToCrossBasic(Boy.GetSpriteView());
            if (i == 56) Boy.ChangeToBasicBasic(Boy.GetSpriteView());
            if (i == 58)
            {
                Search.ChapterTwoHalfEnter();
                Camera.transform.position = new Vector3(25, 0, -10);//별장 탐색
                Boy.ChangeToNoting(Boy.GetSpriteView());
                Background.ChangeToBedroom();
            }
            if (i == 59) Effect.Flash();
            if (i == 60)
            {
                HelpUI.ChangeText(0);
                HelpUI.ImformationPanelOnOff();
            }
            if (i == 61) HelpUI.ImformationPanelOnOff();
            if (i == 62) Kid.ChangeToBasicUpArm(Kid.GetSpriteView());
            if (i == 63) Kid.ChangeToNoting(Kid.GetSpriteView());
            if (i == 64)//손목 클로즈업 배경
            if (i == 66) Kid.ChangeToCrossDownArm(Kid.GetSpriteView());
            if (i == 68) Kid.ChangeToNoting(Kid.GetSpriteView());
            if (i == 75)
            {
                Search.ChapterTwoLastEnter();
                Camera.transform.position = new Vector3(25, 0, -10);
            }
            if (i == 76) Boy.ChangeToCrossUpArm(Boy.GetSpriteView());
            if (i == 77) Boy.ChangeToBasicUpArm(Boy.GetSpriteView());
            if (i == 79) Boy.ChangeToNoting(Boy.GetSpriteView());
            if (i == 80) Background.ChangeToCabinet();
            if (i == 81) Background.ChangeToCabinetOpen();
            if (i == 84) 
            {
                Effect.LightOff();
                Manu.SetActive(false);
                Background.ChangeToCabinet();
            }
            if (i == 85) Effect.FadeIn();
            if (i == 87) Background.ChangeToCabinetOpen();
            //if (i == 89) [캐비닛 앞, 칼에 이미 피가 묻어있는 장면] -> 작업중(흑백)
            if (i == 89)
            {
                Background.ChangeToBedroom();
                Kid.ChangeToCrossDownArm(Kid.GetSpriteView());
            }
            if (i == 90)
            {
                Kid.ChangeToNoting(Kid.GetSpriteView());
                Effect.FadeOut();
            }
            yield return StartCoroutine(Chatting(TextS1, chapter[Line]["c2"].ToString(), chapter[Line]["sc2"].ToString()));
            yield return StartCoroutine(Next());
        }

        NextChapter = false;

        Line = 0;
        chapter = CSVfileReader.Read("scenario_3");
        for(int i = 0; i<66; i++)//3챕터
        {
            Debug.Log(i);
            if (NextChapter == true) break;
            if(i == 0)
            {
                Effect.LightOff();
                if (!Manu.activeSelf) Manu.SetActive(true);
                Boy.ChangeToNoting(Boy.GetSpriteView());
                Kid.ChangeToNoting(Kid.GetSpriteView());
                Background.ChangeToLivingRoom();
            }
            if (i == 1) Effect.FadeIn();
            if (i == 2) Boy.ChangeToCrossDownArm(Boy.GetSpriteView());
            if (i == 3) Boy.ChangeToNoting(Boy.GetSpriteView());
            //if(i == 5)주방에서 칼을 든 장면
            if(i == 7)
            {
                //살인할 때 칼을 든 장면
                Effect.LightOff();
                Manu.SetActive(false);
            }
            if (i == 8)
            {
                Effect.FadeIn();
                Manu.SetActive(true);//+주방에서 칼을 든 장면
            }
            //if(i == 10)//나의 방으로 바꾸기
            if (i == 13)
            {
                Manu.SetActive(false);
                //CG2
            }
            if (i == 14)
            {
                Background.ChangeToFireplace();
                Manu.SetActive(true);
            }
            if (i == 16)
            {
                Search.ChapterThreeEnter();
                Camera.transform.position = new Vector3(25, 0, -10);
                Background.ChangeToBedroom();
            }
            if (i == 18) Kid.ChangeToBasicDownArm(Kid.GetSpriteView());
            if (i == 22)
            {
                Boy.ChangeToCrossUpArm(Boy.GetSpriteView());
                Kid.ChangeToNoting(Kid.GetSpriteView());
            }
            if (i == 23) Boy.ChangeToNoting(Boy.GetSpriteView());//시스템 관련 내용 추가?
            if(i == 24)
            {
                Background.ChangeToFireplace();
                Boy.ChangeToBasicBasic(Boy.GetSpriteView());
            }
            if(i == 25) Boy.ChangeToNoting(Boy.GetSpriteView());
            if (i == 26) Background.ChangeToLivingRoom();
            //if (i == 29)//금이간 시계 클로즈업
            if (i == 30) Background.ChangeToLivingRoom();
            if (i == 32) Boy.ChangeToCrossUpArm(Boy.GetSpriteView());
            if (i == 34) Boy.ChangeToNoting(Boy.GetSpriteView());
            //if(i == 36)사진 클로즈업
            if(i ==44)
            {
                Effect.FadeOut();
                Effect.FadeIn();
            }
            if (i == 50) Kid.ChangeToHappyBasic(Kid.GetSpriteView());
            if (i == 51) Kid.ChangeToNoting(Kid.GetSpriteView());
            if (i == 52) Boy.ChangeToHappyBasic(Boy.GetSpriteView());
            if (i == 54) Boy.ChangeToNoting(Boy.GetSpriteView());
            //if(i == 55)//책 넘기는 소리
            if (i == 56) Boy.ChangeToCrossUpArm(Boy.GetSpriteView());
            if (i == 60) Boy.ChangeToCrossDownArm(Boy.GetSpriteView());
            if (i == 62) Boy.ChangeToBasicBasic(Boy.GetSpriteView());
            if (i == 64) Boy.ChangeToNoting(Boy.GetSpriteView());

            yield return StartCoroutine(Chatting(TextS1, chapter[Line]["c3"].ToString(), chapter[Line]["sc3"].ToString()));
            yield return StartCoroutine(Next());
        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
