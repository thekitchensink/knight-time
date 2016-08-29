using UnityEngine;
using System.Collections;

public class DestroyWall : MonoBehaviour
{

    private int health = 50;
    public bool enable = true;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision coll)
    {
        if (!enable)
        {
            return;
        }

        Base_bullet one = coll.gameObject.GetComponent<Base_bullet>();
        KillYourself two = coll.gameObject.GetComponent<KillYourself>();


        if (one || two)
        {
            health--;

            if (health <= 0)
            {
                GameObject g = GameObject.Instantiate(Resources.Load("SmokeDust") as GameObject);
                g.GetComponent<Transform>().position = transform.position;

                Destroy(gameObject);
            }
        }
    }

}
