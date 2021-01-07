using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBoy : CharacterKid
{
    private Image SpriteViewBoy;
    // Start is called before the first frame update
    void Start()
    {
        SpriteViewBoy = gameObject.GetComponent<Image>();
        On = new Color(1f, 1f, 1f, 0f);
        Off = new Color(1f, 1f, 1f, 1f);
    }
    public override Image GetSpriteView()
    {
        return SpriteViewBoy;
    }

    // Update is called once per frame
    void Update()
    {
        //Kid Update 호출
    }
}
