using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Camera;
    public void Setting_in()
    {
        Camera.transform.position = new Vector3(-50, 0, -10);
    }
    public void Setting_out()
    {
        Camera.transform.position = new Vector3(0, 0, -10);
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
