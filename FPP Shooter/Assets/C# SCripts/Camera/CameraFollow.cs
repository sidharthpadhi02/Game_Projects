using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform  player;

    public float smoothSpeed = 0.125f;
   // float rotationSpeed = 1;


    public Vector3 offset;

 
   //float mouseX, mouseY;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothPosition;

        transform.LookAt(player);

    }
  
}

