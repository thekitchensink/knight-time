using UnityEngine;
using System.Collections;

public class inventory : MonoBehaviour
{
    public PhysicsBulletL pbl;
    public TeleBullet tbl;

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
        bullet_types.Add(newBulletType);
        total_bullet_amount += 1;
        UpdateType(total_bullet_amount - 1);
    }

    void Update()
    {
        if (Input.GetButton("SwitchBullet") && !bounce)
        {
            bounce = true;

            UpdateType(current_type + 1);
        }
        else if(!Input.GetButton("SwitchBullet"))
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
