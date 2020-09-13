using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public SpriteRenderer BlackEffect;
    public SpriteRenderer WhiteEffect;
    private Color BlackOutColor;//페이드 인 아웃
    private Color WhiteOutColor;//플레시

    private WaitForSeconds waitTime = new WaitForSeconds(0.01f);

    public void FadeOut(float speed = 0.02f)
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
            yield return waitTime;
        }

    }

    public void FadeIn(float speed = 0.02f)
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
            yield return waitTime;
        }

    }
    public void Flash(float speed = 0.1f)
    {
        StartCoroutine(FlashCouroutine(speed));
        Debug.Log("Flash");
    }
    IEnumerator FlashCouroutine(float speed)
    {
        WhiteOutColor = WhiteEffect.color;

        while (WhiteEffect.color.a < 1f)
        {
            WhiteOutColor.a += speed;
            WhiteEffect.color = WhiteOutColor;
            yield return waitTime;
        }
        while (WhiteEffect.color.a > 0f)
        {
            WhiteOutColor.a -= speed;
            WhiteEffect.color = WhiteOutColor;
            yield return waitTime;
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
    }
}
