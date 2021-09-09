using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LastDoor : MonoBehaviour
{

    public GameObject DialogueBox;
    public GameObject Player;

    public Text Name;
    public Text Dialogue;

    public Animator button;
    public Animator dialogueAnim;
    public Animator sceneSwitch;

    public Vector3 defaultPosition;
    public Vector3 buttonLocation;

    public List<string> names;

    [TextArea(3, 10)]
    public List<string> sentences;

    private int nameIndex;
    private int sentenceIndex;

    public int sceneSelect;

    public bool changeLocation = false;
    public bool keepLocation = false;



    private bool triggerEnter = false;

    void Start()
    {
        defaultPosition = button.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(GameObject.Find("Music"));
        if (col.CompareTag("Player"))
        {
            Player.GetComponent<Player>().speed = 0f;
            Player.GetComponent<Animator>().SetFloat("Speed", 0f);
            Player.GetComponent<Player>().enabled = false;
            if (changeLocation == true)
            {
                button.transform.position = buttonLocation;
            }

            StartCoroutine(TypeName());
            StartCoroutine(TypeSentence());
        }
    }

    IEnumerator TypeName()
    {
        Name.text = "";
        dialogueAnim.SetBool("isOpen", true);
        Name.text = names[nameIndex];
        yield return new WaitForSeconds(1);
        Player.GetComponent<Player>().enabled = false;
        yield return new WaitForSeconds(4);
        dialogueAnim.SetBool("isOpen", false);
        yield return new WaitForSeconds(1);
        if (names.Count > 1)
        {
            names.RemoveAt(nameIndex);
        }

        // Dialogue Box Location //
        if (keepLocation == false)
        {
            button.transform.position = defaultPosition;
        }
        button.SetBool("Show Button", true);
        triggerEnter = true;
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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && triggerEnter == true)
        {
            sceneSwitch.SetTrigger("WSwitch");
            StartCoroutine(Pause());
        }

        IEnumerator Pause()
        {
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(sceneSelect);
        }
    }
}
