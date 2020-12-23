using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public SpriteRenderer BlackEffect;
    public SpriteRenderer WhiteEffect;
    private Color BlackOutColor;//페이드 인 아웃
    private Color WhiteOutColor;//플레시
    private Color lightOff = new Color(0f, 0f, 0f, 1f);

    private readonly WaitForSeconds WaitTime = new WaitForSeconds(0.01f);

    public void LightOff()//암전
    {
        BlackEffect.color = lightOff;
    }

    public void FadeOut(float speed = 0.02f)//어두워짐
    {
        StartCoroutine(FadeOutCouroutine(speed));
        Debug.Log("Fade out");
    }
    IEnumerator FadeOutCouroutine(float speed)
    {
        BlackOutColor = BlackEffect.color;

        while(BlackEffect.color.a < 1f)
        {
            BlackOutColor.a += speed;
            BlackEffect.color = BlackOutColor;
            yield return WaitTime;
        }

    }

    public void FadeIn(float speed = 0.02f)//밝아짐
    {
        StartCoroutine(FadeInCouroutine(speed));
        Debug.Log("Fade in");
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

    }
    public void Flash(float speed = 0.05f)
    {
        StartCoroutine(FlashCouroutine(speed));
        Debug.Log("Flash");
    }
    IEnumerator FlashCouroutine(float speed)
    {
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
    }

    IEnumerator FadeCouroutine()
    {
        FadeOut();
        yield return new WaitForSeconds(1f);
        FadeIn();
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
            StartCoroutine(FadeCouroutine());
        if (Input.GetKeyDown(KeyCode.F))
            Flash();
        if (Input.GetKeyDown(KeyCode.F1))
            FadeIn();
        if (Input.GetKeyDown(KeyCode.F2))
            FadeOut();
    }
}
