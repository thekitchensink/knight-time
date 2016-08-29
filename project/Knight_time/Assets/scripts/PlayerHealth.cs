using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.ImageEffects;

class FuckYou : System.Exception
{ }

public class PlayerHealth : MonoBehaviour {

    public static PlayerHealth sing;
    public static int Health
    {
        get { return sing.CurrentHealthAmount; }
        set { sing.CurrentHealthAmount = value; }
    }

    private static VignetteAndChromaticAberration vaca;
    private static Bloom b;
    private static NoiseAndGrain nag;
    private static ColorCorrectionCurves ccc;
    private static Fisheye fe;
    private static Tonemapping tm;

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

        GameObject g = gameObject.transform.FindChild("FirstPersonCharacter").gameObject;
        vaca = g.GetComponent < VignetteAndChromaticAberration > ();
        b = g.GetComponent<Bloom>();
        nag = g.GetComponent<NoiseAndGrain>();
        ccc = g.GetComponent<ColorCorrectionCurves>();
        fe = g.GetComponent<Fisheye>();
        tm = g.GetComponent<Tonemapping>();
        
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

            GameObject go = sing.gameObject.transform.FindChild("FirstPersonCharacter").gameObject;
        }
    }

    public static void AddHealth(int amount)
    {
        sing.CurrentHealthAmount += amount;
    }
}
