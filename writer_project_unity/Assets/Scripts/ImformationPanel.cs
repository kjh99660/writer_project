using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ImformationPanel : MonoBehaviour
{  
    public void ClickImformation()
    {
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;
        clickedButton.SetActive(false);
    }
}
