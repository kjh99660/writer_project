using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gallery : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Camera;
    public void Gallery_in()
    {
        Camera.transform.position = new Vector3(25, 0, -10);
        Debug.Log("갤러리 들어감");
    }
    public void Gallery_out()
    {
        Camera.transform.position = new Vector3(0, 0, -10);
        Debug.Log("갤러리 나감");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
