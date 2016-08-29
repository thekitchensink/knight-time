using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

    public GameObject walls;

    public float speed;

    public float unitLength;

    private float tomove;
    private float moving;

    private Vector3 movement;
    private Vector3 last;

	// Use this for initialization
	void Start () {
        last = gameObject.transform.position;
      moving = unitLength;
	  tomove = speed / 60.0f;
    }
	
	// Update is called once per frame
	void Update () {
        //fish are food not friends

        if(moving >= unitLength)
        {
            gameObject.transform.position = last + movement * unitLength;
            last = gameObject.transform.position;
            movement = findWay();
            moving = 0.0f;
        }
        else
        {
            gameObject.transform.position += movement * tomove;
            moving += tomove;
        }
    }

    private Vector3 findWay()
    {
        int num = 0;
        Vector3[] vecs = new Vector3[4];

        RaycastHit hit;

        if(Physics.Raycast(transform.position, new Vector3(1.0f, 0.0f, 0.0f), out hit, unitLength))
        {
            if (!hit.collider.gameObject.GetComponent<DestroyWall>())
                vecs[num++] = new Vector3(1.0f, 0.0f, 0.0f);
        }
        else
        {
            vecs[num++] = new Vector3(1.0f, 0.0f, 0.0f);
        }

        if (Physics.Raycast(transform.position, new Vector3(-1.0f, 0.0f, 0.0f), out hit, unitLength))
        {
            if (!hit.collider.gameObject.GetComponent<DestroyWall>())
                vecs[num++] =  new Vector3(-1.0f, 0.0f, 0.0f);
        }
        else
        {
            vecs[num++] = new Vector3(-1.0f, 0.0f, 0.0f);
        }

        if (Physics.Raycast(transform.position, new Vector3(0.0f, 0.0f, 1.0f), out hit, unitLength))
        {
            if (!hit.collider.gameObject.GetComponent<DestroyWall>())
                vecs[num++] = new Vector3(0.0f, 0.0f, 1.0f);
        }
        else
        {
            vecs[num++] = new Vector3(0.0f, 0.0f, 1.0f);
        }

        if (Physics.Raycast(transform.position, new Vector3(0.0f, 0.0f, -1.0f), out hit, unitLength))
        {
            if (!hit.collider.gameObject.GetComponent<DestroyWall>())
                vecs[num++] = new Vector3(0.0f, 0.0f, -1.0f);
        }
        else
        {
            vecs[num++] = new Vector3(0.0f, 0.0f, -1.0f);
        }

        int ep = Random.Range(0, num - 1);
        Vector3 toReturn = vecs[ep];
        
        return toReturn;
    }

}
