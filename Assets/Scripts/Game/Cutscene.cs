using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame

    public string sceneToLoad;

    private GameObject Character;
    private bool startNext = false, coroutineRunning = false, cutsceneStarted = false;
    public Text texts;
    public string[] lines;
    public int size;
    private int j = 0;
    public GameObject placeForText;

    private void Start()
    {
        placeForText.SetActive(false);
        Character = GameObject.FindGameObjectWithTag("Player");
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
                    placeForText.SetActive(false);
                    cutsceneStarted = false;
                    Character.GetComponent<hero>().isInCutscene = false;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MuteAudio();
        Character.GetComponent<hero>().isInCutscene = true;
        cutsceneStarted = true;
        StartCoroutine(Waiting());
    }
    private void MuteAudio()
    {
        if (Character.GetComponent<hero>().FootstepsSound.isPlaying)
            Character.GetComponent<hero>().FootstepsSound.Stop();
        if (Character.GetComponent<hero>().CrouchingSound.isPlaying)
            Character.GetComponent<hero>().CrouchingSound.Stop();
        if (Character.GetComponent<hero>().JumpingSound.isPlaying)
            Character.GetComponent<hero>().JumpingSound.Stop();
        Character.GetComponent<hero>().animator.SetBool("IsJumping", false);
        Character.GetComponent<hero>().animator.SetBool("IsCrouching", false);
        Character.GetComponent<hero>().animator.SetFloat("Speed", 0f);
    }
    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1.7f);
        placeForText.SetActive(true);
    }
}
