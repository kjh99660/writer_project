using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_game : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Camera;
    public void Save_check()
    {
        Camera.transform.position = new Vector3(50, 0, -10);
        Debug.Log("새로 시작하기로 이동");
    }
    public void Start_yes()
    {
        //게임씬으로 이동
        SceneManager.LoadScene("Ingame_scene");
        Debug.Log("게임씬으로 이동");
    }
    public void Start_no()
    {
        Camera.transform.position = new Vector3(0, 0, -10);
        Debug.Log("메인 화면으로 이동");
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
