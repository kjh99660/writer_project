﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.Android;
using System;
using UnityEngine.Experimental.UIElements;

public class Ingame_setting : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Camera;
    public GameObject Setting_panel;
    public GameObject soundPanel;
    public GameObject CaseFile;
    public GameObject MenuArrow;

    private SpriteRenderer Menu_Arrow;

    private Vector3 startPos;
    private Vector3 targetPos;

    private bool isClose = true;

    private ChatUI TextBox;
    private GameObject[] Buttons = { null, null, null, null, null };

    void Start()
    { 
        startPos = transform.position;
        targetPos = transform.position;
        targetPos.x -= 2.3f;
        Menu_Arrow = MenuArrow.GetComponent<SpriteRenderer>();
        TextBox = GameObject.Find("HideButton(ChatUI1)").GetComponent<ChatUI>();
        for (int i = 0; i < 5; i++)
        {
            Buttons[i] = Setting_panel.transform.GetChild(i).gameObject;
        }
    }

    public void Panel_onoff()
    {
        if (isClose)//열기
        {
            isClose = false;
            Menu_Arrow.flipX = true;
            if(!TextBox.ReturnisClose())TextBox.Changeform();
            ButtonOn();

        }
        else//닫기
        {
            isClose = true;
            Menu_Arrow.flipX = false;
            ButtonOff();
        }

    }
    public void ButtonOff()
    {
        for (int i = 0; i < 5; i++)
        {
            Buttons[i].SetActive(false);
        }
    }
    public void ButtonOn()
    {
        for (int i = 0; i < 5; i++)
        {
            Buttons[i].SetActive(true);
        }
    }



    //인게임에서 사용
    public void Case_file()//사건 파일 열기
    {
        CaseFile.SetActive(true);
        isClose = true;
        Menu_Arrow.flipX = false;
        Setting_panel.SetActive(false);
    }
    public void Case_fileCancel()//사건 파일 닫기
    {
        CaseFile.SetActive(false);
        Setting_panel.SetActive(true);

    }

    /**********************************************/

    public void Save_in()//저장하기
    {
        Camera.transform.position = new Vector3(-25, 0, -10);
    }
    public void Save_out()
    {
        Camera.transform.position = new Vector3(0, 0, -10);
    }

    /**********************************************/

    public void Import_in()//불러오기
    {
        Camera.transform.position = new Vector3(-50, 0, -10);
    }
    public void Import_out()
    {
        Camera.transform.position = new Vector3(0, 0, -10);
    }

    /**********************************************/

    public void SoundOn()//환경 설정
    {
        if (soundPanel.gameObject.activeSelf == false)
        {
            soundPanel.SetActive(true);
            isClose = true;
            Menu_Arrow.flipX = true;
            Setting_panel.SetActive(false);

        }
    }
    public void SoundOff()//환경 설정 x 버튼
    {
        soundPanel.SetActive(false);
        Menu_Arrow.flipX = false;
        Setting_panel.SetActive(true);

    }

    /**********************************************/


    public void Goto_main()//메인으로가기
    {
        SceneManager.LoadScene("Startscene");
    }


    void Update()
    {
        if (isClose == false)
        {
            Vector3 velo = Vector3.zero;
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velo, 0.005f);
        }
        else
        {
            Vector3 velo = Vector3.zero;
            transform.position = Vector3.SmoothDamp(transform.position, startPos, ref velo, 0.005f);
        }
    }

}