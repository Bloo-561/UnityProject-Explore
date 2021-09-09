using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConversionDialogueStart : MonoBehaviour
{
    public GameObject DialogueBox;
    public GameObject player;

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

    private int startCount;

    public bool changeLocation = false;

    void Start()
    {
        if (startCount == 0)
        {
            startCount = 1;
            defaultPosition = DialogueBox.transform.position;

            if (changeLocation == true)
            {
                DialogueBox.transform.position = dialogueLocation;
            }


            player.GetComponent<Player>().enabled = false;
            StartCoroutine(TypeName());
            StartCoroutine(TypeSentence());
        }
    }

    IEnumerator TypeName()
    {
        Name.text = "";
        dialogueAnim.SetBool("isOpen", true);
        Name.text = names[nameIndex];
        yield return new WaitForSeconds(5);
        dialogueAnim.SetBool("isOpen", false);
        yield return new WaitForSeconds(1);
        player.GetComponent<Player>().enabled = true;
        DialogueBox.transform.position = defaultPosition;
        Destroy(this);
    }

    IEnumerator TypeSentence()
    {
        Dialogue.text = "";
        Dialogue.text = sentences[sentenceIndex];
        yield return null;
    }
}
