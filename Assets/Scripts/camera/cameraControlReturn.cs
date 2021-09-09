using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControlReturn : MonoBehaviour
{
    public Animator Camera;
    public Animator Logo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Camera.SetBool("cutscene1", false);
        Logo.SetBool("Show", false);
    }
}
