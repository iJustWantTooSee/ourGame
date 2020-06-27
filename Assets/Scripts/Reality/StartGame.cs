using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private bool dialogFlag = false;
    public bool startGame = false;
    public int length;
    public GameObject dialogField;
    public GameObject hint;
    private GameObject Character;
    private int i = 0;

    private void Start()
    {
        Character = GameObject.FindGameObjectWithTag("Player");
        dialogField.SetActive(false);
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
                if (!dialogFlag)
                {
                    if (!startGame)
                    {
                        dialogFlag = true;
                        dialogField.SetActive(true);
                    }
                    else
                    {
                       SceneManager.LoadScene("gameInGameFirstLVL");
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
