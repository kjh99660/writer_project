using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatUI : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 targetPos;

    public GameObject textUI;

    private bool isClose = false;


    void Start()
    {
        startPos = textUI.transform.position;
        targetPos = textUI.transform.position;
        targetPos.y -= 3.9f;
    }
    public void Changeform()
    {
        Debug.Log("changeform");
        if (isClose) isClose = false;
        else isClose = true;
    }
    public bool ReturnisClose()
    {
        return isClose;
    }

    void Update()
    {
        if(isClose)
        {
            Vector3 velo = Vector3.zero;
            textUI.transform.position = Vector3.SmoothDamp(textUI.transform.position, targetPos, ref velo, 0.05f);
        }
        else
        {
            Vector3 velo = Vector3.zero;
            textUI.transform.position = Vector3.SmoothDamp(textUI.transform.position, startPos, ref velo, 0.05f);
        }



    }
}
