using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControllerStart : MonoBehaviour
{

    public Animator Camera;

    private int startCount;
    
    void Start()
    {
        if (startCount == 0)
        {
            startCount = 1;
            Camera.SetBool("cutscene1", true);
            StartCoroutine(CameraStart());
        }
    }

   IEnumerator CameraStart()
    {
        yield return new WaitForSeconds(6);
        Camera.SetBool("cutscene1", false);
    }
}
