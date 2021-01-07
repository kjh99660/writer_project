using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Sprite Library;
    [SerializeField]
    private Sprite Hallway;
    [SerializeField]
    private Sprite Hallway_anim;
    [SerializeField]
    private Sprite Kitchen;
    [SerializeField]
    private Sprite LivingRoom;
    [SerializeField]
    private Sprite Bedroom;
    [SerializeField]
    private Sprite Fireplace;
    [SerializeField]
    private Sprite Novel;
    [SerializeField]
    private Sprite Lake;
    [SerializeField]
    private Sprite Cabinet;
    [SerializeField]
    private Sprite CabinetOpen;

    public GameObject Rain_ani;

    private Image SpriteView;

    void Start()
    {
        SpriteView = gameObject.GetComponent<Image>();
    }
    public void ChangeToLake() => SpriteView.sprite = Lake;
    public void ChangeToNovel() => SpriteView.sprite = Novel;
    public void ChangeToLivingRoom() => SpriteView.sprite = LivingRoom;
    public void ChangeToLibrary() => SpriteView.sprite = Library;
    public void ChangeToHallway() => SpriteView.sprite = Hallway;
    public void ChangeToHallway_anim() => SpriteView.sprite = Hallway_anim;
    public void ChangeToKitchen() => SpriteView.sprite = Kitchen;
    public void ChangeToFireplace() => SpriteView.sprite = Fireplace;
    public void ChangeToBedroom() => SpriteView.sprite = Bedroom;
    public void ChangeToCabinet() => SpriteView.sprite = Cabinet;
    public void ChangeToCabinetOpen() => SpriteView.sprite = CabinetOpen;
    // Update is called once per frame
    void Update()
    {
        
    }
}
