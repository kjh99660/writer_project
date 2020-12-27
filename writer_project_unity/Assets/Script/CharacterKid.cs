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

    public virtual SpriteRenderer GetSpriteView()
    {
        return SpriteView;
    }

    //이미지 변경
    public virtual void ChangeToNoting(SpriteRenderer SpriteView)
    {
        SpriteView.sprite = null;
    }
    public virtual void ChangeToBasicBasic(SpriteRenderer SpriteView)
    {
        SpriteView.sprite = BasicBasic;
    }
    public virtual void ChangeToBasicUpArm(SpriteRenderer SpriteView)
    {
        SpriteView.sprite = BasicUpArm;
    }
    public virtual void ChangeToBasicDownArm(SpriteRenderer SpriteView)
    {
        SpriteView.sprite = BasicDownArm;
    }
    public virtual void ChangeToCrossBasic(SpriteRenderer SpriteView)
    {
        SpriteView.sprite = CrossBasic;
    }
    public virtual void ChangeToCrossUpArm(SpriteRenderer SpriteView)
    {
        SpriteView.sprite = CrossUpArm;
    }
    public virtual void ChangeToCrossDownArm(SpriteRenderer SpriteView)
    {
        SpriteView.sprite = CrossDownArm;
    }
    public virtual void ChangeToHappyBasic(SpriteRenderer SpriteView)
    {
        SpriteView.sprite = HappyBasic;
    }
    public virtual void ChangeToHappyUpArm(SpriteRenderer SpriteView)
    {
        SpriteView.sprite = HappyUpArm;
    }
    public virtual void ChangeToHappyDownArm(SpriteRenderer SpriteView)
    {
        SpriteView.sprite = HappyDownArm;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
