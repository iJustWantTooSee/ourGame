﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialog : MonoBehaviour
{
    public int n;
    public GameObject hint;
    public GameObject[] dialogs = new GameObject[10];
    public GameObject[] secDialog = new GameObject[3];
    private GameObject Character;
    private bool flag = false, dialogEnded = false;
    public bool mainEnded = false;
    private Animator anim;
    private int i = 0;


    void Start()
    {
        Character = GameObject.FindGameObjectWithTag("Player");
        for (int j = 0; j < n; j++)
        {
            if (j<3)
                secDialog[j].SetActive(false);
            dialogs[j].SetActive(false);
        }
        anim = GetComponent<Animator>();
        hint.SetActive(false);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (flag)
            {
                if (!mainEnded)
                {
                    dialogs[i].SetActive(false);
                    i++;
                    if (i < n)
                        dialogs[i].SetActive(true);
                    else
                    {
                        i = 0;
                        flag = false;
                        Character.GetComponent<CharacterControl>().isInDialog = false;
                        anim.SetBool("isTalking", false);
                        dialogEnded = true;
                        mainEnded = true;
                    }
                }
                else
                {
                    secDialog[i].SetActive(false);
                    i++;
                    if (i < 3)
                        secDialog[i].SetActive(true);
                    else
                    {
                        i = 0;
                        flag = false;
                        Character.GetComponent<CharacterControl>().isInDialog = false;
                        anim.SetBool("isTalking", false);
                        dialogEnded = true;
                    }
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dialogEnded = false;
            hint.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !dialogEnded)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!flag)
                {
                    i = 0;
                    flag = true;
                    Character.GetComponent<CharacterControl>().isInDialog = true;
                    Character.GetComponent<CharacterAnimation>().anim.SetBool("isWalking", false);
                    if (!Character.GetComponent<CharacterControl>().facingRight)
                        Character.GetComponent<CharacterControl>().Flip();
                    anim.SetBool("isTalking", true);
                    if (!mainEnded)
                        dialogs[i].SetActive(true);
                    else
                        secDialog[i].SetActive(true);
                    //MotherAnswer[i].SetActive(true);
                    //playerTalking = true;
                    hint.SetActive(false);
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !dialogEnded)
        {
            dialogEnded = false;
            hint.SetActive(false);
            flag = false;
        }
    }
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class StartDialog : MonoBehaviour
//{
//    public int n;
//    public GameObject hint;
//    public GameObject inputField;
//    public GameObject[] StartReplics = new GameObject[2];
//    public GameObject[] MotherAnswer = new GameObject[8];


//    private GameObject Character;
//    private bool flag = false, motherTalking = false, playerTalking = true, dialogEnded = false;
//    private Animator anim;
//    private int i = 0;


//    void Start()
//    {
//        Character = GameObject.FindGameObjectWithTag("Player");
//        inputField.SetActive(false);
//        for (int j = 0; j < n; j++)
//            MotherAnswer[j].SetActive(false);
//        anim = GetComponent<Animator>();
//        hint.SetActive(false);

//    }
//    private void Update()
//    {

//    }
//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.gameObject.tag == "Player")
//        {
//            dialogEnded = false;
//            hint.SetActive(true);
//        }
//    }

//    private void OnTriggerStay2D(Collider2D collision)
//    {
//        if (collision.gameObject.tag == "Player" && !dialogEnded)
//        {
//            if (Input.GetKeyDown(KeyCode.E))
//            {
//                if (!flag)
//                {
//                    i = -1;
//                    flag = true;
//                    Character.GetComponent<CharacterControl>().isInDialog = true;
//                    Character.GetComponent<CharacterAnimation>().anim.SetBool("isWalking", false);
//                    if (!Character.GetComponent<CharacterControl>().facingRight)
//                        Character.GetComponent<CharacterControl>().Flip();
//                    inputField.transform.position = new Vector3(Character.transform.position.x + 2.2f, Character.transform.position.y + 3.4f, 0);
//                    anim.SetBool("isTalking", true);
//                    playerTalking = true;
//                    //MotherAnswer[i].SetActive(true);
//                    //playerTalking = true;
//                    hint.SetActive(false);
//                }
//            }
//        }
//    }
//    private void OnTriggerExit2D(Collider2D collision)
//    {
//        if (collision.gameObject.tag == "Player" && !dialogEnded)
//        {
//            hint.SetActive(false);
//            //     dialogField.SetActive(false);
//            //      text.SetActive(false);
//            flag = false;
//        }
//    }
//}

//if (Input.GetKeyDown(KeyCode.E) && flag)
//        {
//            if (motherTalking)
//            {
//                motherTalking = false;
//                if (i<n)
//                {
//                    MotherAnswer[i].SetActive(false);
//inputField.SetActive(true);
//                    playerTalking = true;
//                }
//                else
//                {
//                    flag = false;
//                    playerTalking = false;
//                    Character.GetComponent<CharacterControl>().isInDialog = false;
//                    anim.SetBool("isTalking", false);
//                    dialogEnded = true;
//                }
//            }
//            else if (playerTalking)
//            {
//                inputField.SetActive(false);
//                playerTalking = false;
//                i++;
//                if (n< 2)
//                {
//                    MotherAnswer[i].SetActive(true);
//motherTalking = true;
//                }

//                else
//                {
//                    flag = false;
//                    motherTalking = false;
//                    Character.GetComponent<CharacterControl>().isInDialog = false;
//                    anim.SetBool("isTalking", false);
//                    dialogEnded = true;
//                }
//            }
//        }