using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onground : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
           playerinput.isJump = false;
            playerinput.jumpTrigger = false;
            playerinput.iscrouch = false;
            playerinput.crouchtrigger = false;
            playerinput1.isJump = false;
            playerinput1.jumpTrigger = false;
            playerinput2.isJump = false;
            playerinput2.jumpTrigger = false;
            collision.gameObject.GetComponent<playerinput>().Reset();
        }
    }
}
