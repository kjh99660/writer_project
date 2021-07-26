using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class GameData : MonoBehaviour
{
    private bool IsBadEnding =  false;
    private bool IsNormalEnding = false;
    //둘 다 false면 True 엔딩

    //진행 상황 챕터 및 라인 저장
    private int ProgressChapter;//0 에필로그
    private int ProgressLine;

    //CG 및 엔딩 오픈 유무 저장
    private int[] CG = new int[6];
    private int[] Ending = new int[6];

    //증거 수집 유무
    private int[] Clue = new int[6];
    private int[] Character = new int[6];

    //저장 데이터 정보
    private string[] PlayTime = new string[4];


    //*************************************//
    //사운드는 다른 클래스에서 저장

    //루트 관련 정보
    public bool GetIsBadEnding() => IsBadEnding;
    public void SetIsBadEnding(bool value)
    {
        IsBadEnding = value;
        if (IsBadEnding) PlayerPrefs.SetInt("IsBadEnding", 1);
        else PlayerPrefs.SetInt("ISBadEnding", 0);
    }
    public bool GetISNormalEnding() => IsNormalEnding;
    public void SetIsNormalEnding(bool value)
    {
        IsNormalEnding = value;
        if (IsNormalEnding) PlayerPrefs.SetInt("IsNormalEnding", 1);
        else PlayerPrefs.SetInt("IsNormalEnding", 0);
    }
    
    //저장 및 로드 관련
    public void Load()
    {
        
    }
    public void Save(int Chapter,int Line,int[] CG, int[] Ending)
    {
        ProgressChapter = Chapter;
        ProgressLine = Line;
        this.CG = CG;
        this.Ending = Ending;
        PlayerPrefs.SetInt("ProgressChapter", ProgressChapter);
        PlayerPrefs.SetInt("ProgressLine", ProgressLine);
        for (int i = 0; i < 6; i++) PlayerPrefs.SetInt("CG" + i, this.CG[i]);
        for (int i = 0; i < 6; i++) PlayerPrefs.SetInt("Ending" + i, this.CG[i]);
    }
}
