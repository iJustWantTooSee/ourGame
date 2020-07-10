using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDialog : MonoBehaviour
{
    private AudioSource Hum;
    private int i;
    public int length;
    public GameObject dialogField;
    public GameObject hint;
    private GameObject Character;
    public bool dialogFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        Hum = GameObject.FindGameObjectWithTag("HumSound").GetComponent<AudioSource>();
        Character = GameObject.FindGameObjectWithTag("Player");
        dialogField.SetActive(false);
        hint.SetActive(false);
        //       text.SetActive(false);
        dialogFlag = false;
    }
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
            if (Input.GetKeyDown(KeyCode.E) && !dialogFlag)
            {
                dialogFlag = true;
                dialogField.SetActive(true);
                Hum.Play();
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
