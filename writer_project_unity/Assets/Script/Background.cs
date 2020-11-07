using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite Library;
    public Sprite Hallway;
    public Sprite Hallway_anim;
    public Sprite Kitchen;
    public Sprite LivingRoom;
    public Sprite Bedroom;
    public Sprite Fireplace;

    public GameObject Rain_ani;

    private SpriteRenderer SpriteView;

    void Start()
    {
        SpriteView = gameObject.GetComponent<SpriteRenderer>();
        ChangeToLibrary();
    }
    public void ChangeToLivingRoom()
    {
        SpriteView.sprite = LivingRoom;
    }
    public void ChangeToLibrary()
    {
        SpriteView.sprite = Library;
    }
    public void ChangeToHallway()
    {
        SpriteView.sprite = Hallway;
    }
    public void ChangeToHallway_anim()
    {
        SpriteView.sprite = Hallway_anim;
    }
    public void ChangeToKitchen()
    {
        SpriteView.sprite = Kitchen;
    }
    public void ChangeToFireplace()
    {
        SpriteView.sprite = Fireplace;
    }
    public void ChangeToBedroom()
    {
        SpriteView.sprite = Bedroom;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
