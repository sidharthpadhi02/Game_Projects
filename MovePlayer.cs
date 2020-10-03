using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody myBody;
    public float moveForce = 10f;
    public float turnSmoothVelocity ;
    public float turnSmoothTime = 0.1f;

    public Camera cam;

    public FixedJoystick joystick;


    public Interactables focus;
    private Actions anim;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        joystick = GameObject.FindWithTag("Joystick").GetComponent<FixedJoystick>();
        anim = GetComponent<Actions>();

        
        
        
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //we create a ray
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //if the ray hits;
            if(Physics.Raycast(ray,out hit, 100))
            {
                //check if we hit an interactable
                Interactables interact = hit.collider.GetComponent<Interactables>();
                if(interact != null)
                {
                    //setfocus on the interactable
                    SetFocus(interact);
                    //collect it
                }
            }
        }
    }
    private void FixedUpdate()
    {
       
        myBody.velocity = new Vector3(-joystick.Horizontal * moveForce*Time.fixedDeltaTime,
                                       myBody.velocity.y, -joystick.Vertical * moveForce*Time.fixedDeltaTime);



        if(joystick.Horizontal !=0 || joystick.Vertical !=0 )
        {
            //myBody.constraints = RigidbodyConstraints.FreezePositionY| RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            anim.Run(true);

            float targetAngle = Mathf.Atan2(myBody.velocity.x, myBody.velocity.z) * Mathf.Rad2Deg ;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            //transform.rotation = Quaternion.LookRotation(myBody.velocity);

            RemoveFocus();
        }
        else
        {
            //myBody.constraints &= ~RigidbodyConstraints.FreezePositionY;
            anim.Run(false);
        }
   
    }

   void SetFocus(Interactables newFocus)
    {
        if(newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();
            
            
            focus = newFocus;
 
        }
        
        newFocus.OnFocused(transform);
    }
    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();
       
        focus = null;
    }
}
