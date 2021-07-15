using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collider : MonoBehaviour
{
    public ColorManager cm;
    public Scenemanager sm;
    public SpriteRenderer srp;
    public SpriteRenderer src;

    private void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D otherCol)
    {
        if(otherCol.tag == "ColorChanger")
        {
            cm.ColorSelector();
            //srp.color = src.color;
            Destroy(otherCol.gameObject);
            return;
        }
       if(otherCol.tag != cm.currentColor)
        {
            sm.SceneChanger();
        }
       if(otherCol.tag == "finish")
        {
            sm.sceneChanger();
        }
    }
}
