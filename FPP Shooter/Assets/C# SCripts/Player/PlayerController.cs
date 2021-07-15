using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public Transform player;
    public float speed = 5.0f;
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;

    public Transform circle;
    public Transform outerCircle;
    //public Animator anim;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            pointA = Camera.main.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Camera.main.transform.position.y, Input.mousePosition.z));

            circle.transform.position = pointA * -1;
            outerCircle.transform.position = pointA * -1;
        }

        if(Input.GetMouseButton(0))
        {
            touchStart = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Camera.main.transform.position.y, Input.mousePosition.z));

        }
        else
        {
            touchStart = false;
        }
    }
    private void FixedUpdate()
    {
        if(touchStart)
        {
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            MoveCharacter(direction * -1);

            circle.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y) * -1;

        }
        
    }
    void MoveCharacter(Vector2 direction)
    {
        player.Translate(direction * speed * Time.deltaTime);
        player.GetComponent<Animator>().Play("Sword_M_Run_01");
    }


}
