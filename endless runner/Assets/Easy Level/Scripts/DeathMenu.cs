using UnityEngine;

using UnityEngine.UI;

public class DeathMenu : MonoBehaviour {
  //  public GameObject pausemenu;
    public Button pausemenu;
    public Text scored;

    void Start () {
     
	}
	
	void Update () {
		
	}

    public void ToggleEndMenu(int score)
    {
        gameObject.SetActive(true);
        pausemenu.gameObject.SetActive(false);
        score = (int)Time.timeSinceLevelLoad;
        scored.text = "Score :" + (score).ToString();
    }

}
