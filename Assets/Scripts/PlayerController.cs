using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;

    [SerializeField] float torqueValue = 1f;
    [SerializeField] float boostSpeed = 1f;

    [SerializeField] float baseSpeed = 1f;
    SurfaceEffector2D surfaceEffector2D;
    bool canMove = true;

    //float jumpForce; 
    void Start()
    {
       rb2d = GetComponent<Rigidbody2D>();
       surfaceEffector2D=FindObjectOfType<SurfaceEffector2D>();
       baseSpeed = surfaceEffector2D.speed;
    
    }
        void Update()
    {
        if(canMove)
        {
            rotatePlayer();
            RespondToBoost();
        }

    }
   // void OnCollisionStay2D(Collision2D other) 
   //{
   //     if(other.gameObject.tag=="Ground"!=true)
   //     {
   //         jumpForce = -1f;
   //     }
   //     else
   //     {
   //         jumpForce = 10f;
   //     }
        
   // }
   void RespondToBoost()
   {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
   }
    void rotatePlayer()
    {
        
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueValue);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueValue);
        }
    //    if (Input.GetButtonDown("Jump"))
    //    {
    //        rb2d.AddForce(transform.up*jumpForce, ForceMode2D.Impulse);
    //    }
    }
    public void disableController()
    {
        canMove = false;
    }
}
