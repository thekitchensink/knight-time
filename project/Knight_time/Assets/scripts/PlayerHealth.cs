using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.ImageEffects;

class FuckYou : System.Exception
{ }

public class PlayerHealth : MonoBehaviour {

	private static VignetteAndChromaticAberration vaca;
	private static NoiseAndGrain nag;
	private static Fisheye fe;

	private static float originalAbberation = 5;
	private static float originalFish = 0.15f;
	private static float originalGrain = 0.8f;

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

		GameObject g = gameObject.transform.FindChild("FirstPersonCharacter").gameObject;
		vaca = g.GetComponent < VignetteAndChromaticAberration > ();
		nag = g.GetComponent<NoiseAndGrain>();
		fe = g.GetComponent<Fisheye>();
    }
    
    // Update is called once per frame
    void Update () {
        TimeTracker += Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

		if(vaca.chromaticAberration > originalAbberation)
		{
			vaca.chromaticAberration -= 0.8f;
		}
		if(vaca.chromaticAberration < originalAbberation)
		{
			vaca.chromaticAberration = originalAbberation;
		}

		if(nag.intensityMultiplier > originalGrain)
		{
			nag.intensityMultiplier -= 0.5f;
		}
		if(nag.intensityMultiplier < originalGrain)
		{
			nag.intensityMultiplier = originalGrain;
		}

		if(fe.strengthX > originalFish)
		{
			fe.strengthX -= 0.03f;
		}
		if(fe.strengthX < originalFish)
		{
			fe.strengthX = originalFish;
		}

		if(fe.strengthY > originalFish)
		{
			fe.strengthY -= 0.03f;
		}
		if(fe.strengthY < originalFish)
		{
			fe.strengthY = originalFish;
		}
    }

    public static void TakeDamage(int amount)
    {
		sing.gameObject.GetComponent<AudioSource>().pitch = Random.Range (0.9f, 1.1f);
		sing.gameObject.GetComponent<AudioSource>().PlayOneShot(sing.gameObject.GetComponent<AudioSource>().clip, 0.6f);

		//GameObject go = sing.gameObject.transform.FindChild("FirstPersonCharacter").gameObject;
		vaca.chromaticAberration = 60f;
		nag.intensityMultiplier = 60f;
		fe.strengthX = 0.8f;
		fe.strengthY = 0.8f;

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
    public static void AddHealth(int amount)
    {
        sing.CurrentHealthAmount += amount;
    }
}
