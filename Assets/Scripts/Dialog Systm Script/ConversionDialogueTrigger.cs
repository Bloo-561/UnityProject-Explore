using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConversionDialogueTrigger : MonoBehaviour
{
    public GameObject DialogueBox;

    public Text Name;
    public Text Dialogue;

    public Animator button;
    public Animator dialogueAnim;

    public Vector3 defaultPosition;
    public Vector3 dialogueLocation;

    public List<string> names;

    [TextArea(3, 10)]
    public List<string> sentences;

    private int nameIndex;
    private int sentenceIndex;

    public bool changeLocation = false;
    public bool keepLocation = false;

    private bool triggerEnter = false;

    void Start()
    {
        defaultPosition = DialogueBox.transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && triggerEnter == true)
        {
            if (changeLocation == true)
            {
                DialogueBox.transform.position = dialogueLocation;
            }
            StartCoroutine(TypeName());
            StartCoroutine(TypeSentence());
        }
        else
        {

        }
    }

    IEnumerator TypeName()
    {
        Name.text = "";
        dialogueAnim.SetBool("isOpen", true);
        Name.text = names[nameIndex];
        yield return new WaitForSeconds(4);
        dialogueAnim.SetBool("isOpen", false);
        yield return new WaitForSeconds(1);
        if(names.Count > 1)
        {
            names.RemoveAt(nameIndex);
        }


        // Dialogue Box Location //
        if (keepLocation == false)
        {
            DialogueBox.transform.position = defaultPosition;
        }
    }

    IEnumerator TypeSentence()
    {
        Dialogue.text = "";
        Dialogue.text = sentences[sentenceIndex];
        yield return null;
        if(sentences.Count > 1)
        {
            sentences.RemoveAt(sentenceIndex);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            button.SetBool("Show Button", true);
            triggerEnter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            button.SetBool("Show Button", false);
            triggerEnter = false;
        }
    }


}
