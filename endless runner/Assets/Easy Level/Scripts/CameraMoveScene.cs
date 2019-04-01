using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveScene : MonoBehaviour {

    private Transform LookAt;
    private Vector3 offest;
    private Vector3 movevector;
    private float transition;
    private float animatonduration = 2.0f;
    private Vector3 animationoffset = new Vector3(0, 5, 5);
	// Use this for initialization
	void Start () {
       LookAt =  GameObject.FindGameObjectWithTag("Player").transform;
        offest = transform.position - LookAt.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = LookAt.position + offest;

      //  movevector.x =0;

      //  movevector.z = Mathf.Clamp(movevector.z, 3, 5);
       /* transform.position = movevector;

         if(transition > 1.0f)
          {
              transform.position = movevector;
          }
          else
          {
              transform.position = Vector3.Lerp(movevector + animationoffset, movevector, transition);

            transition += Time.deltaTime * 1 / animatonduration;
              transform.LookAt(LookAt.position + Vector3.up);
          }*/
    }
}