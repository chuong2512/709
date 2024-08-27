using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class sample : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Height, Width;
    void Start()
    {
        DisplayInfo();
    }
    void DisplayInfo()
    {
        Height.text = "Height is " + Screen.height;
        Width.text = "Width is " + Screen.width;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
