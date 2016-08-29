using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIStuff : MonoBehaviour 
{
	public Text health;
	public Text gunType;
	public Text ammo;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		health.text = GetComponent<PlayerHealth>().CurrentHealthAmount.ToString();

		if(GetComponent<inventory>().current_type == 0)
		{
			gunType.text = "Charge Gun";
		}
		else if (GetComponent<inventory>().current_type == 1)
		{
			gunType.text = "Teleport Gun";
		}

		ammo.text = GetComponent<inventory>().ammoCount[GetComponent<inventory>().current_type].ToString();

	}
}
