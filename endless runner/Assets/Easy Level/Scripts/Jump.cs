using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private float jumpheight = 50f;
    public Transform Player;
    bool isJumped = false;
    public void Jumps()
    {

       // if (isJumped == false)
      //  {
            Player.transform.Translate(Vector3.up * jumpheight * Time.deltaTime);
            //isJumped = true;
           // Debug.Log("jumptrue");
     //   }
        // rb.AddForce( jumpHeight * transform.up);
    }

}
