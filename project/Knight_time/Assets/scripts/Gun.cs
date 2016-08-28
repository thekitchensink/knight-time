using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    private float CurrentFrameTimeCounter;
    private bool MouseisUp = true;
    private bool AltFireisUp = true;
    private bool SkipDaFrame;
    // Use this for initialization
    void Start () {
        SkipDaFrame = true;
    }

    // Update is called once per frame
    void Update()
    {
        Base_bullet my_bullet = null;
        Base_bullet[] compArray = GetComponents<Base_bullet>();

        for (int i = 0; i < compArray.Length; ++i)
        {
            if (compArray[i].isActiveAndEnabled)
            {
                my_bullet = compArray[i];
                break;
            }
        }

        if (my_bullet != null)
        {
            if (SkipDaFrame)
            {
                bool prev = MouseisUp;
                MouseisUp = !Input.GetButton("Fire1");
                if (MouseisUp)
                {
                    my_bullet.Frame_Mouse_Is_Up();
                    if (prev != MouseisUp)
                    {
                        if (my_bullet.isActiveAndEnabled)
                        {
                            my_bullet.OnMouseUp();
                        }
                    }
                    my_bullet.HeldDownFor = 0;
                }
                else
                {
                    my_bullet.Frame_Mouse_Is_Down();
                    if (prev != MouseisUp)
                    {
                        if (my_bullet.isActiveAndEnabled)
                        {
                            my_bullet.OnMouseDown();
                        }
                    }
                    my_bullet.HeldDownFor += Time.deltaTime;
                }

                AltFireisUp = !Input.GetButton("Fire2");
                if (AltFireisUp)
                {
                    if (my_bullet.isActiveAndEnabled)
                    {
                        if (prev != AltFireisUp)
                        {
                            my_bullet.OnAltFireUp();
                        }
                    }
                }
                else
                {
                    if (my_bullet.isActiveAndEnabled)
                    {
                        if (prev != AltFireisUp)
                        {
                            my_bullet.OnAltFireDown();
                        }
                    }
                }
            }
            else
            {
                SkipDaFrame = false;
            }
        }
    }
}
