using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBoy : CharacterKid
{
    private SpriteRenderer SpriteViewBoy;
    // Start is called before the first frame update
    void Start()
    {
        SpriteViewBoy = gameObject.GetComponent<SpriteRenderer>();
    }
    public override SpriteRenderer GetSpriteView()
    {
        return SpriteViewBoy;
    }

    // Update is called once per frame
    void Update()
    {
        //Kid Update 호출
    }
}
