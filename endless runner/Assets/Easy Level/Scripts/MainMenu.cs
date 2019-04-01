using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public Text Highscore;
    public Text High;
    public Text Hig;
    private void Start()
    {
     Highscore.text = "Easy level Highscore : " +(int)PlayerPrefs.GetFloat("Highscore");
        High.text = "Hard level Highscore : " + (int)PlayerPrefs.GetFloat("High");
        Hig.text = "Medium level Highscore : " + (int)PlayerPrefs.GetFloat("Hig");
    }
    // Start is called before the first frame update
    public void Easy()
    {
        SceneManager.LoadScene("Easy");
    }
    public void Medium()
    {
        SceneManager.LoadScene("Medium");
    }
    // Update is called once per frame
    public void Hard()
    {
        SceneManager.LoadScene("Hard");
    }
}
