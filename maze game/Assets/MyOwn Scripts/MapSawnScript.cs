using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSawnScript : MonoBehaviour
{
    [SerializeField]
    private Transform playerPos;
    [SerializeField]
    private Transform offScreenPos;
    public float speed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
        }
    }
    
}
