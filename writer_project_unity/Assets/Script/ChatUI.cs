﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatUI : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 targetPos;

    private bool isClose = false;

    void Start()
    {
        startPos = transform.position;
        targetPos = transform.position;
        targetPos.y -= 3.2f;
    }
    public void Changeform()
    {
        if (isClose) isClose = false;
        else isClose = true;
    }

    void Update()
    {
        if(isClose)
        {
            Vector3 velo = Vector3.zero;
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velo, 0.1f);
        }
        else
        {
            Vector3 velo = Vector3.zero;
            transform.position = Vector3.SmoothDamp(transform.position, startPos, ref velo, 0.1f);
        }



    }
}
