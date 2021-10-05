using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private Rigidbody rb;
    private CameraFollow cameraFollow;
    private bool playerDied;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cameraFollow = Camera.main.GetComponent<CameraFollow>();

        
    }
     void Update()
    {
        if (!playerDied)
        {
            if(rb.velocity.sqrMagnitude> 60)
            {
                playerDied = true; 
                cameraFollow.CanFollow = false;
                SoundManager.instance.GameEndSound();
                GameplayController.instance.RestartGame();
            }
        }
    }//update
     void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Coin")
        {
            SoundManager.instance.PickedUpCoin();
            GameplayController.instance.IncrementScore();
            target.gameObject.SetActive(false);
        }
        if(target.tag == "Spike")
        {
            cameraFollow.CanFollow = false;
            gameObject.SetActive(false);
            SoundManager.instance.GameEndSound();
            GameplayController.instance.RestartGame();
        }

    }
    void OnCollisionEnter(Collision target)
    {
        if(target.gameObject.tag == "EndPlatform")
        {
            SoundManager.instance.GameStartSound();
            GameplayController.instance.RestartGame();
        }

    }


}//class

