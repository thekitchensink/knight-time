using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    public GameObject Effect;
    public int StartingHealth;
    public int CurrentHealth;
    // Use this for initialization
    void Start () {
        CurrentHealth = StartingHealth;
    }
    
    // Update is called once per frame
    void Update () {
    
    }

    void TakeDamage(int amount)
    {
        CurrentHealth -= amount;
        if(CurrentHealth <= 0)
        {
            Instantiate(Effect, transform.position, transform.rotation);
            Destroy(this);
        }
    }
}
