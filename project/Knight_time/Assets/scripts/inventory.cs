using UnityEngine;
using System.Collections;

public class inventory : MonoBehaviour
{
    public PhysicsBulletL pbl;

    ArrayList bullet_types;
    int current_type = 0;
    int total_bullet_amount;

    bool bounce = false;

    void Start ()
    {
        bullet_types = new ArrayList();

        bullet_types.Add(pbl);

        total_bullet_amount = bullet_types.Count;
    }

    public void PickupPowerup(Base_bullet newBulletType)
    {
        if (!bullet_types.Contains(newBulletType))
        {
            bullet_types.Add(newBulletType);
            total_bullet_amount += 1;
            //            UpdateType(total_bullet_amount - 1);
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
        if (b = Input.GetButton("SwitchBullet") && !bounce)
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
