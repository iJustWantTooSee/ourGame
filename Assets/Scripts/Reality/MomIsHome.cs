using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MomIsHome : MonoBehaviour
{
    public AudioSource Door;
    public string sceneToLoad;
    public Text texts;
    public string[] lines;
    public int size;
    private int j = 0;
    public GameObject placeForText;
    private bool startNext = false, coroutineRunning = false, cutsceneStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        Door.Play();
        placeForText.SetActive(false);
        StartCoroutine(Waiting());
    }
    void Update()
    {
        if (cutsceneStarted)
        {
            if (j < size)
            {
                if (!startNext && !coroutineRunning)
                {
                    texts.text = "";
                    StartCoroutine("PlayText");
                }
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (j < size)
                {
                    if (startNext)
                    {
                        startNext = false;
                        j++;
                    }
                }
                else
                {
                    SceneManager.LoadScene(sceneToLoad);
                }
            }
        }
    }
    IEnumerator PlayText()
    {
        coroutineRunning = true;
        foreach (char c in lines[j])
        {
            texts.text += c;
            yield return new WaitForSeconds(0.065f);
        }
        coroutineRunning = false;
        startNext = true;
    }
    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1.7f);
        placeForText.SetActive(true);
        cutsceneStarted = true;
    }
}
