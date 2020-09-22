using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterKid : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite BasicBasic;
    public Sprite BasicUpArm;
    public Sprite BasicDownArm;
    public Sprite CrossBasic;//시무륵 + 기본팔
    public Sprite CrossUpArm;
    public Sprite CrossDownArm;
    public Sprite HappyBasic;
    public Sprite HappyUpArm;
    public Sprite HappyDownArm;

    private SpriteRenderer SpriteView;

    void Start()
    {
        SpriteView = gameObject.GetComponent<SpriteRenderer>();
        
        //ChangeToBasicBasic();
        //SpriteView.color = new Color();
    }
    //위치 변경
    public void PosToLeft()
    {
        
    }
    public void PosToRight()
    {

    }
    public void PosToCenter()
    {

    }

    //이미지 변경
    public void ChangeToNoting()
    {
        SpriteView.sprite = null;
    }
    public void ChangeToBasicBasic()
    {
        SpriteView.sprite = BasicBasic;
    }
    public void ChangeToBasicUpArm()
    {
        SpriteView.sprite = BasicUpArm;
    }
    public void ChangeToBasicDownArm()
    {
        SpriteView.sprite = BasicDownArm;
    }
    public void ChangeToCrossBasic()
    {
        SpriteView.sprite = CrossBasic;
    }
    public void ChangeToCrossUpArm()
    {
        SpriteView.sprite = CrossUpArm;
    }
    public void ChangeToCrossDownArm()
    {
        SpriteView.sprite = CrossDownArm;
    }
    public void ChangeToHappyBasic()
    {
        SpriteView.sprite = HappyBasic;
    }
    public void ChangeToHappyUpArm()
    {
        SpriteView.sprite = HappyUpArm;
    }
    public void ChangeToHappyDownArm()
    {
        SpriteView.sprite = HappyDownArm;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
