using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

    public float speed;

    public float unitLength;

    private float tomove;

	// Use this for initialization
	void Start () {
	  tomove = speed / 60.0f;
    }
	
	// Update is called once per frame
	void Update () {
        //fish are food not friends
        
    }


}
