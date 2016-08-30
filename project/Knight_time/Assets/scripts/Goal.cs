using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Goal : MonoBehaviour {

    public string level; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	  
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name =="FPSController")
        {
            SceneManager.LoadScene(level);
        }
    }
}
