using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject SoundPanel;
    public void Setting_in()//인게임에서 사용
    {
        SoundPanel.SetActive(true);
    }
    public void Setting_out()
    {
        SoundPanel.SetActive(false);
    }
    //메인화면 세팅 시 사용하는 메서드들
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
