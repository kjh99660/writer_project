using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Camera;

    void Start()
    {

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

    }

// Update is called once per frame
void Update()
    {
        
    }
}
