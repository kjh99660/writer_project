using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
    public GameObject Camera;
    public GameObject[] SavePanel;
    private Text[] PlayTime;
    void Start()
    {
        PlayTime = new Text[4];
        SavePanel = new GameObject[4];
    }

    public void Save_in()//시작 페이지에서만 사용
    {
        //저장 데이터 가져오기 ++ 동기화
        Camera.transform.position = new Vector3(-25, 0, -10);
    }
    public void Save_out()
    {
        //저장 데이터 저장하기
        Camera.transform.position = new Vector3(0, 0, -10);
    }

    //*******************************//

    public void ClickSaveOne()
    {
        Text Text = SavePanel[0].transform.GetChild(0).GetComponent<Text>();
        Text.text = DateTime.Now.ToString();
        PlayerPrefs.SetString("OnePlayTime","");
        //첫번째 파일에 게임을 저장하는 함수 호출
    }
    public void ClickSaveTwo()
    {
        Text Text = SavePanel[1].transform.GetChild(0).GetComponent<Text>();
        Text.text = DateTime.Now.ToString();
        PlayerPrefs.SetString("TwoPlayTime", "");
        //두번째 파일에 게임을 저장하는 함수 호출
    }
    public void ClickSaveThree()
    {
        Text Text = SavePanel[2].transform.GetChild(0).GetComponent<Text>();
        Text.text = DateTime.Now.ToString();
        PlayerPrefs.SetString("ThreePlayTime", "");
        //세번째 파일에 게임을 저장하는 함수 호출
    }
    public void ClickSaveFour()
    {
        Text Text = SavePanel[3].transform.GetChild(0).GetComponent<Text>();
        Text.text = DateTime.Now.ToString();
        PlayerPrefs.SetString("FourPlayTime", "");
        //네번째 파일에 게임을 저장하는 함수 호출
    }
    public void ClickLoadOne()
    {
        //첫번째 파일에 게임을 로드하는 함수 호출
    }
    public void ClickLoadTwo()
    {
        //첫번째 파일에 게임을 로드하는 함수 호출
    }
    public void ClickLoadThree()
    {
        //첫번째 파일에 게임을 로드하는 함수 호출
    }
    public void ClickLoadFour()
    {
        //첫번째 파일에 게임을 로드하는 함수 호출
    }
}
