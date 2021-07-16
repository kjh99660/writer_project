﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectManager : MonoBehaviour
{
    public Image BlackEffect;
    public Image WhiteEffect;
    public Image BlurEffect;
    private Color BlackOutColor;//페이드 인 아웃
    private Color WhiteOutColor;//플레시
    private Color lightOff = new Color(0f, 0f, 0f, 1f);

    private readonly WaitForSeconds WaitTime = new WaitForSeconds(0.01f);

    public void LightOff()//암전
    {
        BlackEffect.gameObject.SetActive(true);
        BlackEffect.color = lightOff;
    }
    public void FadeOut(float speed = 0.02f)//어두워짐
    {
        StartCoroutine(FadeOutCouroutine(speed));
        Debug.Log("Fade out");
    }
    public void FadeIn(float speed = 0.02f)//밝아짐
    {
        StartCoroutine(FadeInCouroutine(speed));
        Debug.Log("Fade in");
    }
    public void Flash(float speed = 0.05f)//플래쉬
    {
        StartCoroutine(FlashCouroutine(speed));
        Debug.Log("Flash");
    }
    public void Blink()//깜빡임
    {
        StartCoroutine(BlinkCouroutine());
        Debug.Log("Blink");
    }
    public void Blur(bool truefalse) => BlurEffect.gameObject.SetActive(truefalse);
    IEnumerator FadeOutCouroutine(float speed)
    {
        BlackEffect.gameObject.SetActive(true);
        BlackOutColor = BlackEffect.color;

        while (BlackEffect.color.a < 1f)
        {
            BlackOutColor.a += speed;
            BlackEffect.color = BlackOutColor;
            yield return WaitTime;
        }

    }
    IEnumerator FadeInCouroutine(float speed)
    {
        BlackOutColor = BlackEffect.color;

        while (BlackEffect.color.a > 0f)
        {
            BlackOutColor.a -= speed;
            BlackEffect.color = BlackOutColor;
            yield return WaitTime;
        }
        BlackEffect.gameObject.SetActive(false);

    }
    IEnumerator FlashCouroutine(float speed)
    {
        WhiteEffect.gameObject.SetActive(true);
        WhiteOutColor = WhiteEffect.color;

        while (WhiteEffect.color.a < 0.25f)
        {
            WhiteOutColor.a += speed;
            WhiteEffect.color = WhiteOutColor;
            yield return WaitTime;
        }
        while (WhiteEffect.color.a > 0f)
        {
            WhiteOutColor.a -= speed;
            WhiteEffect.color = WhiteOutColor;
            yield return WaitTime;
        }
        WhiteEffect.gameObject.SetActive(false);
    }

    IEnumerator BlinkCouroutine()
    {
        for(int i = 0; i < 2; i++)
        {
            FadeOut(0.08f);
            yield return new WaitForSeconds(0.4f);
            FadeIn(0.08f);
            yield return new WaitForSeconds(0.4f);
        }
        FadeOut();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            Blink();
        if (Input.GetKeyDown(KeyCode.F))
            Flash();
        if (Input.GetKeyDown(KeyCode.F1))
            FadeIn();
        if (Input.GetKeyDown(KeyCode.F2))
            FadeOut();
    }
}
