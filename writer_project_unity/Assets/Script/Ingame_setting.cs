﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ingame_setting : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Camera;
    public GameObject Setting_panel;
    private string path;
    private int FileNumber = 0;
    public void Panel_onoff()
    {
        if(Setting_panel.activeSelf == false)
        {
            Debug.Log("설정패널 온");
            ScreenShot();
            Setting_panel.SetActive(true);
        }
        else
        {
            Setting_panel.SetActive(false);
        }
    }
    public void Save_in()
    {
        Camera.transform.position = new Vector3(-25, 0, -10);
    }
    public void Save_out()
    {
        Camera.transform.position = new Vector3(0, 0, -10);
    }
    public void Import_in()
    {
        Camera.transform.position = new Vector3(-50, 0, -10);
    }
    public void Import_out()
    {
        Camera.transform.position = new Vector3(0, 0, -10);
    }
    public void Setting_in()
    {
        Camera.transform.position = new Vector3(-75, 0, -10);
    }
    public void Setting_out()
    {
        Camera.transform.position = new Vector3(0, 0, -10);
    }
    public void Goto_main()
    {
        SceneManager.LoadScene("Startscene");
    }
    private IEnumerator ScreenShot()
    {
        Debug.Log("스크린 샷!");
        Debug.Log(path);
        path = "Assets/ScreenShot";
        path += FileNumber + ".png";
        ScreenCapture.CaptureScreenshot(path,2);
        FileNumber++;
        Debug.Log("스크린 샷!");
        Debug.Log(path);
        yield return new WaitForEndOfFrame();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
