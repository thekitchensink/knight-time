using UnityEngine;
using System.Collections;

public class GunR : MonoBehaviour
{
    private float CurrentFrameTimeCounter;
    private bool MouseisUp = true;
    private bool SkipDaFrame;
    // Use this for initialization
    void Start()
    {
        SkipDaFrame = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (SkipDaFrame == true)
        {
            bool prev = MouseisUp;
            MouseisUp = !Input.GetButton("Fire2");
            if (MouseisUp)
            {
                GetComponent<Base_bullet_r>().Frame_Mouse_Is_Up();
                if (prev != MouseisUp)
                {
                    GetComponent<Base_bullet_r>().OnMouseUp();
                }
                GetComponent<Base_bullet_r>().HeldDownFor = 0;
            }
            else
            {
                GetComponent<Base_bullet_r>().Frame_Mouse_Is_Down();
                if (prev != MouseisUp)
                {
                    GetComponent<Base_bullet_r>().OnMouseDown();
                }
                GetComponent<Base_bullet_r>().HeldDownFor += Time.deltaTime;
            }
        }
        else
        {
            SkipDaFrame = false;
        }
    }
}