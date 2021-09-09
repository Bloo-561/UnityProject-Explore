using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject player;
    public GameObject Trigger;
    public GameObject Barrer2;
    public GameObject Platforms;

    public GameObject Frog_parent;
    public GameObject Frog_child;

    public AudioSource oldMusic;
    public AudioSource Monster;
    public AudioSource currentMusic;

    public Animator dialogueAnim;

    public Text Name;
    public Text Dialogue;

    void Start()
    {
        Barrer2.SetActive(false);
        Platforms.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Trigger.GetComponent<TriggerEnemy>().sawWater == true)
        {
            StartCoroutine(Run());
            Barrer2.SetActive(true);
            Platforms.SetActive(true);
            Frog_parent.SetActive(false);
            Frog_child.SetActive(false);
        }
    }   
    
    IEnumerator Run()
    {
        player.GetComponent<Player>().enabled = false;
        oldMusic.Stop();
        Monster.Play();
        Name.text = "";
        Dialogue.text = "";
        yield return new WaitForSeconds(2);
        dialogueAnim.SetBool("isOpen", true);
        Name.text = "Me";
        Dialogue.text = "Huh?";
        Monster.volume = .7f;
        yield return new WaitForSeconds(2);
        Monster.Play();
        yield return new WaitForSeconds(2);
        Name.text = "Me";
        Dialogue.text = "Run,NOW!";
        currentMusic.Play();
        player.GetComponent<Player>().enabled = true;
        yield return new WaitForSeconds(2);
        dialogueAnim.SetBool("isOpen", false);
        Destroy(this);
    }
}
