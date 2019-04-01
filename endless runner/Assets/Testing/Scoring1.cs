using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Scoring1 : MonoBehaviour {
    public int score = 0;
    public Text scored;
    bool isdead = false;
    public DeathMenu deathmenu;
    private Transform playertransform;
    public Text distance;
    public float distancecovered;
    private float startposition;
    //public PauseMenu pausemenu;
    void Start()
    {
        startposition = 0;
        playertransform = GameObject.FindGameObjectWithTag("Player").transform;
       // InvokeRepeating("spawncoins",5f,2f);
    }

    void Update()
    {
        if (isdead == true)
            return;
        distancecovered = (int)playertransform.localPosition.z - startposition;
        distance.text = "Distance :" + distancecovered.ToString();
        scored.text ="Score :" + score.ToString();
    }
    private void FixedUpdate()
    {
     
    }
    public void Ondeath()
    {
        isdead = true;
        if (PlayerPrefs.GetFloat("Hig") < score)
            PlayerPrefs.SetFloat("Hig", score);

        deathmenu.ToggleEndMenu(score);
    
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coins"))
        {
            
            score += 1;
            other.gameObject.SetActive(false);
        }
    }
}

