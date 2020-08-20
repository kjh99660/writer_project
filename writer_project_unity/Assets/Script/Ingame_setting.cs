using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.Android;
using System;

public class Ingame_setting : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Camera;
    public GameObject Setting_panel;

    private Vector3 startPos;
    private Vector3 targetPos;

    private bool isClose = true;

    void Start()
    {
        startPos = transform.position;
        targetPos = transform.position;
        targetPos.x -= 3.4f;
    }

    public void Panel_onoff()
    {
        if (isClose) isClose = false;
        else isClose = true;
        /*
        if (Setting_panel.activeSelf == false)
        {
            Setting_panel.SetActive(true);
        }
        else
        {
            Setting_panel.SetActive(false);
        }
        */
    }



    //인게임에서 사용
    public void Save_in()
    {
        Camera.transform.position = new Vector3(-25, 0, -10);
    }
    public void Save_out()
    {
        Camera.transform.position = new Vector3(0, 0, -10);
    }
    public void Import_in()//불러오기
    {
        Camera.transform.position = new Vector3(-50, 0, -10);
    }
    public void Import_out()
    {
        Camera.transform.position = new Vector3(0, 0, -10);
    }
    public void Setting_in()//환경 설정
    {
        Camera.transform.position = new Vector3(-75, 0, -10);
    }
    public void Setting_out()
    {
        Camera.transform.position = new Vector3(0, 0, -10);
    }

    public void Goto_main()//메인으로가기
    {
        SceneManager.LoadScene("Startscene");
    }


    // Update is called once per frame
    void Update()
    {
        if (isClose == false)
        {
            Vector3 velo = Vector3.zero;
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velo, 0.1f);
        }
        else
        {
            Vector3 velo = Vector3.zero;
            transform.position = Vector3.SmoothDamp(transform.position, startPos, ref velo, 0.1f);
        }
    }

}