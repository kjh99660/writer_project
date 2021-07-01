﻿using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class Help : MonoBehaviour
{
    [SerializeField]
    private GameObject[] HelpPanel = new GameObject[2];
    public GameObject HelpImage;
    public GameObject[] ImformationPanel = new GameObject[4];
    private readonly string[] String = { "[침대 프레임]이 [사건일지]에 기록되었습니다.",
    "[스티커]가 [사건일지]에 기록되었습니다", "[깨진 시계]가 [사건일지]에 기록되었습니다","[하얀 손수건]이 [사건 일지]에 기록되었습니다.",
    "방 안의 물건을 선택하면 이를 주제로 대화가 가능합니다","[손바닥 자국]이 [사건 일지]에 기록되었습니다."};

    private readonly string[] HelpPanelString = { "방 안의 물건을 선택하면 이를 주제로 대화가 가능합니다.",
        "꽃집 안의 물건을 선택하면 이를 주제로 대화가 가능합니다." };

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i< 2; i++) HelpPanel[i] = GameObject.Find("Helps").transform.GetChild(i).gameObject;
    }
    public void DeletePopUp() => EventSystem.current.currentSelectedGameObject.gameObject.SetActive(false);
    public void DeleteParent() => EventSystem.current.currentSelectedGameObject.gameObject.transform.parent.gameObject.SetActive(false);
    public void HelpImageOn() => HelpImage.SetActive(true);
    public void ChangeHelpPanelText(int Panel, int num)//센터 도움말
    {
        HelpPanel[Panel].transform.GetChild(1).GetComponent<Text>().text = HelpPanelString[num];
    }
    public void HelpPanelOnOff(bool TrueOrFalse, int num)
    {
        HelpPanel[num].transform.gameObject.SetActive(TrueOrFalse);
    }

    /****************************************/

    public void ImformationPanelOnOff(bool TrueOrFalse)//좌상단 도움말
    {
        foreach (GameObject panel in ImformationPanel)
        {
            panel.SetActive(TrueOrFalse);
        }
    }
    public void ChangeText(int num)//좌상단 도움말 내용 변경
    {
        foreach(GameObject panel in ImformationPanel) panel.transform.GetChild(0).GetComponent<Text>().text = String[num];
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
