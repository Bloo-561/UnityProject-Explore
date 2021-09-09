using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScene : MonoBehaviour
{
    public Animator cutscene;

    void Start()
    {
        cutscene.SetBool("cutscene2", true);
        StartCoroutine(Bridge());
    }

    IEnumerator Bridge()
    {
        yield return new WaitForSeconds(5);
        cutscene.SetBool("cutscene2", false);
    }
}
