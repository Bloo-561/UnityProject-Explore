using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpeningScene : MonoBehaviour
{
    public Text OpeningText;
    public AudioSource OpeningMusic;

    // Update is called once per frame
    void Update()
    {
        StartGame();
    }

    void StartGame()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(OpeningCutscene());
        }
    }

    IEnumerator OpeningCutscene()
    {
        OpeningText.text = "";
        OpeningMusic.Play();
        yield return new WaitForSeconds(1);
        OpeningText.text = "Hey...";
        yield return new WaitForSeconds(3);
        OpeningText.text = "You been in your room all this time...";
        yield return new WaitForSeconds(5);
        OpeningText.text = "I need to go out for a bit. Meet me in town in the morning. Okay?";
        yield return new WaitForSeconds(5);
        OpeningText.text = "I left you some things for the trip and have food ready for tonight. Eat them and rest up.";
        yield return new WaitForSeconds(7);
        OpeningText.text = "I love you...okay?";
        yield return new WaitForSeconds(3);
        OpeningText.text = "";
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }
}
