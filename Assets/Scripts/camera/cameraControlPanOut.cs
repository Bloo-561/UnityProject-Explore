using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControlPanOut : MonoBehaviour
{
    public Animator Camera;
    public Animator Logo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Camera.SetBool("cutscene1", true);
        Logo.SetBool("Show", true);
    }
}
