using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float movementForce = 0.5f, jumpForce = 0.15f, jumpTime = 0.15f;
    private bool isOnPlatform;
   
     void Awake()
    {
        rb = GetComponent<Rigidbody>();    
    }

   
    void Update()
    {
        getInput();
        
    }
    void getInput()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Jump(true);
        }
        else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
            Jump(false);
        }
         
    }//get input
    void Jump(bool isLeft)
    {
        SoundManager.instance.JumpSound();
        if (isLeft && isOnPlatform)
        {
            isOnPlatform = false;
            transform.DORotate(new Vector3(0f, 90f, 0f), 0f);//we rotate the player 90' 
            transform.DOJump(new Vector3(transform.position.x - movementForce, transform.position.y + jumpForce,
                transform.position.z
                ), 0.5f, 1, jumpTime);
            
        }
        if(!isLeft && isOnPlatform)
        {
            isOnPlatform = false;
            transform.DORotate(new Vector3(0f, -180f, 0f), 0f);//we rotate the play -180f
            transform.DOJump(new Vector3(transform.position.x , transform.position.y + jumpForce,
                transform.position.z+movementForce
                ), 0.5f, 1, jumpTime);

        }

    }//jump
     void OnCollisionEnter(Collision target)
    {
        if(target.gameObject.tag == "Platform")
        {
            isOnPlatform = true;
        }
    }



}//class
