using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Chat_controller : MonoBehaviour
{
    public Text NameS1;
    public Text TextS1;
    public GameObject Camera;
    public GameObject Manu;
    public GameObject[] HelpPanel = new GameObject[2];
    private bool Click = true;
    private bool NextChapter = false;
    private int Line = 0;
    private List<Dictionary<string, object>> chapter;

    private SearchScenes Search;//조사 관련
    private Help HelpUI;//도움말 관련
    private ChatUI CenterText;//중앙글자 관련
    private Background Background;//배경 관련
    private EffectManager Effect;//이펙트 관련
    private PopUp PopUp;//팝업관련
    private CharacterKid Kid;//아이 이미지
    private CharacterBoy Boy;//소년 이미지  
    private CharacterOther Character;//다른 등장인물 이미지
    private Ingame_setting IngameSetting;//인게임 UI기능 관련
    private GameData Data;//저장 데이터
    private Audio Audio;//사운드 관련

    private readonly WaitForSeconds NextLetter = new WaitForSeconds(0.04f);
    void Start()
    {
        chapter = CSVfileReader.Read("scenario");

        Audio = GameObject.Find("EffectSound").GetComponent<Audio>();
        CenterText = GameObject.Find("ChatUI").GetComponent<ChatUI>();
        HelpUI = GameObject.Find("Helps").GetComponent<Help>();
        Background = GameObject.Find("BackGroundMain").GetComponent<Background>();
        Effect = GameObject.Find("Effect").GetComponent<EffectManager>();
        Kid = GameObject.Find("Standing").transform.GetChild(0).GetComponent<CharacterKid>();
        Boy = GameObject.Find("Standing").transform.GetChild(1).GetComponent<CharacterBoy>();
        Character = GameObject.Find("Standing").transform.GetChild(2).GetComponent<CharacterOther>();
        Search = GameObject.Find("SearchController").GetComponent<SearchScenes>();
        PopUp = GameObject.Find("PopUp").GetComponent<PopUp>();
        IngameSetting = GameObject.Find("Canvas").transform.Find("Setting").GetComponent<Ingame_setting>();
        Data = GameObject.Find("Data").GetComponent<GameData>();

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
                CenterText.CenterTextChange(1);
                Manu.SetActive(false);
            }
            if (i == 4)
            {
                Effect.LightOff();
                Audio.PlayEffectSound("1");               
            }
            if (i == 5)
            {
                Background.ChangeToLibrary(Background.SpriteView);
                Effect.FadeIn();
            }
            if (i == 6) HelpUI.HelpImageOn();
            if (i == 7)
            {
                Manu.SetActive(true);
                Background.ChangeToLibrary(Background.SpriteView);
                Audio.PlayEffectSound("1");
            }
            yield return StartCoroutine(Chatting(TextS1, chapter[Line]["c1"].ToString(), chapter[Line]["sc1"].ToString()));
            yield return StartCoroutine(Next());
        }

        for (int i = 0; i< 62; i++)//1챕터 + 프롤로그 초반
        {
            if (NextChapter == true) break;
            Debug.Log(i);
            if (i == 0)
            {               
                Effect.LightOff();
                Effect.FadeIn();
                Background.ChangeToHallway(Background.SpriteView);
            }          
            if (i == 1)
            {
                Audio.PlayBackGroundSound("1");
                Effect.LightOff();
                Effect.FadeIn();
                Background.ChangeToHallway_anim(Background.SpriteView);
                Background.Rain_ani.SetActive(true);
            }
            //if (i == 3)  //CG1
            //if (i == 4)  //CG1-(2)
            if (i == 5)
            {
                Audio.StopBackGroundSound();
                Background.Rain_ani.SetActive(false);
                Manu.SetActive(false);
                Effect.FadeOut();
            }
            if(i == 6) CenterText.CenterTextChange(2);
            if (i == 7)//1장 시작
            {
                Audio.PlayBackGroundSound("2");
                CenterText.CenterTextChange(0);
                Manu.SetActive(true);
                Effect.FadeIn();
                Background.ChangeToLivingRoom(Background.SpriteView);             
            }
            if (i == 8) Kid.ChangeToBasicBasic(Kid.GetSpriteView());
            if (i == 9)
            {
                //CG
                Audio.PlayBackGroundSound("1");
                Kid.ChangeToNoting(Kid.GetSpriteView());
            }
            if (i == 11) Audio.StopBackGroundSound();
            //if(i == 20)오르골 클로즈업 22에서 없애기
            if (i == 26) Kid.ChangeToCrossDownArm(Kid.GetSpriteView());
            if (i == 30) Kid.ChangeToNoting(Kid.GetSpriteView());
            if (i == 31)
            {
                //cg
            }
            if(i == 32)
            {
                Effect.FadeOut();
                Manu.SetActive(false);
            }
            if (i == 33)
            {
                Audio.PlayBackGroundSound("3");
                Manu.SetActive(true);
                Background.ChangeToLake(Background.SpriteView);
                Effect.FadeIn();
            }
            if (i == 34) Kid.ChangeToBasicBasic(Kid.GetSpriteView());
            if (i == 35) Kid.ChangeToNoting(Kid.GetSpriteView());
            if (i == 36)
            {
                Search.ChapterOneEnter();
                Camera.transform.position = new Vector3(25, 0, -10);//호수탐색
            }
            if (i == 37)
            {
                Audio.StopBackGroundSound();
                Effect.LightOff();
                Effect.FadeIn();
            }
            if (i == 38) Audio.PlayEffectSound("2");
            if(i == 41)
            {
                Audio.PlayEffectSound("3");
                Effect.LightOff();
                Effect.FadeIn();
            }
            if (i == 42)
            {
                //Audio.PlayBackGroundSound("")급박한 배경음악
                Audio.StopEffactSound();
            }
            if (i == 46)
            {
                Search.ChangeOne_2Search();//다음 탐색 준비 - 호수 배경 오브젝트와 사람 인영
                //호수 배경에 나뭇가지 오브젝트와 사람 인영 오브젝트 추가
            }
            if(i == 47)
            {
                Camera.transform.position = new Vector3(25, 0, -10);
                //나뭇가지를 탐색하는 내용
                //호수 전경에 나뭇가지를 눌러야 다음으로 넘어가진다.
            }
            if(i == 48)
            {
                //급박한 음악 끝
                Effect.LightOff();
                Effect.FadeIn();
            }
            //if (i == 59)CG 
            if (i == 61)
            {
                Manu.SetActive(false);
                Effect.LightOff();
            }

            yield return StartCoroutine(Chatting(TextS1, chapter[Line]["c1"].ToString(), chapter[Line]["sc1"].ToString()));
            yield return StartCoroutine(Next());
        }

        NextChapter = false;//챕터 넘기기 용
        Line = 0;
        chapter = CSVfileReader.Read("scenario_2");

        for (int i = 0; i<107; i++)//2챕터
        {
            if (NextChapter == true) break;
            Debug.Log(i);
            if(i == 0)
            {
                CenterText.CenterTextChange(3);
                if (!Manu.activeSelf) Manu.SetActive(true);
                Background.ChangeToFireplace(Background.SpriteView);//별장 난로앞 – 아이 코트, 머그컵 없음
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
            if(i == 26)
            {
                Boy.ChangeToNoting(Boy.GetSpriteView());
                Kid.ChangeToBasicDownArm(Kid.GetSpriteView());
            }
            if(i == 28)
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
            if (i == 34)
            {
                Boy.ChangeToNoting(Boy.GetSpriteView());
                Effect.FadeOut();
            }
            if (i == 35)
            {                
                Effect.FadeIn();
                //[별장 난로 앞 배경 – 머그컵 추가]
            }
            if (i == 36) Boy.ChangeToBasicBasic(Boy.GetSpriteView());            
            if (i == 38) Boy.ChangeToNoting(Boy.GetSpriteView());
            //if(i == 39) 오르골 팝업 띄우기      
            //if(i == 44)(음악소리)
            //if(i == 47)//팝업 삭제
            if (i == 51) Boy.ChangeToHappyBasic(Boy.GetSpriteView());
            if (i == 52) Boy.ChangeToNoting(Boy.GetSpriteView());       
            if(i == 54)
            {
                Search.ChapterTwoEnter();
                Camera.transform.position = new Vector3(25, 0, -10);//별장 탐색
            }
            if (i == 56) Boy.ChangeToCrossUpArm(Boy.GetSpriteView());
            if (i == 58) Boy.ChangeToBasicUpArm(Boy.GetSpriteView());
            if (i == 59) Boy.ChangeToCrossUpArm(Boy.GetSpriteView());
            if (i == 61) Boy.ChangeToNoting(Boy.GetSpriteView());
            if(i == 62)
            {
                //CG
            }
            if(i == 63) Effect.Flash();
            if(i == 64)
            {
                HelpPanel[0].SetActive(true);
                //아이 코트 사라짐
            }
            if (i == 66) Boy.ChangeToCrossBasic(Boy.GetSpriteView());
            if (i == 68) Boy.ChangeToBasicBasic(Boy.GetSpriteView());
            if (i == 70)
            {
                Search.ChapterTwoHalfEnter();
                Camera.transform.position = new Vector3(25, 0, -10);//별장 탐색
                Boy.ChangeToNoting(Boy.GetSpriteView());
                Background.ChangeToBedroom(Background.SpriteView);
            }
            if (i == 71) Effect.Flash();
            if (i == 72)
            {
                HelpUI.ChangeText(0);
                HelpUI.ImformationPanelOnOff(true);
            }
            if (i == 73) HelpUI.ImformationPanelOnOff(false);
            if (i == 74) Kid.ChangeToBasicUpArm(Kid.GetSpriteView());
            if (i == 75) Kid.ChangeToNoting(Kid.GetSpriteView());
            //if (i == 76)//손목 클로즈업 배경
            if (i == 78) Kid.ChangeToCrossDownArm(Kid.GetSpriteView());
            if (i == 81) Kid.ChangeToNoting(Kid.GetSpriteView());
            if (i == 87)
            {
                Search.ChapterTwoLastEnter();
                Camera.transform.position = new Vector3(25, 0, -10);
            }
            if (i == 88) Boy.ChangeToCrossUpArm(Boy.GetSpriteView());
            if (i == 89) Boy.ChangeToBasicUpArm(Boy.GetSpriteView());
            if (i == 91) Boy.ChangeToNoting(Boy.GetSpriteView());
            if (i == 92) Background.ChangeToCabinet(Background.SpriteView);
            if (i == 93) Background.ChangeToCabinetOpen(Background.SpriteView);
            if (i == 97) 
            {
                Effect.LightOff();
                Manu.SetActive(false);
                Background.ChangeToCabinet(Background.SpriteView);
            }
            if (i == 98) Effect.FadeIn();
            //if(i == 99)//끼익 소리 추가하기
            if (i == 99) Background.ChangeToCabinetOpen(Background.SpriteView);
            //i == 100 + 칼들고 있는 손 추가하기
            if (i == 101) Effect.Blink();
            if (i == 103) Effect.FadeIn();// + 피 떨어지는 소리
            if (i == 104)
            {
                Background.ChangeToBedroom(Background.SpriteView);
                Kid.ChangeToCrossDownArm(Kid.GetSpriteView());
            }
            if (i == 106)
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

        for(int i = 0; i<73; i++)//3챕터
        {
            Debug.Log(i);
            if (NextChapter == true) break;
            if(i == 0)
            {
                Effect.FadeIn();
                CenterText.CenterTextChange(4);
                if (!Manu.activeSelf) Manu.SetActive(true);
                Boy.ChangeToNoting(Boy.GetSpriteView());
                Kid.ChangeToNoting(Kid.GetSpriteView());
                Background.ChangeToLivingRoom(Background.SpriteView);
            }
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
            if (i == 11) Effect.FadeOut();
            if (i == 12)
            {
                //CG3//+사운드 시작
            }
            if (i == 14)
            {
                Effect.LightOff();
                Effect.FadeIn();
                //사운드 끄기
                Background.ChangeToFireplace(Background.SpriteView);
                Manu.SetActive(true);//12라인에 FALSE없으면 삭제
            }
            if (i == 16)
            {
                Search.ChapterThreeEnter();
                Camera.transform.position = new Vector3(25, 0, -10);
                Background.ChangeToBedroom(Background.SpriteView);
            }
            if (i == 18) Kid.ChangeToBasicDownArm(Kid.GetSpriteView());
            if(i == 22)
            {
                Kid.ChangeToNoting(Kid.GetSpriteView());
                Boy.ChangeToCrossUpArm(Boy.GetSpriteView());
            }
            if(i == 23) Boy.ChangeToBasicBasic(Boy.GetSpriteView());
            if (i == 24) Boy.ChangeToNoting(Boy.GetSpriteView());
            if(i == 25)Background.ChangeToLivingRoom(Background.SpriteView);
            //if(i == 27)손수건 팝업 띄우기
            if (i == 32) PopUp.TurnOnOffObject(PopUp.PopUpBackGround, PopUp.Watch, true);//팝업
            if (i == 34) PopUp.TurnOnOffObject(PopUp.PopUpBackGround, PopUp.Watch, false);
            if (i == 36) Boy.ChangeToCrossUpArm(Boy.GetSpriteView());
            if (i == 39) Boy.ChangeToNoting(Boy.GetSpriteView());
            if (i == 40) PopUp.TurnOnOffObject(PopUp.PopUpBackGround, PopUp.Sticker, true);
            if(i == 49)
            {
                PopUp.TurnOnOffObject(PopUp.PopUpBackGround, PopUp.Sticker, false);
                PopUp.TurnOnOffObject(PopUp.PopUpBackGround, PopUp.Sticker, true);//스티커 뒷면으로 교체
                Effect.LightOff();
                Effect.FadeIn();
            }
            if (i == 53) PopUp.TurnOnOffObject(PopUp.PopUpBackGround, PopUp.Sticker, false);
            if (i == 55) Kid.ChangeToHappyBasic(Kid.GetSpriteView());
            if (i == 56) Kid.ChangeToNoting(Kid.GetSpriteView());
            if (i == 57) Boy.ChangeToBasicBasic(Boy.GetSpriteView());
            if (i == 59) Boy.ChangeToNoting(Boy.GetSpriteView());
            if(i == 61)
            {
                //책 펼치는 소리
                IngameSetting.ClearSuspectPart();
                IngameSetting.Case_file();
                IngameSetting.Case_fileSuspect();
            }
            if (i == 62) Boy.ChangeToCrossUpArm(Boy.GetSpriteView());
            if (i == 66) Boy.ChangeToCrossDownArm(Boy.GetSpriteView());
            if (i == 68) Boy.ChangeToBasicBasic(Boy.GetSpriteView());
            if (i == 70) Boy.ChangeToNoting(Boy.GetSpriteView());
            if (i == 72) Effect.FadeOut();

            yield return StartCoroutine(Chatting(TextS1, chapter[Line]["c3"].ToString(), chapter[Line]["sc3"].ToString()));
            yield return StartCoroutine(Next());
        }

        NextChapter = false;
        Line = 0;
        chapter = CSVfileReader.Read("scenario_4");

        for(int i = 0; i < 29; i++)//챕터4
        {
            Debug.Log(i);
            if (NextChapter == true) break;
            if (i == 0)
            {
                CenterText.CenterTextChange(5);
                Background.ChangeToAmberHouse(Background.SpriteView);
            }
            if (i == 1) Effect.FadeIn();
            if (i == 2) Character.ChangeToAmber(Character.GetSpriteView());
            if (i == 3) Character.ChangeToNoting(Character.GetSpriteView());
            if(i == 7)
            {
                Search.ChapterFourEnter();
                HelpPanel[1].SetActive(true);                
            }
            if (i == 8)
            {
                Camera.transform.position = new Vector3(25, 0, -10);
                Character.ChangeToAmber(Character.GetSpriteView());
            }
            if(i == 11)
            {
                Character.ChangeToNoting(Character.GetSpriteView());
                Background.ChangeToStreet(Background.SpriteView);                
            }
            //if(i == 13)아데린 실종 포스터 팝업
            if(i == 15)
            {
                Search.ChapterFourSecondEnter();
                Background.ChangeToFlowerShop(Background.SpriteView);
                Character.ChangeToLilly(Character.GetSpriteView());
                HelpUI.ChangeHelpPanelText(1, 1);
            }
            if (i == 18) Character.ChangeToNoting(Character.GetSpriteView());
            if (i == 19)
            {
                Camera.transform.position = new Vector3(25, 0, -10);
                HelpUI.HelpPanelOnOff(true, 1);
            }
            if (i == 20) Character.ChangeToLilly(Character.GetSpriteView());
            if (i == 26) Character.ChangeToNoting(Character.GetSpriteView());
            if (i == 28) Background.ChangeToLibrary(Background.SpriteView);

            yield return StartCoroutine(Chatting(TextS1, chapter[Line]["c4"].ToString(), chapter[Line]["sc4"].ToString()));
            yield return StartCoroutine(Next());
        }

        NextChapter = false;
        Line = 0;
        chapter = CSVfileReader.Read("scenario_5");

        for(int i = 0; i < 69; i++)//챕터5
        {
            Debug.Log(i);
            if (NextChapter == true) break;
            if(i == 0)
            {
                CenterText.CenterTextChange(6);
                Background.ChangeToAbigailHouse(Background.SpriteView);
            }
            if (i == 2) Character.ChangeToAbigail(Character.GetSpriteView());
            if (i == 5) Character.ChangeToNoting(Character.GetSpriteView());
            if (i == 7) Character.ChangeToAbigail(Character.GetSpriteView());
            if (i == 16) Character.ChangeToOlivia(Character.GetSpriteView());
            if (i == 31) Character.ChangeToNoting(Character.GetSpriteView());
            //if(i == 33) 음악
            //if(i == 35) 흐려지는 효과
            if (i == 36) Background.ChangeToLivingRoom(Background.SpriteView);
            //if(i == 37) Background.ChangeTo 문밖 배경
            //if(i == 38) 이미지 변경
            if (i == 39) Background.ChangeToLivingRoom(Background.SpriteView);
            if (i == 40) Effect.LightOff();//+ 음악 끝
            if (i == 41)
            {
                Effect.FadeIn();
                Background.ChangeToAbigailHouse(Background.SpriteView);
                Character.ChangeToOlivia(Character.GetSpriteView());
            }
            if (i == 46) Character.ChangeToNoting(Character.GetSpriteView());
            if (i == 47) Background.ChangeToStreet(Background.SpriteView);
            if(i == 49) Effect.FadeOut();
            if (i == 52)
            {
                Effect.FadeIn();
                Background.ChangeToBus(Background.SpriteView);
            }
            //if(i == 54) 공사장 간판 팝업
            if (i == 56) Effect.FadeOut();
            if(i == 57)
            {
                Effect.FadeIn();
                Background.ChangeToLivingRoom(Background.SpriteView);
                Boy.ChangeToBasicBasic(Boy.GetSpriteView());
            }
            if (i == 59)
            {
                Background.ChangeToLibrary(Background.SpriteView);
                Boy.ChangeToNoting(Boy.GetSpriteView());
            }
            if (i == 60) Boy.ChangeToBasicBasic(Boy.GetSpriteView());
            if (i == 61) Boy.ChangeToCrossBasic(Boy.GetSpriteView());
            //62 sound
            if (i == 67) Boy.ChangeToCrossDownArm(Boy.GetSpriteView());
            if(i == 68)
            {
                Effect.FadeOut();
                Boy.ChangeToNoting(Boy.GetSpriteView());
            }

            yield return StartCoroutine(Chatting(TextS1, chapter[Line]["c5"].ToString(), chapter[Line]["sc5"].ToString()));
            yield return StartCoroutine(Next());
        }

        NextChapter = false;
        Line = 0;
        chapter = CSVfileReader.Read("scenario_6");
        for (int i = 0; i < 69; i++)//챕터6
        {
            Debug.Log(i);
            if (NextChapter == true) break;
            if (i == 0)
            {
                Character.ChangeToNoting(Character.GetSpriteView());
                CenterText.CenterTextChange(7);
                Background.ChangeToLivingRoom(Background.SpriteView);
            }
            if(i == 3) Kid.ChangeToHappyBasic(Kid.GetSpriteView());
            if(i == 4)
            {
                Kid.ChangeToNoting(Kid.GetSpriteView());
                Boy.ChangeToCrossBasic(Boy.GetSpriteView());
            }
            if (i == 6) Boy.ChangeToNoting(Boy.GetSpriteView());
            if (i == 9) Boy.ChangeToBasicUpArm(Boy.GetSpriteView());
            if (i == 10) Boy.ChangeToNoting(Boy.GetSpriteView());
            if (i == 12) PopUp.Choice(1);

            if (PopUp.GetChoiceAnswer() != 2 && i == 13)//실패
            {
                Data.IsBadEnding = true;
                Line = 20;
                i = 20;
            }
            if (PopUp.GetChoiceAnswer() == 2 && i == 20)//성공
            {
                Line = 23;
                i = 23;
            }
            if (i == 23) Boy.ChangeToCrossUpArm(Boy.GetSpriteView());
            if(i == 26)
            {
                Background.ChangeToUnderConstruction(Background.SpriteView);
                Boy.ChangeToNoting(Boy.GetSpriteView());
            }
            if (i == 30) Boy.ChangeToBasicBasic(Boy.GetSpriteView());
            if (i == 33) Boy.ChangeToNoting(Boy.GetSpriteView());
            if(i == 34)
            {
                Background.ChangeToStreet(Background.SpriteView);
                Boy.ChangeToCrossDownArm(Boy.GetSpriteView());
            }
            if(i == 36) Boy.ChangeToBasicBasic(Boy.GetSpriteView());
            if(i == 38)
            {
                Boy.ChangeToNoting(Boy.GetSpriteView());
                Kid.ChangeToBasicDownArm(Kid.GetSpriteView());
            }
            if(i == 39)
            {
                Kid.ChangeToNoting(Kid.GetSpriteView());
                Boy.ChangeToBasicUpArm(Boy.GetSpriteView());
            }
            if(i == 46)
            {
                Boy.ChangeToNoting(Boy.GetSpriteView());
                Background.ChangeToCakeStore(Background.SpriteView);
            }
            if (i == 48) Boy.ChangeToBasicBasic(Boy.GetSpriteView());
            if(i == 49)
            {
                Boy.ChangeToNoting(Boy.GetSpriteView());
                Kid.ChangeToHappyBasic(Kid.GetSpriteView());
            }
            if(i == 50)
            {
                Kid.ChangeToNoting(Kid.GetSpriteView());
                Boy.ChangeToBasicBasic(Boy.GetSpriteView());
            }
            if(i == 51) Boy.ChangeToNoting(Boy.GetSpriteView());
            if (i == 60) PopUp.Choice(2);
            if (PopUp.GetChoiceAnswer() != 3 && i == 61)//실패
            {
                Data.IsBadEnding = true;
                Line = 63;
                i = 63;
            }
            if(PopUp.GetChoiceAnswer() == 3 && i == 63)//성공
            {
                Line = 67;
                i = 67;
            }
            if(i == 66)
            {
                Background.ChangeToStreet(Background.SpriteView);
                Boy.ChangeToCrossUpArm(Boy.GetSpriteView());
            }
            if (i == 68) Boy.ChangeToNoting(Boy.GetSpriteView());


            yield return StartCoroutine(Chatting(TextS1, chapter[Line]["c6"].ToString(), chapter[Line]["sc6"].ToString()));
            yield return StartCoroutine(Next());
        }

        NextChapter = false;
        Line = 0;
        chapter = CSVfileReader.Read("scenario_7");
        for (int i = 0; i < 80; i++)//챕터7
        {
            Debug.Log(i);
            if (NextChapter == true) break;
            if (i == 0)
            {
                Character.ChangeToNoting(Character.GetSpriteView());
                CenterText.CenterTextChange(8);
                Background.ChangeToKateHouse(Background.SpriteView);
            }
            if(i == 2) Character.ChangeToKate(Character.GetSpriteView());
            if(i == 4)
            {
                Character.ChangeToNoting(Character.GetSpriteView());
                Boy.ChangeToBasicBasic(Boy.GetSpriteView());
            }
            if(i == 5)
            {
                Boy.ChangeToNoting(Boy.GetSpriteView());
                Character.ChangeToKate(Character.GetSpriteView());
            }
            if(i == 6)
            {
                Boy.ChangeToBasicBasic(Boy.GetSpriteView());
                Character.ChangeToNoting(Character.GetSpriteView());
            }
            if(i == 7)
            {
                Character.ChangeToKate(Character.GetSpriteView());
                Boy.ChangeToNoting(Boy.GetSpriteView());
            }
            if(i == 8)
            {
                Character.ChangeToNoting(Character.GetSpriteView());
                Boy.ChangeToBasicUpArm(Boy.GetSpriteView());
            }
            if(i == 9)
            {
                Character.ChangeToKate(Character.GetSpriteView());
                Boy.ChangeToNoting(Boy.GetSpriteView());
            }
            if (i == 16) Character.ChangeToNoting(Character.GetSpriteView());
            if (i == 17) Boy.ChangeToHappyBasic(Boy.GetSpriteView());
            if(i == 18)
            {
                Character.ChangeToKate(Character.GetSpriteView());
                Boy.ChangeToNoting(Boy.GetSpriteView());
            }
            if (i == 19)
            {
                Character.ChangeToNoting(Character.GetSpriteView());
                Boy.ChangeToHappyBasic(Boy.GetSpriteView());
            }
            if (i == 20) Boy.ChangeToNoting(Boy.GetSpriteView());
            if (i == 21) Boy.ChangeToBasicBasic(Boy.GetSpriteView());
            if(i == 29)
            {
                Boy.ChangeToNoting(Boy.GetSpriteView());
                PopUp.Choice(3);
            }
            if (PopUp.GetChoiceAnswer() == 1 && i == 35)//성공
            {
                Line = 45;
                i = 45;
            }
            if (PopUp.GetChoiceAnswer() == 2 && i == 29)//실패 - 2
            {
                Data.IsBadEnding = true;
                Line = 35;
                i = 35;
            }
            if (PopUp.GetChoiceAnswer() == 2 && i == 36)//실패 - 2 - 2
            {
                Line = 39;
                i = 39;
            }
            if (PopUp.GetChoiceAnswer() == 3 && i == 30)//실패 - 3
            {
                Data.IsBadEnding = true;
                Line = 37;
                i = 37;
            }
            if (i == 45) Background.ChangeToLivingRoom(Background.SpriteView);
            if (i == 46) Boy.ChangeToCrossUpArm(Boy.GetSpriteView());
            if (i == 49) Boy.ChangeToNoting(Boy.GetSpriteView());
            if(i == 50)
            {
                Background.ChangeToFlowerShop(Background.SpriteView);
                Effect.LightOff();
                Effect.FadeIn();
            }
            if (i == 65) Background.ChangeToStreet(Background.SpriteView);
            if (i == 66) Boy.ChangeToCrossBasic(Boy.GetSpriteView());
            if (i == 74) Boy.ChangeToBasicBasic(Boy.GetSpriteView());
            if(i == 75)
            {
                Boy.ChangeToNoting(Boy.GetSpriteView());
                Kid.ChangeToCrossBasic(Kid.GetSpriteView());
            }
            if (i == 79)
            {
                Kid.ChangeToNoting(Kid.GetSpriteView());
                Effect.FadeOut();
            }


            yield return StartCoroutine(Chatting(TextS1, chapter[Line]["c7"].ToString(), chapter[Line]["sc7"].ToString()));
            yield return StartCoroutine(Next());
        }

        NextChapter = false;
        Line = 0;
        chapter = CSVfileReader.Read("scenario_8");

        for (int i = 0; i < 26; i++)//챕터8
        {
            Debug.Log(i);
            if (NextChapter == true) break;
            if (i == 0)
            {
                Effect.FadeIn();
                Character.ChangeToNoting(Character.GetSpriteView());
                CenterText.CenterTextChange(9);
                Background.ChangeToBedroom(Background.SpriteView);
            }
            if (i == 4) Boy.ChangeToCrossUpArm(Boy.GetSpriteView());
            if (i == 6) Boy.ChangeToBasicUpArm(Boy.GetSpriteView());
            if (i == 7) Boy.ChangeToNoting(Boy.GetSpriteView());
            if (i == 8) Background.ChangeToVillaStair(Background.SpriteView);
            if (i == 13) Boy.ChangeToCrossBasic(Boy.GetSpriteView());
            if (i == 14) Boy.ChangeToNoting(Boy.GetSpriteView());
            //if(i == 17)계단에 손바닥 자국이 난 장면
            if(i == 19)
            {
                Background.ChangeToVillaOutSide(Background.SpriteView);
                Boy.ChangeToCrossBasic(Boy.GetSpriteView());
            }
            if (i == 21) Boy.ChangeToNoting(Boy.GetSpriteView());
            if (i == 22) Kid.ChangeToBasicUpArm(Kid.GetSpriteView());
            if (i == 23) Kid.ChangeToNoting(Kid.GetSpriteView());
            if (i == 24)
            {
                Effect.Flash();
                // PopUp.TurnOnOffObject(PopUp.PopUpBackGround, PopUp.Handprint, true);//팝업
                HelpUI.ChangeText(5);
                HelpUI.ImformationPanelOnOff(true);
            }
            if (i == 25)
            {
                Effect.FadeOut();
                //PopUp.TurnOnOffObject(PopUp.PopUpBackGround, PopUp.Handprint, false);
                HelpUI.ImformationPanelOnOff(false);
            }

            yield return StartCoroutine(Chatting(TextS1, chapter[Line]["c8"].ToString(), chapter[Line]["sc8"].ToString()));
            yield return StartCoroutine(Next());
        }

        NextChapter = false;
        Line = 0;
        chapter = CSVfileReader.Read("scenario_9");

        for (int i = 0; i < 61; i++)//챕터9
        {
            Debug.Log(i);
            if (NextChapter == true) break;
            if (i == 0)
            {
                Effect.FadeIn();
                CenterText.CenterTextChange(10);
                //배경 [별장에서 칼 들고 있는 장면 재활용 + 진짜 어두운 배경] -> 만들어줘
            }
            if (i == 1)
            {
                //열린 캐비닛 앞 칼 들고 있는 장면 -> 흑백 필터
            }
            if (i == 2) Effect.LightOff();
            if (i == 3) Effect.FadeIn();
            //if(i == 5) 음악 끝

            if (Data.IsBadEnding == true)
            {
                if (i == 7) Background.ChangeToLibrary(Background.SpriteView);
                if (i == 9) Background.ChangeToLivingRoom(Background.SpriteView);
                if (i == 12) Boy.ChangeToCrossBasic(Boy.GetSpriteView());
                if (i == 19) Boy.ChangeToCrossUpArm(Boy.GetSpriteView());
                //if (i == 20)심장 내려앉는 소리
                //i == 22 배경 어둡게
                if(i == 31)
                {
                    Boy.ChangeToNoting(Boy.GetSpriteView());
                    //베드 엔딩
                }
                if (i == 32) SceneManager.LoadScene("Startscene");

            }
            else
            {
                if (i == 7)
                {
                    Line = 33;
                    Background.ChangeToLibrary(Background.SpriteView);
                }                
                if (i == 10) Background.ChangeToLivingRoom(Background.SpriteView);
                if (i == 11) Boy.ChangeToBasicBasic(Boy.GetSpriteView());
                if(i == 14)
                {
                    Boy.ChangeToNoting(Boy.GetSpriteView());
                    Kid.ChangeToBasicBasic(Kid.GetSpriteView());
                }
                if (i == 15) Kid.ChangeToNoting(Kid.GetSpriteView());
                if(i == 16)
                {
                    //(불안한 브금) [캐비닛 앞 노아의 모습 + 피 살짝]
                }
                if (i == 17) Kid.ChangeToBasicBasic(Kid.GetSpriteView());
                if(i == 18)
                {
                    Kid.ChangeToNoting(Kid.GetSpriteView());
                    //접시 깨지는 소리
                }
                if(i == 26) Kid.ChangeToCrossBasic(Kid.GetSpriteView());
                if(i == 27)
                {
                    Kid.ChangeToNoting(Kid.GetSpriteView());
                    Boy.ChangeToCrossBasic(Boy.GetSpriteView());
                }
                if (i == 28) Boy.ChangeToNoting(Boy.GetSpriteView());
                if (i == 29) Kid.ChangeToBasicUpArm(Kid.GetSpriteView());
                if(i == 30)
                {
                    Kid.ChangeToNoting(Kid.GetSpriteView());
                    Boy.ChangeToCrossBasic(Boy.GetSpriteView());
                }
                if (i == 34)
                {
                    Boy.ChangeToNoting(Boy.GetSpriteView());
                    Background.ChangeToLibrary(Background.SpriteView);
                }
                if(i == 38)
                {
                    Search.ChapterNineEnter();
                    Camera.transform.position = new Vector3(25, 0, -10);
                }
                if (i == 39) Boy.ChangeToCrossBasic(Boy.GetSpriteView());
                if (i == 41) Boy.ChangeToNoting(Boy.GetSpriteView());
                if (i == 43) Boy.ChangeToCrossUpArm(Boy.GetSpriteView());
                if (i == 51) Boy.ChangeToCrossDownArm(Boy.GetSpriteView());
                if(i == 52)
                {
                    Boy.ChangeToNoting(Boy.GetSpriteView());
                    Kid.ChangeToCrossDownArm(Kid.GetSpriteView());
                }
                if(i == 54)
                {
                    Kid.ChangeToNoting(Kid.GetSpriteView());
                    Boy.ChangeToCrossBasic(Boy.GetSpriteView());
                }
                if (i == 56) Boy.ChangeToNoting(Boy.GetSpriteView());
                if (i == 60) Effect.LightOff();

            }

            yield return StartCoroutine(Chatting(TextS1, chapter[Line]["c9"].ToString(), chapter[Line]["sc9"].ToString()));
            yield return StartCoroutine(Next());
        }

        NextChapter = false;
        Line = 0;
        chapter = CSVfileReader.Read("scenario_10");

        for (int i = 0; i < 59; i++)//챕터10
        {
            Debug.Log(i);
            if (NextChapter == true) break;
            if (i == 0)
            {
                Background.ChangeToLibrary(Background.SpriteView);
                CenterText.CenterTextChange(11);               
            }
            if (i == 1) Effect.FadeIn();
            if (i == 4) Background.ChangeToFlowerShop(Background.SpriteView);
            if(i == 12)
            {
                Search.ChapterTenEnter();
                Camera.transform.position = new Vector3(25, 0, -10);
            }
            if(Data.IsNormalEnding == true)
            {
                if (i == 14) Boy.ChangeToCrossDownArm(Boy.GetSpriteView());
                if (i == 15) Boy.ChangeToNoting(Boy.GetSpriteView());
                if (i == 18) Boy.ChangeToCrossDownArm(Boy.GetSpriteView());
                if (i == 19) Boy.ChangeToNoting(Boy.GetSpriteView());
                if (i == 21) Boy.ChangeToBasicBasic(Boy.GetSpriteView());
                if(i == 22)
                {
                    Boy.ChangeToNoting(Boy.GetSpriteView());
                    Kid.ChangeToBasicBasic(Kid.GetSpriteView());
                }
                if (i == 23) Kid.ChangeToNoting(Kid.GetSpriteView());
                if(i == 26) Boy.ChangeToBasicBasic(Boy.GetSpriteView());
                if(i == 29)
                {
                    Boy.ChangeToNoting(Boy.GetSpriteView());
                    Kid.ChangeToBasicBasic(Kid.GetSpriteView());
                }
                if (i == 30)
                {
                    Boy.ChangeToBasicBasic(Boy.GetSpriteView());
                    Kid.ChangeToNoting(Kid.GetSpriteView());
                }
                if (i == 31) Boy.ChangeToNoting(Boy.GetSpriteView());
                if (i == 32) Boy.ChangeToBasicBasic(Boy.GetSpriteView());
                if (i == 33) Boy.ChangeToNoting(Boy.GetSpriteView());
                if (i == 35) Boy.ChangeToHappyBasic(Boy.GetSpriteView());
                if (i == 37) Boy.ChangeToNoting(Boy.GetSpriteView());
                if (i == 40) Boy.ChangeToBasicBasic(Boy.GetSpriteView());
                if (i == 44) Boy.ChangeToCrossUpArm(Boy.GetSpriteView());
                if (i == 46) Boy.ChangeToNoting(Boy.GetSpriteView());
                if (i == 47) Boy.ChangeToBasicBasic(Boy.GetSpriteView());
                if (i == 49) Boy.ChangeToNoting(Boy.GetSpriteView());
                if (i == 50)
                {
                    Effect.LightOff();
                    //노말 엔딩
                    break;
                }
            }
            else 
            {
                if(i == 13)
                {
                    Line = 51;
                    //Line 변경 쪽지 팝업
                    //PopUp
                }
                if(i == 16)
                {
                    //Popup
                }
                if (i == 20) Background.ChangeToFlowerHouseBackGround(Background.SpriteView);
                if(i ==21)
                {
                    Search.ChapterTenSecondEnter();
                    Camera.transform.position = new Vector3(25, 0, -10);
                }
                if(i == 42)
                {
                    Effect.LightOff();
                    break;
                }
            }
            yield return StartCoroutine(Chatting(TextS1, chapter[Line]["c10"].ToString(), chapter[Line]["sc10"].ToString()));
            yield return StartCoroutine(Next());
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
