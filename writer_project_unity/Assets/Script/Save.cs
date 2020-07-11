using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Camera;

    private Ingame_setting Ingame_setting;
    private Image SaveImage01;
    private string FileName;


    void Start()
    {
        Ingame_setting = GameObject.Find("Setting").GetComponent<Ingame_setting>();
        SaveImage01 = GameObject.Find("SaveFile01").GetComponent<Image>();
    }

    public void Save_in()//시작 페이지에서만 사용
    {
        Camera.transform.position = new Vector3(-25, 0, -10);
    }
    public void Save_out()
    {
        Camera.transform.position = new Vector3(0, 0, -10);
    }
    public void ClickSaveImage()
    {
        FileName = "ScreenShot" + Ingame_setting.GetFilenumber();
        SaveImage01.sprite = Resources.Load<Sprite>(FileName) as Sprite;
    }

// Update is called once per frame
void Update()
    {
        
    }
}
