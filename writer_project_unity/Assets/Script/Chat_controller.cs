using System;
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
    private bool Click = true;
    private bool NextChapter = false;
    private int Line = -1;
    private List<Dictionary<string, object>> chapter;

    private SearchScenes Search;//조사 관련

    private GameObject GetBackGround;//배경 관련
    private Background Background;

    private GameObject GetEffect;//이펙트 관련
    private EffectManager Effect;

    private GameObject GetKid;//아이 이미지
    private CharacterKid Kid;

    private readonly WaitForSeconds NextLetter = new WaitForSeconds(0.04f);
    void Start()
    {
        chapter = CSVfileReader.Read("scenario");

        GetBackGround = GameObject.Find("BackGroundMain");
        GetEffect = GameObject.Find("Effect");
        GetKid = GameObject.Find("kidStanding");

        Background = GetBackGround.GetComponent<Background>();
        Effect = GetEffect.GetComponent<EffectManager>();
        Kid = GetKid.GetComponent<CharacterKid>();
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
            yield return NextLetter;          
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
            Debug.Log(i);
            //기본 이미지 novel로 시작
            if (i == 0) Effect.LightOff();
            if (i == 1) Manu.SetActive(false);
            if (i == 2) Effect.FadeIn();
            if (i == 5) Effect.LightOff();
            if (i == 6)
            {
                Manu.SetActive(true);
                Background.ChangeToLibrary();
                Effect.FadeIn();
            }
            if (NextChapter == true) break;//챕터 넘기기 용
            yield return StartCoroutine(Next());
            yield return StartCoroutine(Chatting(TextS1, chapter[Line]["c1"].ToString(), chapter[Line]["sc1"].ToString()));
        }

        for (int i = 0; i< 48; i++)//1챕터
        {
            Debug.Log(i);
            if (i == 0)
            {
                Effect.LightOff();
                Effect.FadeIn();
                Background.ChangeToHallway();
            }
            if (i == 1)
            {
                //CG               
            }
            if (i == 2)
            {
                Effect.LightOff();
                Effect.FadeIn();
                Background.ChangeToHallway_anim();
                Background.Rain_ani.SetActive(true);
                Kid.ChangeToBasicBasic();
            }
            if (i == 3)
            {
                Kid.ChangeToNoting();
                Manu.SetActive(false);
                Background.Rain_ani.SetActive(false);
                Effect.FadeOut();
            }
            if (i == 5)
            {
                Manu.SetActive(true);
                Effect.FadeIn();
                Background.ChangeToLivingRoom();
                Kid.ChangeToBasicBasic();
            }
            if(i == 6)
            {
                //CG
            }
            if(i == 16)
            {
                Kid.ChangeToCrossDownArm();
            }
            if(i == 23)
            {
                Effect.FadeOut();
                Manu.SetActive(false);               
            }
            if (i == 24)
            {
                Background.ChangeToLake();
                Effect.FadeIn();
            }
            if(i == 25)
            {
                Kid.ChangeToBasicBasic();
            }
            if (i == 27)
            {
                Search.ChapterOneEnter();
                Camera.transform.position = new Vector3(25, 0, -10);//호수탐색
            }
            if(i == 31)
            {
                Search.ChangeOne_2Search();//다음 탐색 준비 - 호수 배경 오브젝트와 사람 인영
                //호수 배경에 나뭇가지 오브젝트와 사람 인영 오브젝트 추가
            }
            if(i == 36)
            {
                Camera.transform.position = new Vector3(25, 0, -10);
                //나뭇가지를 탐색하는 내용
                //호수 전경에 나뭇가지를 눌러야 다음으로 넘어가진다.
            }
            if (NextChapter == true) break;
            yield return StartCoroutine(Next());
            yield return StartCoroutine(Chatting(TextS1, chapter[Line]["c1"].ToString(), chapter[Line]["sc1"].ToString()));
        }

        NextChapter = false;//챕터 넘기기 용

        Line = -1;
        chapter = CSVfileReader.Read("scenario_2");
        for (int i = 0; i<81; i++)//2챕터
        {
            if (NextChapter == true) break;
            yield return StartCoroutine(Next());
            yield return StartCoroutine(Chatting(TextS1, chapter[Line]["c2"].ToString(), chapter[Line]["sc2"].ToString()));
        }

        NextChapter = false;

        Line = -1;
        chapter = CSVfileReader.Read("scenario_3Before");
        for(int i = 0; i<13; i++)//3챕터 이야기 조사 전
        {
            if (NextChapter == true) break;
            yield return StartCoroutine(Next());
            yield return StartCoroutine(Chatting(TextS1, chapter[Line]["c3"].ToString(), chapter[Line]["sc3"].ToString()));
        }

        // 조사 및 대화 관련 스크립트로 이동
        yield return StartCoroutine(Next());
        Camera.transform.position = new Vector3(25, 0, -10);

        NextChapter = false;

        Line = -1;
        chapter = CSVfileReader.Read("scenario_3After");
        for (int i = 0; i < 43; i++)//3챕터 이야기 조사 후
        {
            if (NextChapter == true) break;
            yield return StartCoroutine(Next());
            yield return StartCoroutine(Chatting(TextS1, chapter[Line]["c3"].ToString(), chapter[Line]["sc3"].ToString()));
        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
