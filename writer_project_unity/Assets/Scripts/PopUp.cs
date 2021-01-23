using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    public GameObject PopUpBackGround;
    public GameObject Watch;
    public GameObject Sticker;
    void Start()
    {
        
    }
    public void TurnOnOffObject(GameObject Panel, GameObject Object, bool OnOff)
    {
        Panel.SetActive(OnOff);
        Object.SetActive(OnOff);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
