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
    [SerializeField]
    private Sprite ClueWatch;
    [SerializeField]
    private Sprite ClueSticker;
    [SerializeField]
    private Sprite ClueNoSticker;

    public GameObject Rain_ani;

    private Image SpriteView;
    private Image SpriteViewSearch;
    private Image SpriteViewSearchLeft;
    private Image SpriteViewSearchRight;
    /***********************/

    void Start()
    {
        SpriteView = gameObject.GetComponent<Image>();
        SpriteViewSearch = GameObject.Find("BackGroundSearch").GetComponent<Image>();
        SpriteViewSearchLeft = GameObject.Find("BackGroundSearchLeft").GetComponent<Image>();
        SpriteViewSearchRight = GameObject.Find("BackGroundSearchRight").GetComponent<Image>();
    }
    public Image spriteView
    {
        get { return SpriteView; }
    }
    public Image spriteViewSearch
    {
        get { return SpriteViewSearch; }
    }
    public Image spriteViewSearchLeft
    {
        get { return SpriteViewSearchLeft; }
    }
    public Image spriteViewSearchRight
    {
        get { return SpriteViewSearchRight; }
    }

    public void ChangeToLake(Image background) => background.sprite = Lake;
    public void ChangeToNovel(Image background) => background.sprite = Novel;
    public void ChangeToLivingRoom(Image background) => background.sprite = LivingRoom;
    public void ChangeToLibrary(Image background) => background.sprite = Library;
    public void ChangeToHallway(Image background) => background.sprite = Hallway;
    public void ChangeToHallway_anim(Image background) => background.sprite = Hallway_anim;
    public void ChangeToKitchen(Image background) => background.sprite = Kitchen;
    public void ChangeToFireplace(Image background) => background.sprite = Fireplace;
    public void ChangeToBedroom(Image background) => background.sprite = Bedroom;
    public void ChangeToCabinet(Image background) => background.sprite = Cabinet;
    public void ChangeToCabinetOpen(Image background) => background.sprite = CabinetOpen;
    public void ChangeToClueWatch(Image background) => background.sprite = ClueWatch;
    public void ChangeToClueSticker(Image backgtound) => backgtound.sprite = ClueSticker;
    public void ChangeToClueNoSticker(Image background) => background.sprite = ClueNoSticker;
    /***********************/
    // Update is called once per frame
    void Update()
    {
        
    }
}
