using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Help : MonoBehaviour
{
    public GameObject HelpPanel;
    public GameObject HelpImage;
    [SerializeField]
    private Text Text;
    private string[] String = { "[침대 헤드]에 대한 단서를 [사건기록파일]에 수집했습니다." };
    [Range (0,1)]
    private int Num = 0;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void DeletePopUp()
    {
        EventSystem.current.currentSelectedGameObject.gameObject.SetActive(false);
    }
    public void DeleteParent()
    {
        EventSystem.current.currentSelectedGameObject.gameObject.transform.parent.gameObject.SetActive(false);
    }
    public void HelpImageOn()
    {
        HelpImage.SetActive(true);
    }
    public void ChangeText()
    {
        Text.text = String[Num];
        Num++;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
