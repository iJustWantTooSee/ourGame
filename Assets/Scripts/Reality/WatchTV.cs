using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class WatchTV : MonoBehaviour
{
    public Text[] texts;
    public int size;
    private string line;
    private bool lineisended = true, coroutineRunning = false;
    public GameObject textAndBack;


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
        textAndBack.SetActive(false);
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
                if (lineisended && !coroutineRunning)
                {
                    lineisended = false;
                    line = texts[j].text;
                    texts[j].text = "";
                    coroutineRunning = true;
                    StartCoroutine("PlayText");
                }
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (j<size)
                {
                    if (lineisended)
                    {
                        j++;
                    }
                }
                else
                {
                    Character.GetComponent<CharacterControl>().isInDialog = false;
                    objectCloseUp.SetActive(false);
                    ObjectIsOn = false;
                    ObjectEnded = true;
                }
            }

        }
    }

    IEnumerator PlayText()
    {
        foreach (char c in line)
        {
            texts[j].text += c;
            yield return new WaitForSeconds(0.125f);
        }
        coroutineRunning = false;
        lineisended = true;
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
                        if (!Character.GetComponent<CharacterControl>().facingRight)
                            Character.GetComponent<CharacterControl>().Flip();
                        ObjectIsOn = true;
                        objectCloseUp.SetActive(true);
                        textAndBack.SetActive(true);
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
