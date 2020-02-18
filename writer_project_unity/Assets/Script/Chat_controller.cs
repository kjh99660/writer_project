using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chat_controller : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Name;
    public Text Text;
    IEnumerator Chatting(string narrator, string narration)
    {
        Name.text = narrator;
        string writertext = "";
        for(int i=0; i< narration.Length;i++)
        {
            writertext += narration[i];
            Text.text = writertext;
            yield return null;
        }
    }
    IEnumerator Texting()
    {
        yield return StartCoroutine(Chatting("주인공", "대사 출력 구현하기 연습 중"));
    }
    void Start()
    {
        StartCoroutine(Texting());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
