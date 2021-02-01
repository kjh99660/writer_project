using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    public GameObject PopUpBackGround;
    public GameObject Watch;
    public GameObject Sticker;
    public GameObject PanelForHideText;

    /***************************///선택지
    public GameObject ChoiceObject;
    [SerializeField]
    private GameObject ChoiceFirst, ChoiceSecond, ChoiceThird;
    private Text FirstText, SecondText, ThirdText;

    private readonly string[] ChoiceString = new string[] { "비스로트수작", "비스트로수작", "비스토르수작" };
    private int Answer = 0;
    void Start()
    {
        FirstText = ChoiceFirst.transform.GetChild(0).GetComponent<Text>();
        SecondText = ChoiceSecond.transform.GetChild(0).GetComponent<Text>();
        ThirdText = ChoiceThird.transform.GetChild(0).GetComponent<Text>();
    }
    public void TurnOnOffObject(GameObject Panel, GameObject Object, bool OnOff)
    {
        Panel.SetActive(OnOff);
        Object.SetActive(OnOff);
    }
    public void Choice(int number)
    {
        FirstText.text = ChoiceString[3 * number - 3];
        SecondText.text = ChoiceString[3 * number - 2];
        ThirdText.text = ChoiceString[3 * number - 1];
        ChoiceObject.SetActive(true);
        PanelForHideText.SetActive(true);
    }
    public int GetChoiceAnswer()
    {
        return Answer;
    }
    /*************************/
    public void ChoiceFirstButton()
    {
        Answer = 1;
        ChoiceObject.SetActive(false);
        PanelForHideText.SetActive(false);
    }
    public void ChoiceSecondButton()
    {
        Answer = 2;
        ChoiceObject.SetActive(false);
        PanelForHideText.SetActive(false);
    }
    public void ChoiceThirdButton()
    {
        Answer = 3;
        ChoiceObject.SetActive(false);
        PanelForHideText.SetActive(false);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
