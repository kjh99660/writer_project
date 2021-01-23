﻿using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ChatUI : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 targetPos;

    public GameObject textUI;
    public Text CenterText;
    public GameObject Manu;
    public GameObject UIOn;


    [SerializeField]
    private bool IsClose { get; set; } = false;
    private readonly string[] TextCenter = new string[] { " ","<프롤로그>","<1장.만남>", "<2장. 오래된 별장>", "<3장. 조사>","<4장. 알리바이>" };

    void Start()
    {
        startPos = textUI.transform.position;
        targetPos = textUI.transform.position;
        targetPos.y -= 3.9f;
    }
    public void CenterTextChange(int chapter) => CenterText.text = TextCenter[chapter];
    public void Changeform()//false => 열기
    {
        //무조건 누르면 닫아야함
        IsClose = true;
        Manu.SetActive(false);
        UIOn.SetActive(true);
        Debug.Log(IsClose);
    }
    public bool GetIsClose() => IsClose;
    public void SetISClose(bool ISClose)
    {
        this.IsClose = ISClose;
    }
    void Update()
    {
        if(IsClose)
        {
            Vector3 velo = Vector3.zero;
            textUI.transform.position = Vector3.SmoothDamp(textUI.transform.position, targetPos, ref velo, 0.05f);
        }
        else//열기
        {
            Vector3 velo = Vector3.zero;
            textUI.transform.position = Vector3.SmoothDamp(textUI.transform.position, startPos, ref velo, 0.05f);
        }



    }
}
