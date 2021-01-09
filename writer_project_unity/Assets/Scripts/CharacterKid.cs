using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private Image SpriteView;
    protected Color On;
    protected Color Off;

    void Start()
    {
        SpriteView = gameObject.GetComponent<Image>();
        On = new Color(1f, 1f, 1f, 0f);
        Off = new Color(1f, 1f, 1f, 1f);
    }

    public virtual Image GetSpriteView()
    {
        return SpriteView;
    }

    //이미지 변경
    public virtual void ChangeToNoting(Image SpriteView)
    {
        SpriteView.color = On;
    }
    public virtual void ChangeToBasicBasic(Image SpriteView)
    {
        SpriteView.color = Off;
        SpriteView.sprite = BasicBasic;
    }
    public virtual void ChangeToBasicUpArm(Image SpriteView)
    {
        SpriteView.color = Off;
        SpriteView.sprite = BasicUpArm;
    }
    public virtual void ChangeToBasicDownArm(Image SpriteView)
    {
        SpriteView.color = Off;
        SpriteView.sprite = BasicDownArm;
    }
    public virtual void ChangeToCrossBasic(Image SpriteView)
    {
        SpriteView.color = Off;
        SpriteView.sprite = CrossBasic;
    }
    public virtual void ChangeToCrossUpArm(Image SpriteView)
    {
        SpriteView.color = Off;
        SpriteView.sprite = CrossUpArm;
    }
    public virtual void ChangeToCrossDownArm(Image SpriteView)
    {
        SpriteView.color = Off;
        SpriteView.sprite = CrossDownArm;
    }
    public virtual void ChangeToHappyBasic(Image SpriteView)
    {
        SpriteView.color = Off;
        SpriteView.sprite = HappyBasic;
    }
    public virtual void ChangeToHappyUpArm(Image SpriteView)
    {
        SpriteView.color = Off;
        SpriteView.sprite = HappyUpArm;
    }
    public virtual void ChangeToHappyDownArm(Image SpriteView)
    {
        SpriteView.color = Off;
        SpriteView.sprite = HappyDownArm;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
