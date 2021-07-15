using UnityEngine;

public class MyPlayer : MonoBehaviour
{
    public float myJump = 10f;
    private Rigidbody2D myBody;
    private void Start()
    {
        myBody = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            myBody.velocity = Vector2.up * myJump;
        }
    }
}
