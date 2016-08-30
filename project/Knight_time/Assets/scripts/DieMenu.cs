using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DieMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RestartGame()
    {
        SceneManager.LoadScene("test");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
