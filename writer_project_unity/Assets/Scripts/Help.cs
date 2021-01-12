using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class Help : MonoBehaviour
{
    public GameObject HelpPanel;
    public GameObject HelpImage;
    public GameObject[] ImformationPanel = new GameObject[4];
    private readonly string[] String = { "[침대 헤드]가 [사건일지]에 기록되었습니다.",
    "[스티커]가 [사건일지]에 기록되었습니다", "[금이 간 시계]가 [사건일지]에 기록되었습니다",
    "방 안의 물건을 선택하면 이를 주제로 대화가 가능합니다"};

    // Start is called before the first frame update
    void Start()
    {

    }
    public void DeletePopUp() => EventSystem.current.currentSelectedGameObject.gameObject.SetActive(false);
    public void DeleteParent() => EventSystem.current.currentSelectedGameObject.gameObject.transform.parent.gameObject.SetActive(false);
    public void HelpImageOn() => HelpImage.SetActive(true);
    public void ImformationPanelOnOff()
    {
        foreach (GameObject panel in ImformationPanel)
        {
            if (panel.activeSelf == false) panel.SetActive(true);
            else panel.SetActive(false);
        }
    }
    public void ChangeText(int num)
    {
        foreach(GameObject panel in ImformationPanel) panel.transform.GetChild(0).GetComponent<Text>().text = String[num];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
