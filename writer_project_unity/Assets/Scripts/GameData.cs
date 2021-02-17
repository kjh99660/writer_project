using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameData : MonoBehaviour
{
    public bool IsBadEnding;
    public bool IsNormalEnding;
    //둘 다 false면 True 엔딩

    public int Stage;//0 에필로그
    public int Line;

    public float MusicSound;
    public float EffectSound;

}
