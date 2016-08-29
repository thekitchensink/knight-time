using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class inventory : MonoBehaviour
{
    public PhysicsBulletL pbl;

    ArrayList bullet_types;
	[HideInInspector]
    public int current_type = 0;
    int total_bullet_amount;
	public List<int> ammoCount;

    bool bounce = false;

    void Start ()
    {
        bullet_types = new ArrayList();

        bullet_types.Add(pbl);

        total_bullet_amount = bullet_types.Count;

		ammoCount = new List<int>();
		ammoCount.Add(10);


    }

    public void PickupPowerup(Base_bullet newBulletType)
    {
        if (!bullet_types.Contains(newBulletType))
        {
            bullet_types.Add(newBulletType);
			ammoCount.Add(5);
            total_bullet_amount += 1;
            //            UpdateType(total_bullet_amount - 1);
        }
		else
		{
			ammoCount[bullet_types.IndexOf(newBulletType)] += 8;
		}
        PhysicsBulletL pbl = newBulletType as PhysicsBulletL;
        if (pbl != null)
            Debug.Log("PhysicsBulletL");
        else
        {
            TeleBullet tb = newBulletType as TeleBullet;
            if (tb != null)
                Debug.Log("TeleBullet");
        }

        UpdateType(bullet_types.IndexOf(newBulletType));
    }

    void Update()
    {
        bool b;
        if (b = Input.GetButtonDown("SwitchBullet") && !bounce)
        {
            bounce = true;

            UpdateType(current_type + 1);
        }
        else if(!b)
        {
            bounce = false;
        }
    }

    void UpdateType(int newType)
    {
		(bullet_types[current_type] as Base_bullet).enabled = false;

        current_type = newType;

        if (current_type >= total_bullet_amount)
        {
            current_type = current_type % total_bullet_amount;
        }

        if (current_type < 0)
        {
            current_type = total_bullet_amount + current_type;
        }

		(bullet_types[current_type] as Base_bullet).enabled = true;
    }
}
