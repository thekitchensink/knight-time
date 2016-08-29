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
    void Update () {
        if (SkipDaFrame)
        {
            Base_bullet[] bb = GetComponents<Base_bullet>();
            Base_bullet k = bb[0];
            foreach(Base_bullet b in bb)
            {
                if (b.isActiveAndEnabled)
                {
                    k = b;
                }
            }


            bool prev = MouseisUp;
            MouseisUp = !Input.GetButton("Fire1");
            if (MouseisUp)
            {
                if (prev != MouseisUp)
                {
                    k.OnMouseUp();
                }
                k.Frame_Mouse_Is_Up();
                k.HeldDownFor = 0;
            }
            else
            {
                if (prev != MouseisUp)
                {
                    k.OnMouseDown();
                }
                k.Frame_Mouse_Is_Down();
                k.HeldDownFor += Time.deltaTime;
            }

            AltFireisUp = !Input.GetButton("Fire2");
            if (AltFireisUp)
            {
                if(prev != AltFireisUp)
                {
                    k.OnAltFireUp();
                }
            }
            else
            {
                if(prev != AltFireisUp)
                {
                    k.OnAltFireDown();
                }
            }
        }
        else
        {
            SkipDaFrame = false;
        }
    }
}
