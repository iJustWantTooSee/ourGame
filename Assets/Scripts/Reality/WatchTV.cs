using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class WatchTV : MonoBehaviour
{
    public Text texts;
    public string[] lines;
    public int size;
    private bool startNext = false, coroutineRunning = false;
    public GameObject placeForText;
    public GameObject afterDialog;


    public GameObject objectCloseUp;
    public GameObject hint;
    public GameObject dialogField;
    private GameObject Character;
    private bool ObjectIsOn = false, ObjectEnded = false, dialogFlag = false;
    private int i = 0, length = 200;
    private int j = 0; 

    // Start is called before the first frame update
    void Start()
    {
        afterDialog.SetActive(false);
        placeForText.SetActive(false);
        for (int k = 0; k < size; k++)
        Character = GameObject.FindGameObjectWithTag("Player");
        objectCloseUp.SetActive(false);
        hint.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogFlag)
        {
            if (i < length)
            {
                dialogField.transform.position = new Vector3(Character.transform.position.x + 1.5f, Character.transform.position.y + 3.4f, 0);
                i++;
            }
            else
            {
                dialogField.SetActive(false);
                i = 0;
                dialogFlag = false;
            }
        }
        else if (ObjectIsOn)
        {
            if (j < size)
            {
                if (!startNext && !coroutineRunning)
                {
                    //line = texts.text;
                    texts.text = "";
                    StartCoroutine("PlayText");
                }
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (j<size)
                {
                    if (startNext)
                    {
                        startNext = false;
                        j++;
                    }
                }
                else
                {
                    if (j == size)
                    {
                        objectCloseUp.SetActive(false);
                        placeForText.SetActive(false);
                        afterDialog.transform.position = new Vector3(Character.transform.position.x + 1.5f, Character.transform.position.y + 3.4f, 0);
                        afterDialog.SetActive(true);
                        j++;
                    }
                    else
                    {
                        afterDialog.SetActive(false);
                        Character.GetComponent<CharacterControl>().isInDialog = false;
                        ObjectIsOn = false;
                        ObjectEnded = true;
                    }
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
        if (collision.gameObject.tag == "Player")
        {
            hint.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!ObjectIsOn)
                {
                    if (ObjectEnded)
                    {
                        dialogField.SetActive(true);
                        dialogFlag = true;
                    }
                    else
                    {
                        hint.SetActive(false);
                        Character.GetComponent<CharacterControl>().isInDialog = true;
                        Character.GetComponent<CharacterAnimation>().anim.SetBool("isWalking", false);
                        ObjectIsOn = true;
                        objectCloseUp.SetActive(true);
                        placeForText.SetActive(true);
                    }
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hint.SetActive(false);
        }
    }
}
