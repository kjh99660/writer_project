using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Camera;

    //저장 관련 변수들
    //플레이어 이름
    public InputField[] PlayerName = new InputField[6];//문자열로 저장

    //플레이어가 찾은 증거의 갯수
    public InputField[] DiscoverEvidence = new InputField[6];//숫자로 저장

    //진행 상황 챕터 및 라인 저장
    public InputField[] ProgressChapter = new InputField[6];//숫자로 저장
    public InputField[] ProgressLine = new InputField[6];//숫자로 저장

    //수집한 CG갯수 저장 - 모든 파일이 CG 오픈 공유 게임 킬 때 저장
    public InputField[,] NumberOfCG = new InputField[6,6];//숫자로 저장  0 수집 x | 1 수집 0

    //게임 볼륨 저장 - 항상 50으로 일정하게 변경
    public InputField[] Volume = new InputField[6];// float로 저장

    void Start()
    {

    }

    public void Save_in()//시작 페이지에서만 사용
    {
        Camera.transform.position = new Vector3(-25, 0, -10);
    }
    public void Save_out()
    {
        Camera.transform.position = new Vector3(0, 0, -10);
    }
    public void ClickSave1()
    {

    }

// Update is called once per frame
void Update()
    {
        
    }
}
