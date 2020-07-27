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
    public void Panel_onoff()
    {
        if(Setting_panel.activeSelf == false)
        {
            Setting_panel.SetActive(true);
        }
        else
        {
            Setting_panel.SetActive(false);
        }
    }
    public void Save_in()//시작 씬에서 사용
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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}