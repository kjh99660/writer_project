using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[Serializable]
public class GameData : MonoBehaviour
{
    private bool IsBadEnding =  false;
    public bool IsNormalEnding;
    //둘 다 false면 True 엔딩

    //진행 상황 챕터 및 라인 저장
    public int ProgressChapter;//0 에필로그
    public int ProgressLine;

    //CG 및 엔딩 오픈 유무 저장
    public int[] CG = new int[6];
    public int[] Ending = new int[6];

    //볼륨 설정 저장
    public float MusicSound;
    public float EffectSound;

    public bool GetIsBadEnding() => IsBadEnding;
    public void SetIsBadEnding(bool value) => IsBadEnding = value;

}
