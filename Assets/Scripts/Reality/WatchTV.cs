using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchTV : MonoBehaviour
{
    public GameObject objectCloseUp;
    public GameObject hint;
    public GameObject dialogField;
    private GameObject Character;
    private bool ObjectIsOn = false, ObjectEnded = false, dialogFlag = false;
    private int i = 0, length = 200;

    // Start is called before the first frame update
    void Start()
    {
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
            if (Input.GetKeyDown(KeyCode.F))
            {
                Character.GetComponent<CharacterControl>().isInDialog = false;
                objectCloseUp.SetActive(false);
                ObjectIsOn = false;
                ObjectEnded = true;
            }

        }
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
