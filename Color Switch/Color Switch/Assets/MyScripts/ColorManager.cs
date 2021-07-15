using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public string currentColor;
    public SpriteRenderer sr ;

    public Color[] colorArr = new Color[4];
    void Start()
    {
        //sr = gameObject.GetComponent<SpriteRenderer>();
        ColorSelector();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ColorSelector()
    {
        int index = Random.Range(0, 4);
        switch(index)
        {
            case 0:
                currentColor = "Blue";
                sr.color = colorArr[0];
                break;
            case 1:
                currentColor = "Pink";
                sr.color = colorArr[1];
                break;
            case 2:
                currentColor = "Yellow";
                sr.color = colorArr[2];
                break;
            case 3:
                currentColor = "Purple";
                sr.color = colorArr[3];
                break;
        }
    }
}
