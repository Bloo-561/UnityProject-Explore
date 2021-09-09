using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    //public Animator transition;
    public int sceneSelect;
    public Animator sceneSwitch;
    public GameObject Eyes;


    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            sceneSwitch.SetTrigger("Switch");
            Eyes.gameObject.SetActive(true);
            StartCoroutine(Pause());

        }
    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(sceneSelect);
    }
}
