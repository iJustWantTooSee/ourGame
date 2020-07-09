using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    public GameObject ui;
    public AudioSource doorSound;
    public Camera prevCamera;
    public Camera nextCamera;
    public GameObject objToTp;
    public Transform CharacterPosition;
    // Start is called before the first frame update
    void Start()
    {
        ui.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            ui.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                doorSound.Play();
                prevCamera.gameObject.SetActive(false);
                nextCamera.gameObject.SetActive(true);
                objToTp.transform.position = CharacterPosition.transform.position;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        ui.SetActive(false);
    }
}
