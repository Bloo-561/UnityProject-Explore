using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class meetFrog : MonoBehaviour
{
    public GameObject DialogueBox;
    public GameObject player;
    public GameObject Frog;
    public GameObject Frog_Parent;
    public GameObject Frog_Child;
    public GameObject Barrier;

    public AudioSource Music;

    public Animator dialogueAnim;

    public Text Name;
    public Text Dialogue;

    public PlayableDirector director;

    public List<string> names;

    [TextArea(3, 10)]
    public List<string> sentences;

    private int nameIndex;
    private int sentenceIndex;

    void Start()
    {
        Frog_Parent.SetActive(false);
        Frog_Child.SetActive(false);
        Barrier.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        director.Play();
        StartCoroutine(Cutscene());
    }

    IEnumerator Cutscene()
    {
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        dialogueAnim.SetBool("isOpen", true);
        Name.text = "Me";
        Dialogue.text = "Glad that drop wasn't long. I should head right and work my way back up.";
        yield return new WaitForSeconds(3);
        dialogueAnim.SetBool("isOpen", false);
        yield return new WaitForSeconds(2);
        dialogueAnim.SetBool("isOpen", true);
        Name.text = "Me";
        Dialogue.text = "EH?!";
        yield return new WaitForSeconds(2);
        dialogueAnim.SetBool("isOpen", true);
        Name.text = "Me";
        Dialogue.text = "Please don't hurt me...not again...";
        yield return new WaitForSeconds(7);
        Name.text = "Me";
        Dialogue.text = "Huh?";
        Frog.gameObject.SetActive(false);
        Frog_Parent.SetActive(true);
        Frog_Child.SetActive(true);
        Barrier.SetActive(true);
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
        dialogueAnim.SetBool("isOpen", false);
    }
}
