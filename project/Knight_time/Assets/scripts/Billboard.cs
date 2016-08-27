using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Sprite))]
public class Billboard : MonoBehaviour
{
    void Update()
    {
        Vector3 camForward = Camera.main.transform.forward;
        
        transform.forward = -camForward;
    }
}
