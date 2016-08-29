using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

class FuckYou : System.Exception
{ }

public class PlayerHealth : MonoBehaviour {

    public static PlayerHealth sing;
    public static int Health
    {
        get { return sing.CurrentHealthAmount; }
      //  set { sing.CurrentHealthAmount = Health; }
    }

    public int StartingHealthAmount;
    public int CurrentHealthAmount;

    public float InvulnFrameLength;

    private float TimeTracker;
    // Use this for initialization
    void Start () {
        if (sing != null)
        {
            throw new FuckYou();
        }
        else sing = this;
        CurrentHealthAmount = StartingHealthAmount;
    }
    
    // Update is called once per frame
    void Update () {
        TimeTracker += Time.deltaTime;
    }

    public static void TakeDamage(int amount)
    {
        if(sing.TimeTracker > sing.InvulnFrameLength)
        {
            sing.TimeTracker = 0;

            sing.CurrentHealthAmount -= amount;
        }

        Debug.Log("this helth" + sing.CurrentHealthAmount);

        if(sing.CurrentHealthAmount <= 0)
        {
            Debug.Log("ded");


            SceneManager.LoadScene("youdie");
        }
    }
}
