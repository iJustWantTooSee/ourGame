
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class CharacterControl : MonoBehaviour
{

    public float speed;
    public int length;
    private float moveInput;
    private Rigidbody2D rb;
    private bool facingRight = true, dialogFlag = false;
    private ShowDialog dlgObj;
    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput*speed, rb.velocity.y);
        if (dialogFlag)
        {
            if (i < length)
            {
                dlgObj.dialogField.transform.position = new Vector3(this.transform.position.x + 1.5f, this.transform.position.y + 3.4f, 0);
                dlgObj.text.transform.position = new Vector3(this.transform.position.x + 1.5f, this.transform.position.y + 3.4f, 0);
                i++;
            }
            else
            {
                dlgObj.dialogField.SetActive(false);
                dlgObj.text.SetActive(false);
                i = 0;
                dialogFlag = false;
                dlgObj.flag = false;
            }
        }
        if (!facingRight && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight && moveInput < 0)
        {
            Flip();
        }
    }
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    public void ShowDialogOnCharacter(string tag)
    {
        if (dialogFlag)
        {
            dlgObj.dialogField.SetActive(false);
            dlgObj.text.SetActive(false);
            i = 0;
        }
        GameObject obj = GameObject.FindGameObjectWithTag(tag);
        dlgObj = obj.GetComponent<ShowDialog>();
         dlgObj.dialogField.SetActive(true);
        dlgObj.text.SetActive(true);
         dialogFlag = true;
    }
}
