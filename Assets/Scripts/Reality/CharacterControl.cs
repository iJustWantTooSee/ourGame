
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class CharacterControl : MonoBehaviour
{
    public GameObject[] Cameras;
    public int CamerasAmount;
    public float speed;
    //public int length;
    private float moveInput;
    private Rigidbody2D rb;
    public bool facingRight = true; 
    //private bool dialogFlag = false;
    //private ShowDialog dlgObj;
    //private int i = 0;
    public bool isInDialog = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        for (int i = 0; i < CamerasAmount; i++)
            Cameras[i].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInDialog)
        {
            moveInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
            if (!facingRight && moveInput > 0)
            {
                Flip();
            }
            else if (facingRight && moveInput < 0)
            {
                Flip();
            }
        }
    }
    public void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    //public void ShowDialogOnCharacter(string tag)
    //{
    //    if (dialogFlag)
    //    {
    //        dlgObj.dialogField.SetActive(false);
    //        dlgObj.text.SetActive(false);
    //        i = 0;
    //    }
    //    GameObject obj = GameObject.FindGameObjectWithTag(tag);
    //    dlgObj = obj.GetComponent<ShowDialog>();
    //     dlgObj.dialogField.SetActive(true);
    //    dlgObj.text.SetActive(true);
    //     dialogFlag = true;
    //}
}
