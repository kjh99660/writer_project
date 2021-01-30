using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Sprite Library, Hallway, Hallway_anim;
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
    private Sprite AmberHouse;
    [SerializeField]
    private Sprite Street;
    [SerializeField]
    private Sprite FlowerShop;
    [SerializeField]
    private Sprite Cabinet, CabinetOpen;
    [SerializeField]
    private Sprite ClueSticker, ClueNoSticker, ClueWatch;
    [SerializeField]
    private Sprite AbigailHouse;
    [SerializeField]
    private Sprite Bus;

    public GameObject Rain_ani;
    public Image SpriteView { get; private set; }
    public Image SpriteViewSearch { get; private set; }
    public Image SpriteViewSearchLeft { get; private set; }
    public Image SpriteViewSearchRight { get; private set; }
    /***********************/
    void Start()
    {
        SpriteView = gameObject.GetComponent<Image>();
        SpriteViewSearch = GameObject.Find("BackGroundSearch").GetComponent<Image>();
        SpriteViewSearchLeft = GameObject.Find("BackGroundSearchLeft").GetComponent<Image>();
        SpriteViewSearchRight = GameObject.Find("BackGroundSearchRight").GetComponent<Image>();
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
    public void ChangeToAmberHouse(Image background) => background.sprite = AmberHouse;
    public void ChangeToStreet(Image background) => background.sprite = Street;
    public void ChangeToFlowerShop(Image background) => background.sprite = FlowerShop;
    public void ChangeToAbigailHouse(Image background) => background.sprite = AbigailHouse;
    public void ChangeToBus(Image background) => background.sprite = Bus;
    /***********************/
    // Update is called once per frame
    void Update()
    {
        
    }
}
