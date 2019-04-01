using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playerinput2 : MonoBehaviour
{
    public TouchScript touchControls;
    public static bool isJump;
    public static bool jumpTrigger;
    public static bool iscrouch;
    public static bool crouchtrigger;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float crouchheight;
    public float movementspeed;
    private Vector3 direction;
    public GameObject pu;
    public GameObject setfalse;
    public GameObject setopen;
    private Scoring scoring;
  // public GameObject Keytonextscene;
    Rigidbody rb;
    Animator anim;
    bool isdead = false;
    private Transform playertransform;
    public float horiforce;
    public GameObject prefab;
    private void Start()
    {
        playertransform = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        isJump = false;
        jumpTrigger = false;
        iscrouch = false;
        crouchtrigger = false;
    }

    private void Update()
    {
        if (jumpTrigger && !isJump)
        {
            this.transform.Translate(Vector3.up * jumpHeight * Time.deltaTime);
            isJump = true;
            anim.SetBool("IsOnGround", true);
        }
        if (crouchtrigger &&!iscrouch || Input.GetKey(KeyCode.C)||touchControls.SwipeDown)
            {
            Debug.Log(crouchtrigger);
            this.transform.Translate(Vector3.down * crouchheight * Time.deltaTime);
        }
        if(touchControls.SwipeUp)
        {
            jumpTrigger = true;
        }
            if ((Input.GetKey(KeyCode.J)))
        {
            jumpTrigger = true;
        }
        if (touchControls.SwipeLeft)
        {
            transform.Translate(Vector3.left * horiforce);
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * horiforce);
        }

        if (touchControls.SwipeRight)
        {
            transform.Translate(Vector3.right * horiforce);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * horiforce);
        }
        pu = GameObject.FindGameObjectWithTag("PowerUp").gameObject;
        setfalse = GameObject.FindGameObjectWithTag("False").gameObject;
        setopen = GameObject.FindGameObjectWithTag("Open").gameObject;
    
    }
    private void FixedUpdate()
    {
        if (isdead == true)
        {
            return;
        }

        if(transform.position.x >5.00 || transform.position.x <-5.00)
        {
            Death();
            GameObject range = Instantiate(prefab, playertransform.transform.localPosition + new Vector3(0, 0, 15), Quaternion.identity) as GameObject;
        }
        if (transform.position.x == 5.00 || transform.position.x ==-5.00)
        {
            GameObject range = Instantiate(prefab, playertransform.transform.localPosition + new Vector3(0, 0, 5), Quaternion.identity) as GameObject;
        }
   
        rb.velocity = new Vector3(0, 0, movementspeed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            Death();
            
        }
        if(collision.gameObject.CompareTag("PowerUp"))
        {
            movementspeed += 2;
           pu.SetActive(false);
        }
        if(collision.gameObject.CompareTag("Open"))
        {
            setfalse.gameObject.SetActive(false);
            setopen.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Coins"))
        {
            movementspeed += 2;
            pu.SetActive(false);
        }
        /*  if(collision.gameObject.CompareTag("Key"))
          {
              SceneManager.LoadScene("GoToThisWhenTaken");
          }*/
    }
    public void Reset()
    {
        anim.SetBool("IsOnGround", false);
    }
    public void Jump()
    {
        jumpTrigger = true;
    }
    public void Death()
    {
        isdead = true;
        GetComponent<Scoring2>().Ondeath();
        Destroy(this.gameObject);
    }
}
