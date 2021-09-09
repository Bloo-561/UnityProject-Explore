using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class FinalCutscene : MonoBehaviour
{
    public GameObject DialogueBox;
    public GameObject player;

    public Animator camera;

    public Image Credits;
    public Text Name;
    public Text Dialogue;

    public Animator dialogueAnim;

    public PlayableDirector director;

    public AudioSource Music;

    void Start()
    {
        Credits.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(GameObject.Find("RunMusic"));
        this.GetComponent<BoxCollider2D>().enabled = false;
        director.Play();
        StartCoroutine(Final());
        Music.Play();
    }

    IEnumerator Final()
    {
        camera.SetBool("cutscene2", true);
        player.GetComponent<Player>().enabled = false;
        yield return new WaitForSeconds(1.2f);
        dialogueAnim.SetBool("isOpen", true);
        Name.text = "Me";
        Dialogue.text = "Whew! Glad I got away from...what did I exactly run away from?";
        yield return new WaitForSeconds(4);
        Dialogue.text = "Plus, where did those platforms come from? They weren't there before...";
        yield return new WaitForSeconds(4);
        Dialogue.text = "Anyways, I need to go to town, wait there's someone!!";
        yield return new WaitForSeconds(4);
        Dialogue.text = "Excuse Me!";
        yield return new WaitForSeconds(4);
        Name.text = "???";
        Dialogue.text = "Oh hello stranger, how can I help you?";
        yield return new WaitForSeconds(4);
        Name.text = "Me";
        Dialogue.text = "I need help to get into town. Can you please help me?";
        yield return new WaitForSeconds(4);
        Name.text = "???";
        Dialogue.text = "Oh sure, not a problem, but why you came though the caves? Couldn't you just use the beach to get to town?";
        yield return new WaitForSeconds(4);
        dialogueAnim.SetBool("isOpen", false);
        yield return new WaitForSeconds(5);
        dialogueAnim.SetBool("isOpen", true);
        Name.text = "Me";
        Dialogue.text = "What?";
        yield return new WaitForSeconds(2);
        Credits.enabled = true;
    }
}
