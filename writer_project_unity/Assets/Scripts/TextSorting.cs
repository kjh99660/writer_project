using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSorting : MonoBehaviour
{
    // Start is called before the first frame update
    public string sortingLayerName;
    public int sortingOrder;

    void Start()
    {
        MeshRenderer mesh = GetComponent<MeshRenderer>();
        mesh.sortingLayerName = sortingLayerName;
        mesh.sortingOrder = sortingOrder;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
