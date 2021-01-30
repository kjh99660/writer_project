using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchScenes : MonoBehaviour//개망한 클래스 이해하려 하지 말것
{
    // Start is called before the first frame update
    [SerializeField]   
    private Text NameS2;
    [SerializeField]
    private Text TextS2;
    [SerializeField]
    private Text NameS2Down;
    [SerializeField]
    private Text TextS2Down;
    [SerializeField]
    private Text NameS2Up;
    [SerializeField]
    private Text TextS2Up;
    [SerializeField]
    private GameObject UpText;
    [SerializeField]
    private GameObject MiddleText;
    [SerializeField]
    private GameObject DownText;

    private bool Click = true;
    private int Line = -1;
    private GameObject Camera;
    private Help Help;
    private Background BackGround;//배경 관련
    private EffectManager Effect;//이펙트 관련
    private Ingame_setting Ingame_Setting;//인 게임 세팅 변화
    private CharacterOther Character;//다른 등장인물 이미지
    private List<Dictionary<string, object>> chapter4;
    private List<Dictionary<string, object>> chapter3;
    private List<Dictionary<string, object>> chapter2;
    private List<Dictionary<string, object>> chapter1;

    private int[] chapter3Check = new int[3] { 0, 0, 0 };
    private int[] chapter1Check = new int[3] { 0, 0, 0 };
    private int[] chapter4Check = new int[5] {0, 0, 0, 0, 0 };
    private int[] chapter4CheckSecond = new int[6] { 0, 0, 0, 0, 0, 0 };
    private bool ChapterOneHalf = false;
    private bool ChapterTwoHalf = false;
    private bool ChapterTwoLast = false;
    private bool ChapterThree = false;

    //장소 이동 버튼
    public Button LeftButton;
    public Button RightButton;

    //조사 물품
    private Button WatchButton;
    private Button BlanketButton;
    private Button TowelButton;

    private Button LakeButton;
    private Button LandButton;
    private Button WillowButton;
    private Button BranchButton;

    private Button FrameButton;
    private Button FirePlaceButton;
    private Button CupButton;
    private Button CoatButton;
    private Button GasRangeButton;
    private Button SinkButton;
    private Button CupBoardButton;
    private Button TableAndChairButton;
    private Button CabinetButton;
    private Button DrawerButton;
    private Button SleepingBagButton;
    private Button BedHeadButton;

    private Button AmberBedButton;
    private Button AmberFrameButton;
    private Button AmberDeskButton;
    private Button AmberRabbitButton;
    private Button AmberPosterButton;

    private Button LillyCounterButton;
    private Button LillyFlowerPotButton;
    private Button LillyMarieGoldButton;
    private Button LillyRoseButton;
    private Button LillyRoseMarieButton;
    private Button LillyHydrangeaButton;

    //오브젝트 목록
    private GameObject Chapter1Object;
    private GameObject Chapter2Object;
    private GameObject Chapter3Object;
    private GameObject Chapter4Object;

    private readonly WaitForSeconds NextLetter = new WaitForSeconds(0.04f);//빌드시 대사 간격 추가한 후 빌드

    void Start()
    {
        Camera = GameObject.Find("Main Camera");
        chapter1 = CSVfileReader.Read("search_1");
        BackGround = GameObject.Find("BackGroundMain").GetComponent<Background>();
        Effect = GameObject.Find("Effect").GetComponent<EffectManager>();
        Help = GameObject.Find("Helps").GetComponent<Help>();
        Ingame_Setting = GameObject.Find("Canvas").transform.Find("Setting").GetComponent<Ingame_setting>();
        Character = GameObject.Find("Standing").transform.GetChild(3).GetComponent<CharacterOther>();

        Chapter1Object = GameObject.Find("Chapter1Object");
        Chapter2Object = GameObject.Find("Chapter2Object");
        Chapter3Object = GameObject.Find("Chapter3Object");
        Chapter4Object = GameObject.Find("Chapter4Object");

        BlanketButton = Chapter3Object.transform.GetChild(0).GetComponent<Button>();
        WatchButton = Chapter3Object.transform.GetChild(1).GetComponent<Button>();
        TowelButton = Chapter3Object.transform.GetChild(2).GetComponent<Button>();

        FirePlaceButton = Chapter2Object.transform.GetChild(0).GetComponent<Button>();
        FrameButton = Chapter2Object.transform.GetChild(1).GetComponent<Button>();
        CoatButton = Chapter2Object.transform.GetChild(2).GetComponent<Button>();
        CupButton = Chapter2Object.transform.GetChild(3).GetComponent<Button>();

        GasRangeButton = Chapter2Object.transform.GetChild(4).GetComponent<Button>();
        SinkButton = Chapter2Object.transform.GetChild(5).GetComponent<Button>();
        CupBoardButton = Chapter2Object.transform.GetChild(6).GetComponent<Button>();
        TableAndChairButton = Chapter2Object.transform.GetChild(7).GetComponent<Button>();
        CabinetButton = Chapter2Object.transform.GetChild(8).GetComponent<Button>();
        DrawerButton = Chapter2Object.transform.GetChild(9).GetComponent<Button>();
        SleepingBagButton = Chapter2Object.transform.GetChild(10).GetComponent<Button>();
        BedHeadButton = Chapter2Object.transform.GetChild(11).GetComponent<Button>();

        LakeButton = Chapter1Object.transform.GetChild(0).GetComponent<Button>();
        WillowButton = Chapter1Object.transform.GetChild(1).GetComponent<Button>();
        LandButton = Chapter1Object.transform.GetChild(2).GetComponent<Button>();
        BranchButton = Chapter1Object.transform.GetChild(3).GetComponent<Button>();
        //챕터 3 이후부터는 나중에 연결
    }
    public void Click_Text()
    {
        Click = false;
    }
    IEnumerator Chatting(Text name, Text text, string narrator, string narration)//채팅 진행 코루틴 , 한 프레임마다 한 글자씩 생성
    {
        name.text = narrator;
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
    IEnumerator Texting(List<Dictionary<string, object>> TextFile, int LineNumber, int LoopTime, Text Name, Text Text)
    {
        Name.gameObject.SetActive(true);
        Text.gameObject.SetActive(true);
        Line = LineNumber;
        for (int i = 0; i < LoopTime; i++)
        {
            yield return StartCoroutine(Chatting(Name, Text, TextFile[Line]["search1"].ToString(), TextFile[Line]["search2"].ToString()));
            yield return StartCoroutine(Next());
        }
        Name.gameObject.SetActive(false);
        Text.gameObject.SetActive(false);
    }


    /**************************************************************************************************/
    //조사 물품 코루틴

    //#챕터 1 조사 내용
    IEnumerator Willow()//버드나무
    {
        MiddleText.SetActive(true);
        LakeButton.interactable = false;
        LandButton.interactable = false;
        yield return StartCoroutine(Texting(chapter1, 0, 1, NameS2, TextS2));
        LakeButton.interactable = true;
        LandButton.interactable = true;
        chapter1Check[0] = 1;
        MiddleText.SetActive(false);
    }
    IEnumerator Lake()
    {
        MiddleText.SetActive(true);
        WillowButton.interactable = false;
        LandButton.interactable = false;
        yield return StartCoroutine(Texting(chapter1, 2, 1, NameS2, TextS2));
        WillowButton.interactable = true;
        LandButton.interactable = true;
        chapter1Check[1] = 1;
        MiddleText.SetActive(false);
    }
    IEnumerator Land()
    {
        MiddleText.SetActive(true);
        LakeButton.interactable = false;
        WillowButton.interactable = false;
        yield return StartCoroutine(Texting(chapter1, 3, 1, NameS2, TextS2));
        LakeButton.interactable = true;
        WillowButton.interactable = true;
        chapter1Check[2] = 1;
        MiddleText.SetActive(false);
    }
    
    //#챕터 1 두번째 조사 내용
    IEnumerator Branch()
    {
        MiddleText.SetActive(true);
        yield return StartCoroutine(Texting(chapter1, 5, 1, NameS2, TextS2));
        Camera.transform.position = new Vector3(0, 0, -10);
        MiddleText.SetActive(false);
    }
    IEnumerator NotUse()
    {
        MiddleText.SetActive(true);
        yield return StartCoroutine(Texting(chapter1, 6, 1, NameS2, TextS2));
        MiddleText.SetActive(false);
    }

    //#챕터 2 조사 내용
    IEnumerator Coat()
    {
        MiddleText.SetActive(true);
        yield return StartCoroutine(Texting(chapter2, 3, 1, NameS2, TextS2));
        Camera.transform.position = new Vector3(0, 0, -10);
        MiddleText.SetActive(false);
    }
    IEnumerator Cup()
    {
        MiddleText.SetActive(true);
        yield return StartCoroutine(Texting(chapter2, 2, 1, NameS2, TextS2));
        MiddleText.SetActive(false);
    }
    IEnumerator Frame()
    {
        MiddleText.SetActive(true);
        yield return StartCoroutine(Texting(chapter2, 1, 1, NameS2, TextS2));
        MiddleText.SetActive(false);
    }
    IEnumerator FirePlace()
    {
        MiddleText.SetActive(true);
        yield return StartCoroutine(Texting(chapter2, 0, 1, NameS2, TextS2));
        MiddleText.SetActive(false);
    }
    IEnumerator Noting()
    {
        MiddleText.SetActive(true);
        yield return StartCoroutine(Texting(chapter2, 4, 1, NameS2, TextS2));
        MiddleText.SetActive(false);
    }
    IEnumerator GasRange()
    {
        UpText.SetActive(true);
        yield return StartCoroutine(Texting(chapter2, 5, 1, NameS2Up, TextS2Up));
        UpText.SetActive(false);
    }
    IEnumerator Sink()
    {
        UpText.SetActive(true);
        yield return StartCoroutine(Texting(chapter2, 6, 1, NameS2Up, TextS2Up));
        UpText.SetActive(false);
    }
    IEnumerator CupBoard()
    {
        UpText.SetActive(true);
        if (ChapterTwoLast) yield return StartCoroutine(Texting(chapter2, 16, 1, NameS2Up, TextS2Up));
        else yield return StartCoroutine(Texting(chapter2, 7, 1, NameS2Up, TextS2Up));
        UpText.SetActive(false);
    }
    IEnumerator TableAndChair()
    {
        UpText.SetActive(true);
        yield return StartCoroutine(Texting(chapter2, 8, 1, NameS2Up, TextS2Up));
        UpText.SetActive(false);
    }
    IEnumerator Cabinet()
    {
        DownText.SetActive(true);
        if (ChapterTwoLast)
        {
            yield return StartCoroutine(Texting(chapter2, 19, 1, NameS2Down, TextS2Down));
            Camera.transform.position = new Vector3(0, 0, -10);
            //Ingame_Setting.GetClue();
        }
        else yield return StartCoroutine(Texting(chapter2, 9, 1, NameS2Down, TextS2Down));
        DownText.SetActive(false);
    }
    IEnumerator Drawer()
    {
        DownText.SetActive(true);
        yield return StartCoroutine(Texting(chapter2, 10, 1, NameS2Down, TextS2Down));
        DownText.SetActive(false);
    }
    IEnumerator SleepingBag()
    {
        DownText.SetActive(true);
        if (ChapterTwoLast) yield return StartCoroutine(Texting(chapter2, 17, 2, NameS2Down, TextS2Down));
        else yield return StartCoroutine(Texting(chapter2, 11, 1, NameS2Down, TextS2Down));
        DownText.SetActive(false);
    }   
    IEnumerator BedHead()//증거물품
    {
        DownText.SetActive(true);
        CabinetButton.interactable = false;
        DrawerButton.interactable = false;
        SleepingBagButton.interactable = false;
        yield return StartCoroutine(Texting(chapter2, 12, 4, NameS2Down, TextS2Down));

        CabinetButton.interactable = true;
        DrawerButton.interactable = true;
        SleepingBagButton.interactable = true;
        Camera.transform.position = new Vector3(0, 0, -10);
        DownText.SetActive(false);
    }
    IEnumerator Nothing(List<Dictionary<string, object>> TextFile, Text name, Text text, int Line)
    {
        UpText.SetActive(true);
        MiddleText.SetActive(true);
        DownText.SetActive(true);
        yield return StartCoroutine(Texting(TextFile, Line, 1, name, text));
        UpText.SetActive(false);
        MiddleText.SetActive(false);
        DownText.SetActive(false);
    }
    //#챕터 3 조사 내용
    IEnumerator Towel()//증거물품
    {
        DownText.SetActive(true);
        if(chapter3Check[2] == 1)
        {
            yield return StartCoroutine(Texting(chapter3, 16, 1, NameS2Down, TextS2Down));
        }
        else
        {
            TurnChapterTwoItem(false);
            yield return StartCoroutine(Texting(chapter3, 11, 2, NameS2Down, TextS2Down));
            Effect.Flash();
            yield return StartCoroutine(Texting(chapter3, 13, 3, NameS2Down, TextS2Down));
            Help.ChangeText(3);
            Help.ImformationPanelOnOff(true);
            chapter3Check[2] = 1;
            TurnChapterTwoItem(true);
        }
        DownText.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        Help.ImformationPanelOnOff(false);
    }
    IEnumerator Watch()//증거물품
    {
        DownText.SetActive(true);
        if (chapter3Check[0] == 1)
        {
            yield return StartCoroutine(Texting(chapter3, 16, 1, NameS2Down, TextS2Down));
        }
        else 
        {
            TurnChapterTwoItem(false);
            yield return StartCoroutine(Texting(chapter3, 5, 3, NameS2Down, TextS2Down));

            BackGround.ChangeToClueWatch(BackGround.SpriteViewSearchRight);
            Effect.Flash();
            Ingame_Setting.GetClue(0);//시계
            Help.ChangeText(2);
            Help.ImformationPanelOnOff(true);
            yield return StartCoroutine(Texting(chapter3, 8, 1, NameS2Down, TextS2Down));
            NameS2Down.gameObject.SetActive(true);
            TextS2Down.gameObject.SetActive(true);
            yield return StartCoroutine(Next());
            NameS2Down.gameObject.SetActive(false);
            TextS2Down.gameObject.SetActive(false);
            Help.ImformationPanelOnOff(false);
            chapter3Check[0] = 1;
            BackGround.ChangeToBedroom(BackGround.SpriteViewSearchRight);
            TurnChapterTwoItem(true);
        }
        DownText.SetActive(false);
    }
    IEnumerator Blanket()//+스티커 (증거물품)
    {
        MiddleText.SetActive(true);
        if(chapter3Check[1] == 1)
        {
            yield return StartCoroutine(Texting(chapter3, 16, 1, NameS2, TextS2));
        }
        else
        {
            TurnChapterTwoItem(false);
            Line = 0;
            for (int i = 0; i < 5; i++)
            {
                if (i == 2) BackGround.ChangeToClueSticker(BackGround.SpriteViewSearch);
                if (i == 3) Effect.Flash();
                if (i == 4)
                {
                    Help.ChangeText(1);
                    Help.ImformationPanelOnOff(true);
                }
                yield return StartCoroutine(Chatting(NameS2, TextS2, chapter3[Line]["search1"].ToString(), chapter3[Line]["search2"].ToString()));
                yield return StartCoroutine(Next());
            }
            Help.ImformationPanelOnOff(false);
            Ingame_Setting.GetClue(1);//스티커
            TurnChapterTwoItem(true);
            chapter3Check[1] = 1;
            BackGround.ChangeToFireplace(BackGround.SpriteViewSearch);
        }
        MiddleText.SetActive(false);
    }
    //#챕터 4 조사 내용
    IEnumerator AmberPoster()
    {
        MiddleText.SetActive(true);
        Character.ChangeToAmber(Character.GetSpriteView());
        yield return StartCoroutine(Texting(chapter4, 1, 3, NameS2, TextS2));
        Character.ChangeToNoting(Character.GetSpriteView());
        chapter4Check[0] = 1;
        MiddleText.SetActive(false);
    }
    IEnumerator AmberFrame()
    {
        MiddleText.SetActive(true);
        Character.ChangeToAmber(Character.GetSpriteView());
        yield return StartCoroutine(Texting(chapter4, 4, 3, NameS2, TextS2));
        Character.ChangeToNoting(Character.GetSpriteView());
        chapter4Check[1] = 1;
        MiddleText.SetActive(false);
    }
    IEnumerator AmberRabbit()
    {
        MiddleText.SetActive(true);
        yield return StartCoroutine(Texting(chapter4, 7, 1, NameS2, TextS2));
        Character.ChangeToAmber(Character.GetSpriteView());
        yield return StartCoroutine(Texting(chapter4, 8, 1, NameS2, TextS2));
        Character.ChangeToNoting(Character.GetSpriteView());
        chapter4Check[2] = 1;
        MiddleText.SetActive(false);
    }
    IEnumerator AmberDesk()
    {
        MiddleText.SetActive(true);
        yield return StartCoroutine(Texting(chapter4, 9, 1, NameS2, TextS2));
        chapter4Check[3] = 1;
        MiddleText.SetActive(false);
    }
    IEnumerator AmberBed()
    {
        MiddleText.SetActive(true);
        yield return StartCoroutine(Texting(chapter4, 10, 1, NameS2, TextS2));
        chapter4Check[4] = 1;
        MiddleText.SetActive(false);
    }
    IEnumerator LillyMarieGold()
    {
        MiddleText.SetActive(true);
        yield return StartCoroutine(Texting(chapter4, 13, 1, NameS2, TextS2));
        MiddleText.SetActive(false);
        chapter4CheckSecond[0] = 1;
    }
    IEnumerator LillyCounter()
    {
        MiddleText.SetActive(true);
        yield return StartCoroutine(Texting(chapter4, 12, 1, NameS2, TextS2));
        MiddleText.SetActive(false);
        chapter4CheckSecond[1] = 1;
    }
    IEnumerator LillyRoseMarie()
    {
        MiddleText.SetActive(true);
        yield return StartCoroutine(Texting(chapter4, 14, 1, NameS2, TextS2));
        MiddleText.SetActive(false);
        chapter4CheckSecond[2] = 1;
    }
    IEnumerator LillyRose()
    {
        MiddleText.SetActive(true);
        yield return StartCoroutine(Texting(chapter4, 15, 1, NameS2, TextS2));
        MiddleText.SetActive(false);
        chapter4CheckSecond[3] = 1;
    }
    IEnumerator LillyHydrangea()
    {
        MiddleText.SetActive(true);
        yield return StartCoroutine(Texting(chapter4, 16, 1, NameS2, TextS2));
        Character.ChangeToLilly(Character.GetSpriteView());
        yield return StartCoroutine(Texting(chapter4, 17, 4, NameS2, TextS2));
        Character.ChangeToNoting(Character.GetSpriteView());
        MiddleText.SetActive(false);
        chapter4CheckSecond[4] = 1;
    }
    IEnumerator LillyFlowerPot()
    {
        MiddleText.SetActive(true);
        yield return StartCoroutine(Texting(chapter4, 21, 1, NameS2, TextS2));
        Character.ChangeToLilly(Character.GetSpriteView());
        yield return StartCoroutine(Texting(chapter4, 22, 2, NameS2, TextS2));
        Character.ChangeToNoting(Character.GetSpriteView());
        MiddleText.SetActive(false);
        chapter4CheckSecond[5] = 1;
    }

    /********************************************************************/
    //챕터 변경 함수
    public void ChapterOneEnter()
    {
        //첫 배경 활성화
        TurnChapterOneItem(true);
    }
    public void ChangeOne_2Search()//나뭇가지를 눌러야 넘어가는 씬
    {
        //나뭇가지 및 배경 활성화
        BranchButton.gameObject.SetActive(true);
    }
    public void ChapterTwoEnter()
    {
        //배경 활성화
        chapter2 = CSVfileReader.Read("search_2");
        TurnChapterOneItem(false);
        BranchButton.gameObject.SetActive(false);
        TurnChapterTwoItem(true);
    }
    public void ChapterTwoHalfEnter()
    {
        ChapterTwoHalf = true;
        LeftButton.gameObject.SetActive(true);
        RightButton.gameObject.SetActive(true);
        TurnChapterTwoItem(true);
        //좌우 이동 가능한 배경 , 아이 코트 사라짐
        //새로운 오브젝트 추가
    }
    public void ChapterTwoLastEnter()
    {
        ChapterTwoHalf = false;
        ChapterTwoLast = true;
    }
    public void ChapterThreeEnter()
    {
        ChapterTwoLast = false;
        ChapterThree = true;
        LeftButton.gameObject.SetActive(true);
        RightButton.gameObject.SetActive(true);
        TurnChapterTwoItem(true);
        chapter3 = CSVfileReader.Read("search_3");
        TurnChapterThreeItem(true);
    }
    public void ChapterFourEnter()
    {
        chapter4 = CSVfileReader.Read("search_4");
        BackGround.ChangeToAmberHouse(BackGround.SpriteViewSearch);
        AmberBedButton = Chapter4Object.transform.GetChild(0).GetComponent<Button>();
        AmberPosterButton = Chapter4Object.transform.GetChild(1).GetComponent<Button>();
        AmberFrameButton = Chapter4Object.transform.GetChild(2).GetComponent<Button>();
        AmberDeskButton = Chapter4Object.transform.GetChild(3).GetComponent<Button>();
        AmberRabbitButton = Chapter4Object.transform.GetChild(4).GetComponent<Button>();
        ChapterThree = false;
        LeftButton.gameObject.SetActive(false);
        RightButton.gameObject.SetActive(false);
        TurnChapterTwoItem(false);
        TurnChapterThreeItem(false);
        TurnChapterFourItemFirst(true);
    }
    public void ChapterFourSecondEnter()
    {
        BackGround.ChangeToFlowerShop(BackGround.SpriteViewSearch);
        LillyCounterButton = Chapter4Object.transform.GetChild(5).GetComponent<Button>();
        LillyFlowerPotButton = Chapter4Object.transform.GetChild(6).GetComponent<Button>();
        LillyMarieGoldButton = Chapter4Object.transform.GetChild(7).GetComponent<Button>();
        LillyHydrangeaButton = Chapter4Object.transform.GetChild(8).GetComponent<Button>();
        LillyRoseMarieButton = Chapter4Object.transform.GetChild(9).GetComponent<Button>();
        LillyRoseButton = Chapter4Object.transform.GetChild(10).GetComponent<Button>();
        TurnChapterFourItemFirst(false);
        TurnChapterFourItemSecond(true);
    }
    public void TurnChapterOneItem(bool OnOff)
    {
        LakeButton.gameObject.SetActive(OnOff);
        WillowButton.gameObject.SetActive(OnOff);
        LandButton.gameObject.SetActive(OnOff);
    }
    public void TurnChapterTwoItem(bool OnOff)
    {
        CoatButton.gameObject.SetActive(OnOff);
        FrameButton.gameObject.SetActive(OnOff);
        CupButton.gameObject.SetActive(OnOff);
        FirePlaceButton.gameObject.SetActive(OnOff);
        //거실
        GasRangeButton.gameObject.SetActive(OnOff);
        SinkButton.gameObject.SetActive(OnOff);
        CupBoardButton.gameObject.SetActive(OnOff);
        TableAndChairButton.gameObject.SetActive(OnOff);
        //주방
        CabinetButton.gameObject.SetActive(OnOff);
        DrawerButton.gameObject.SetActive(OnOff);
        SleepingBagButton.gameObject.SetActive(OnOff);
        BedHeadButton.gameObject.SetActive(OnOff);
        //침실
    }
    public void TurnChapterThreeItem(bool OnOff)
    {
        BlanketButton.gameObject.SetActive(OnOff);
        WatchButton.gameObject.SetActive(OnOff);
        TowelButton.gameObject.SetActive(OnOff);
    }
    public void TurnChapterFourItemFirst(bool OnOff)
    {
        AmberBedButton.gameObject.SetActive(OnOff);
        AmberDeskButton.gameObject.SetActive(OnOff);
        AmberPosterButton.gameObject.SetActive(OnOff);
        AmberRabbitButton.gameObject.SetActive(OnOff);
        AmberFrameButton.gameObject.SetActive(OnOff);
    }
    public void TurnChapterFourItemSecond(bool OnOff)
    {
        LillyHydrangeaButton.gameObject.SetActive(OnOff);
        LillyMarieGoldButton.gameObject.SetActive(OnOff);
        LillyRoseButton.gameObject.SetActive(OnOff);
        LillyRoseMarieButton.gameObject.SetActive(OnOff);
        LillyFlowerPotButton.gameObject.SetActive(OnOff);
        LillyCounterButton.gameObject.SetActive(OnOff);
    }

    /*************************************************************************/
    //버튼 관련 메서드
    public void ClickLeftButton()
    {
        //배경을 바꾸는 내용 - 챕터마다 다름    
        Effect.LightOff();
        Camera.transform.position = new Vector3(25, Camera.transform.position.y + 10, -10);    
        Effect.FadeIn();        
    }
    public void ClickRightButton()
    {
        //배경을 바꾸는 내용 - 챕터마다 다름 > Chat Controller에서 하기
        Effect.LightOff();
        Camera.transform.position = new Vector3(25, Camera.transform.position.y - 10, -10);
        Effect.FadeIn();
    }
    //#챕터 1

    public void ClickWillow()
    {
        if (ChapterOneHalf) StartCoroutine(NotUse());
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
    //#챕터 2
    public void ClickCoat()
    {
        if (ChapterTwoHalf) StartCoroutine(Noting());//이미 조사한 것 같다.
        else if (ChapterTwoLast) StartCoroutine(Nothing(chapter2, NameS2, TextS2, 20));//2쳅터는 20라인에서 시작
        else if (ChapterThree) StartCoroutine(Nothing(chapter3, NameS2, TextS2, 15));
        else StartCoroutine(Coat());
    }
    public void ClickCup()
    {
        if (ChapterTwoHalf) StartCoroutine(Noting());
        else if (ChapterTwoLast) StartCoroutine(Nothing(chapter2, NameS2, TextS2, 20));
        else if (ChapterThree) StartCoroutine(Nothing(chapter3, NameS2, TextS2, 9));
        else StartCoroutine(Cup());
    }
    public void ClickFirePlace()
    {
        if (ChapterTwoHalf) StartCoroutine(Noting());
        else if (ChapterTwoLast) StartCoroutine(Nothing(chapter2, NameS2, TextS2, 20));
        else if (ChapterThree) StartCoroutine(Nothing(chapter3, NameS2, TextS2, 9));
        else StartCoroutine(FirePlace());
    }
    public void ClickFrame()
    {
        if (ChapterTwoHalf) StartCoroutine(Noting());
        else if (ChapterTwoLast) StartCoroutine(Nothing(chapter2, NameS2, TextS2, 20));
        else if (ChapterThree) StartCoroutine(Nothing(chapter3, NameS2, TextS2, 9));
        else StartCoroutine(Frame());
    }
    //[별장 주방] - 왼쪽
    public void ClickGasRange()
    {
        if (ChapterTwoHalf) StartCoroutine(GasRange());
        else if (ChapterTwoLast) StartCoroutine(Nothing(chapter2, NameS2Up, TextS2Up, 20));
        else if (ChapterThree) StartCoroutine(Nothing(chapter3, NameS2Up, TextS2Up, 9));
    }
    public void ClickSink()
    {       
        if (ChapterTwoHalf) StartCoroutine(Sink());
        else if (ChapterTwoLast) StartCoroutine(Nothing(chapter2, NameS2Up, TextS2Up, 20));
        else if (ChapterThree) StartCoroutine(Nothing(chapter3, NameS2Up, TextS2Up, 9));
    }
    public void ClickCupBoard()
    {
        if (ChapterThree) StartCoroutine(Nothing(chapter3, NameS2Up, TextS2Up, 9));
        else StartCoroutine(CupBoard());
    }
    public void ClickTableAndChair()
    {
        if (ChapterTwoHalf) StartCoroutine(TableAndChair());
        else if (ChapterTwoLast) StartCoroutine(Nothing(chapter2, NameS2Up, TextS2Up, 20));
        else if (ChapterThree) StartCoroutine(Nothing(chapter3, NameS2Up, TextS2Up, 9));
    }
    public void ClickCabinet()
    {
        if (ChapterThree) StartCoroutine(Nothing(chapter3, NameS2Down, TextS2Down, 9));
        else StartCoroutine(Cabinet());
    }
    public void ClickDrawer()
    {
        if (ChapterTwoHalf) StartCoroutine(Drawer());
        else if (ChapterTwoLast) StartCoroutine(Nothing(chapter2, NameS2Down, TextS2Down, 20));
        else if (ChapterThree) StartCoroutine(Nothing(chapter3, NameS2Down, TextS2Down, 9));
    }
    public void ClickSleepingBag()
    {
        if (ChapterThree) StartCoroutine(Nothing(chapter3, NameS2Down, TextS2Down, 9));
        else StartCoroutine(SleepingBag());
    }
    public void ClickBedHead()
    {
        if (ChapterTwoHalf) StartCoroutine(BedHead());
        else if (ChapterTwoLast) StartCoroutine(Nothing(chapter2, NameS2Down, TextS2Down, 20));
        else if (ChapterThree) StartCoroutine(Nothing(chapter3, NameS2Down, TextS2Down, 9));
    }
    //#챕터 3
    public void ClickBlanket() => StartCoroutine(Blanket());
    public void ClickWatch() => StartCoroutine(Watch());
    public void ClickTowel() => StartCoroutine(Towel());
    //#챕터 4
    public void ClickAmberPoster() => StartCoroutine(AmberPoster());
    public void ClickAmberFrame() => StartCoroutine(AmberFrame());
    public void ClickAmberBed() => StartCoroutine(AmberBed());
    public void ClickAmberDesk() => StartCoroutine(AmberDesk());
    public void ClickAmberRabbit() => StartCoroutine(AmberRabbit());
    public void ClickLillyCounter() => StartCoroutine(LillyCounter());
    public void ClickLillyFlowerPot() => StartCoroutine(LillyFlowerPot());
    public void ClickLillyMarieGold() => StartCoroutine(LillyMarieGold());
    public void ClickLillyHydrangea() => StartCoroutine(LillyHydrangea());
    public void ClickLillyRose() => StartCoroutine(LillyRose());
    public void ClickLillyRoseMarie() => StartCoroutine(LillyRoseMarie());

    /***********************************************************************/
    //챕터 클리어 조건 관련 함수 => 업데이트 
    public void ChapterOneSearchClear()
    {
        for (int i = 0; i < chapter1Check.Length; i++) if (chapter1Check[i] == 0) return;//1chapter search clear
        foreach (int check in chapter1Check) chapter1Check[check] = 0;
        Camera.transform.position = new Vector3(0, 0, -10);
        ChapterOneHalf = true;
        return;
    }
    public void ChapterThreeSearchClear()
    {
        for (int i = 0; i < chapter3Check.Length; i++) if (chapter3Check[i] == 0) return;//3chapter search clear
        foreach (int check in chapter3Check) chapter3Check[check] = 0;
        Camera.transform.position = new Vector3(0, 0, -10);
        ChapterThree = false;
        return;
    }
    public void ChapterFourSearchClear()
    {
        int temp = 0;
        for (int i = 0; i < chapter4Check.Length; i++) if (chapter4Check[i] == 1) temp++;//4chapter search clear
        if(temp >= 3)
        {
            foreach (int check in chapter4Check) chapter4Check[check] = 0;
            Camera.transform.position = new Vector3(0, 0, -10);
        }
    }
    public void ChapterFourSecondSearchClear()
    {
        for (int i = 0; i < chapter4CheckSecond.Length; i++) if (chapter4CheckSecond[i] == 0) return;//4chapter second search clear
        foreach (int check in chapter4CheckSecond) chapter4CheckSecond[check] = 0;
        Camera.transform.position = new Vector3(0, 0, -10);
    }

    void Update()
    {
        ChapterOneSearchClear();
        ChapterThreeSearchClear();
        ChapterFourSearchClear();
        ChapterFourSecondSearchClear();
    }
}
