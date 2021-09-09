using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConversionKeepRunning : MonoBehaviour
{
    public GameObject DialogueBox;
    public GameObject Player;

    public Text Name;
    public Text Dialogue;

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

    public float previousSpeed;

    void Start()
    {
        defaultPosition = DialogueBox.transform.position;
        previousSpeed = Player.GetComponent<Player>().speed;
    }

    IEnumerator TypeName()
    {
        Name.text = "";
        dialogueAnim.SetBool("isOpen", true);
        Name.text = names[nameIndex];
        yield return new WaitForSeconds(4);
        dialogueAnim.SetBool("isOpen", false);
        Player.GetComponent<Player>().speed = 5f;
        yield return new WaitForSeconds(1);
        if (names.Count > 1)
        {
            names.RemoveAt(nameIndex);
        }
        Destroy(this);

        // Dialogue Box Location //
        if (keepLocation == false)
        {
            DialogueBox.transform.position = defaultPosition;
        }
        Player.GetComponent<Player>().enabled = true;
    }

    IEnumerator TypeSentence()
    {
        Dialogue.text = "";
        Dialogue.text = sentences[sentenceIndex];
        yield return null;
        if (sentences.Count > 1)
        {
            sentences.RemoveAt(sentenceIndex);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (changeLocation == true)
            {
                DialogueBox.transform.position = dialogueLocation;
            }

            StartCoroutine(TypeName());
            StartCoroutine(TypeSentence());
        }
    }
}
