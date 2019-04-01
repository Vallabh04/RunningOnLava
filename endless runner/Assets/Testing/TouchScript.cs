using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScript : MonoBehaviour
{
    private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private bool isDraging = false;
    private Vector2 startTouch, swipeDelta;

    public Vector2 SwipeDelta { get { return swipeDelta; } }

    public bool Tap { get {return tap; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }


    private void Update()
    {
        tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;

        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            isDraging = true;
            tap = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonDown(1))
        {
            isDraging = false;
            Reset();
        }
        #endregion


        #region Mobile Inputs

        if (Input.touches.Length > 0) {

            if (Input.touches[0].phase == TouchPhase.Began)
            {
                isDraging = true;
                tap = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled) {
                isDraging = false;
                Reset();
            }
        }
        #endregion

        //Calculate the distance
        swipeDelta = Vector2.zero;
        if (isDraging)
        {
            if (Input.touches.Length > 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            else if (Input.GetMouseButton(0))
            {
                //Debug.Log(((Vector2)Input.mousePosition) + " " + startTouch);
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }

        // if we crossed the deadzone
        if (swipeDelta.magnitude > 90)
        {
            //which direction
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                
                //left or right
                if (x < 0)
                {
                  //  Debug.Log("L " + Mathf.Abs(x) + " " + Mathf.Abs(y));
                    swipeLeft = true;

                }else {
                  //  Debug.Log("R " + Mathf.Abs(x) + " " + Mathf.Abs(y));
                    swipeRight = true;
                }
            }
            else {
                //Up or Down
                if (y < 0)
                {
                   // Debug.Log("D " + Mathf.Abs(x) + " " + Mathf.Abs(y));
                    swipeDown = true;
                }
                else {
                  //  Debug.Log("U " + Mathf.Abs(x) + " " + Mathf.Abs(y));
                    swipeUp = true;
                }
            }

            Reset();
        }


    }


    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }

}
