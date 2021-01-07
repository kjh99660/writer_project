using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchScenes : MonoBehaviour
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
    
    private bool Click = true;
    private int Line = -1;
    private GameObject Camera;
    //private Background BackGround;//배경 관련
    private EffectManager Effect;//이펙트 관련
    private List<Dictionary<string, object>> chapter3;
    private List<Dictionary<string, object>> chapter2;
    private List<Dictionary<string, object>> chapter1;

    private int[] chapter3Check = new int[2] { 0, 0 };
    private int[] chapter1Check = new int[3] { 0, 0, 0 };
    private bool ChapterOneHalf = false;
    private bool ChapterTwoHalf = false;
    private bool ChapterTwoLast = false;

    //장소 이동 버튼
    public Button LeftButton;
    public Button RightButton;

    //조사 물품
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
    private Button GasRangeButton;
    private Button SinkButton;
    private Button CupBoardButton;
    private Button TableAndChairButton;
    private Button CabinetButton;
    private Button DrawerButton;
    private Button SleepingBagButton;
    private Button BedHeadButton;

    //오브젝트 목록
    private GameObject Chapter1Object;
    private GameObject Chapter2Object;
    private GameObject Chapter3Object;

    private readonly WaitForSeconds NextLetter = new WaitForSeconds(0.04f);//빌드시 대사 간격 추가한 후 빌드

    void Start()
    {
        Camera = GameObject.Find("Main Camera");
        chapter1 = CSVfileReader.Read("search_1");
        //BackGround = GameObject.Find("BackGroundSearch").GetComponent<Background>();
        Effect = GameObject.Find("Effect").GetComponent<EffectManager>();

        Chapter1Object = GameObject.Find("Chapter1Object");
        Chapter2Object = GameObject.Find("Chapter2Object");
        Chapter3Object = GameObject.Find("Chapter3Object");

        WatchButton = Chapter3Object.transform.GetChild(1).GetComponent<Button>();
        BlanketButton = Chapter3Object.transform.GetChild(0).GetComponent<Button>();

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

    //챕터 1 조사 내용
    IEnumerator Willow()//버드나무
    {
        LakeButton.interactable = false;
        LandButton.interactable = false;
        yield return StartCoroutine(Texting(chapter1, 0, 1, NameS2, TextS2));
        LakeButton.interactable = true;
        LandButton.interactable = true;
        chapter1Check[0] = 1;
    }
    IEnumerator Lake()
    {
        WillowButton.interactable = false;
        LandButton.interactable = false;
        yield return StartCoroutine(Texting(chapter1, 2, 1, NameS2, TextS2));
        WillowButton.interactable = true;
        LandButton.interactable = true;
        chapter1Check[1] = 1;
    }
    IEnumerator Land()
    {
        LakeButton.interactable = false;
        WillowButton.interactable = false;
        yield return StartCoroutine(Texting(chapter1, 3, 1, NameS2, TextS2));
        LakeButton.interactable = true;
        WillowButton.interactable = true;
        chapter1Check[2] = 1;
    }
    
    //챕터 1 두번째 조사 내용
    IEnumerator Branch()
    {
        yield return StartCoroutine(Texting(chapter1, 5, 1, NameS2, TextS2));
        Camera.transform.position = new Vector3(0, 0, -10);
    }
    IEnumerator NotUse()
    {
        yield return StartCoroutine(Texting(chapter1, 6, 1, NameS2, TextS2));
    }
    //챕터 2 조사 내용
    IEnumerator Coat()
    {
        yield return StartCoroutine(Texting(chapter2, 3, 1, NameS2, TextS2));
        Camera.transform.position = new Vector3(0, 0, -10);
    }
    IEnumerator Cup()
    {
        yield return StartCoroutine(Texting(chapter2, 2, 1, NameS2, TextS2));
    }
    IEnumerator Frame()
    {
        yield return StartCoroutine(Texting(chapter2, 1, 1, NameS2, TextS2));
    }
    IEnumerator FirePlace()
    {
        yield return StartCoroutine(Texting(chapter2, 0, 1, NameS2, TextS2));
    }
    IEnumerator Noting()
    {
        yield return StartCoroutine(Texting(chapter2, 4, 1, NameS2, TextS2));
    }
    IEnumerator GasRange()
    {
        yield return StartCoroutine(Texting(chapter2, 5, 1, NameS2Up, TextS2Up));
    }
    IEnumerator Sink()
    {
        yield return StartCoroutine(Texting(chapter2, 6, 1, NameS2Up, TextS2Up));
    }
    IEnumerator CupBoard()
    {
        if (ChapterTwoLast) yield return StartCoroutine(Texting(chapter2, 16, 1, NameS2Up, TextS2Up));
        else yield return StartCoroutine(Texting(chapter2, 7, 1, NameS2Up, TextS2Up));
    }
    IEnumerator TableAndChair()
    {
        yield return StartCoroutine(Texting(chapter2, 8, 1, NameS2Up, TextS2Up));
    }
    IEnumerator Cabinet()
    {
        if (ChapterTwoLast)
        {
            yield return StartCoroutine(Texting(chapter2, 19, 1, NameS2Down, TextS2Down));
            Camera.transform.position = new Vector3(0, 0, -10);
        }
        else yield return StartCoroutine(Texting(chapter2, 9, 1, NameS2Down, TextS2Down));
    }
    IEnumerator Drawer()
    {
        yield return StartCoroutine(Texting(chapter2, 10, 1, NameS2Down, TextS2Down));
    }
    IEnumerator SleepingBag()
    {
        if (ChapterTwoLast) yield return StartCoroutine(Texting(chapter2, 17, 2, NameS2Down, TextS2Down));
        else yield return StartCoroutine(Texting(chapter2, 11, 1, NameS2Down, TextS2Down));
    }   
    IEnumerator BedHead()
    {
        CabinetButton.interactable = false;
        DrawerButton.interactable = false;
        SleepingBagButton.interactable = false;
        yield return StartCoroutine(Texting(chapter2, 12, 4, NameS2Down, TextS2Down));
        CabinetButton.interactable = true;
        DrawerButton.interactable = true;
        SleepingBagButton.interactable = true;
        Camera.transform.position = new Vector3(0, 0, -10);
    }
    IEnumerator Nothing(Text name, Text text)
    {
        yield return StartCoroutine(Texting(chapter2, 20, 1, name, text));
    }
    //챕터 3 조사 내용
    IEnumerator Watch()
    {
        BlanketButton.interactable = false;
        yield return StartCoroutine(Texting(chapter3, 3, 6, NameS2, TextS2));
        BlanketButton.interactable = true;
        chapter3Check[0] = 1;
    }
    IEnumerator Blanket()
    {
        WatchButton.interactable = false;
        yield return StartCoroutine(Texting(chapter3, 0, 2, NameS2, TextS2));
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
        //배경 활성화 -> 챗 컨트롤러
        chapter2 = CSVfileReader.Read("search_2");
        LakeButton.gameObject.SetActive(false);
        WillowButton.gameObject.SetActive(false);
        LandButton.gameObject.SetActive(false);
        BranchButton.gameObject.SetActive(false);
        
        CoatButton.gameObject.SetActive(true);
        FrameButton.gameObject.SetActive(true);
        CupButton.gameObject.SetActive(true);
        FirePlaceButton.gameObject.SetActive(true);
    }
    public void ChapterTwoHalfEnter()
    {
        ChapterTwoHalf = true;
        LeftButton.gameObject.SetActive(true);
        RightButton.gameObject.SetActive(true);

        GasRangeButton.gameObject.SetActive(true);
        SinkButton.gameObject.SetActive(true);
        CupBoardButton.gameObject.SetActive(true);
        TableAndChairButton.gameObject.SetActive(true);
        //주방
        CabinetButton.gameObject.SetActive(true);
        DrawerButton.gameObject.SetActive(true);
        SleepingBagButton.gameObject.SetActive(true);
        BedHeadButton.gameObject.SetActive(true);
        //침실
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
        chapter3 = CSVfileReader.Read("search_3");
        BranchButton.gameObject.SetActive(true);
        WatchButton.gameObject.SetActive(true);
        BlanketButton.gameObject.SetActive(true);
    }
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
        else if (ChapterTwoLast) StartCoroutine(Nothing(NameS2, TextS2));
        else StartCoroutine(Coat());
    }
    public void ClickCup()
    {
        if (ChapterTwoHalf) StartCoroutine(Noting());
        else if (ChapterTwoLast) StartCoroutine(Nothing(NameS2, TextS2));
        else StartCoroutine(Cup());
    }
    public void ClickFirePlace()
    {
        if (ChapterTwoHalf) StartCoroutine(Noting());
        else if (ChapterTwoLast) StartCoroutine(Nothing(NameS2, TextS2));
        else StartCoroutine(FirePlace());
    }
    public void ClickFrame()
    {
        if (ChapterTwoHalf) StartCoroutine(Noting());
        else if (ChapterTwoLast) StartCoroutine(Nothing(NameS2, TextS2));
        else StartCoroutine(Frame());
    }
    //[별장 주방] - 왼쪽
    public void ClickGasRange()
    {
        if (ChapterTwoHalf) StartCoroutine(GasRange());
        else StartCoroutine(Nothing(NameS2Up, TextS2Up));
    }
    public void ClickSink()
    {       
        if (ChapterTwoHalf) StartCoroutine(Sink());
        else StartCoroutine(Nothing(NameS2Up, TextS2Up));       
    }
    public void ClickCupBoard() => StartCoroutine(CupBoard());
    public void ClickTableAndChair()
    {
        if (ChapterTwoHalf) StartCoroutine(TableAndChair());
        else StartCoroutine(Nothing(NameS2Up, TextS2Up));
    }
    public void ClickCabinet() => StartCoroutine(Cabinet());
    public void ClickDrawer()
    {
        if (ChapterTwoHalf) StartCoroutine(Drawer());
        else StartCoroutine(Nothing(NameS2Down, TextS2Down));
    }
    public void ClickSleepingBag() => StartCoroutine(SleepingBag());
    public void ClickBedHead()
    {
        if (ChapterTwoHalf) StartCoroutine(BedHead());
        else StartCoroutine(Nothing(NameS2Down, TextS2Down));
    }

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
