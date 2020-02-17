using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Exit_panel;

    public void Exit_paenl()
    {
        Exit_panel.SetActive(true);
        Debug.Log("종료창 활성화");
    }
    public void Exit_game()
    {
        Application.Quit();
        Debug.Log("게임 종료");
    }
    public void Exit_paneloff()
    {
        Exit_panel.SetActive(false);
        Debug.Log("종료창 비활성화");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
