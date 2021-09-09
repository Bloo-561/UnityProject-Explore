using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class OutsideAutoTimeline : MonoBehaviour
{

    public GameObject DialogueBox;

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

    private bool fix = false;

    void Start()
    {
        StartCoroutine(TypeName());
        StartCoroutine(TypeSentence());
    }

    IEnumerator TypeName()
    {
        yield return new WaitForSeconds(3);
        Name.text = "";
        dialogueAnim.SetBool("isOpen", true);
        Name.text = names[nameIndex];
        yield return new WaitForSeconds(5);
        Music.Play();
        dialogueAnim.SetBool("isOpen", false);
        yield return new WaitForSeconds(1);
        Destroy(this);
    }

    IEnumerator TypeSentence()
    {
        Dialogue.text = "";
        Dialogue.text = sentences[sentenceIndex];
        yield return null;
    }
}
