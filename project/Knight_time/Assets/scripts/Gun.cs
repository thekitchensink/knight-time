﻿using UnityEngine;
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
            bool prev = MouseisUp;
            MouseisUp = !Input.GetButton("Fire1");
            if (MouseisUp)
            {
                if (prev != MouseisUp)
                {
                    GetComponent<Base_bullet>().OnMouseUp();
                }
                GetComponent<Base_bullet>().Frame_Mouse_Is_Up();
                GetComponent<Base_bullet>().HeldDownFor = 0;
            }
            else
            {
                if (prev != MouseisUp)
                {
                    GetComponent<Base_bullet>().OnMouseDown();
                }
                GetComponent<Base_bullet>().Frame_Mouse_Is_Down();
                GetComponent<Base_bullet>().HeldDownFor += Time.deltaTime;
            }

            AltFireisUp = !Input.GetButton("Fire2");
            if (AltFireisUp)
            {
                if(prev != AltFireisUp)
                {
                    GetComponent<Base_bullet>().OnAltFireUp();
                }
            }
            else
            {
                if(prev != AltFireisUp)
                {
                    GetComponent<Base_bullet>().OnAltFireDown();
                }
            }
        }
        else
        {
            SkipDaFrame = false;
        }
    }
}
