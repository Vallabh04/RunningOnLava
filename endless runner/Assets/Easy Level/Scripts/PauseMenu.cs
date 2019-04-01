using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour
{
 
    public Text scored;
    void Start()
    {
        
    }

    
   public void pausemenu(float score)
    { 
            gameObject.SetActive(true);
            score += Time.deltaTime;
            scored.text = ((int)score).ToString();
    }
    public void resume()
    {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
    }
}
