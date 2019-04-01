using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu1 : MonoBehaviour
{
    public GameObject pausemenu;
    bool ispaused = false;

    public void Pause()
    {
        pausemenu.gameObject.SetActive(true);
        ispaused = true;
        Time.timeScale = 0.0f;
        AudioListener.volume = 0;
    }
    public void Resume()
    {
        pausemenu.gameObject.SetActive(false);
        ispaused = false;
        Time.timeScale = 1.0f;
        AudioListener.volume = 1;
    }
    public void stopsound()
    {
        if (AudioListener.pause == true)
        {
            AudioListener.pause = false;
        }
        else
        {
            AudioListener.pause = true;
        }
    }

}
