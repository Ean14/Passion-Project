using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thumb : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite ncs1;
    public GameObject image;

    void Start()
    {
        image.GetComponent<Image>().sprite = ncs1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
