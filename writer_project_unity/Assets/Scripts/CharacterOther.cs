using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterOther : MonoBehaviour
{
    public Sprite Amber;
    public Sprite Lilly;
    public Sprite Olivia;
    public Sprite Abigail;
    private Image SpriteView;
    private Color On;
    private Color Off;
    // Start is called before the first frame update
    void Start()
    {
        SpriteView = gameObject.GetComponent<Image>();
        On = new Color(1f, 1f, 1f, 0f);
        Off = new Color(1f, 1f, 1f, 1f);
    }
    public Image GetSpriteView()
    {
        return SpriteView;
    }
    public void ChangeToNoting(Image SpriteView)
    {
        SpriteView.color = On;
    }
    public void ChangeToAmber(Image SpriteView)
    {
        SpriteView.color = Off;
        SpriteView.sprite = Amber;
    }
    public void ChangeToLilly(Image SpriteView)
    {
        SpriteView.color = Off;
        SpriteView.sprite = Lilly;
    }
    public void ChangeToOlivia(Image SpriteView)
    {
        SpriteView.color = Off;
        SpriteView.sprite = Olivia;
    }
    public void ChangeToAbigail(Image SpriteView)
    {
        SpriteView.color = Off;
        SpriteView.sprite = Abigail;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
