using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDialog : MonoBehaviour
{
    public GameObject text;
    public GameObject dialogField;
    public GameObject hint;
    private GameObject Character;
    public float sec;
    public bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        Character = GameObject.FindGameObjectWithTag("Player");
        dialogField.SetActive(false);
        hint.SetActive(false);
        //       text.SetActive(false);
        flag = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hint.SetActive(true);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E) && !flag)
        {
            flag = true;
            Character.GetComponent<CharacterControl>().ShowDialogOnCharacter(this.tag);
        }
        //if (flag) 
        //{
        //   StartCoroutine(ShowAndHide(dialogField));
        //dialogField.transform.position = new Vector3(Character.transform.position.x+1.5f, Character.transform.position.y+3.4f,0);
        //text.transform.position = new Vector3(Character.transform.position.x + x, Character.transform.position.y + y, Character.transform.position.z+z);
        //          text.transform.position = new Vector3(Character.transform.position.x + 1.5f, Character.transform.position.y + 3.4f, 0);
        //}
    }
    IEnumerator ShowAndHide()
    {
        dialogField.SetActive(true);
        text.SetActive(true);
        dialogField.transform.position = new Vector3(Character.transform.position.x + 1.5f, Character.transform.position.y + 3.4f, 0);
        text.transform.position = new Vector3(Character.transform.position.x + 1.5f, Character.transform.position.y + 3.4f, 0);
        yield return new WaitForSeconds(sec);
        dialogField.SetActive(false);
        text.SetActive(false);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        hint.SetActive(false);
        //     dialogField.SetActive(false);
        //      text.SetActive(false);
        flag = false;
    }
}
