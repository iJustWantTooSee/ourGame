using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ejHit : MonoBehaviour
{

    public Animator animator;

    private float runSpeed = 7f;

    public Transform target;
    public Transform left;
    public Transform right;


    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target.transform.position.x >= left.transform.position.x && target.transform.position.x <= right.transform.position.x)
        {
            //walk
            animator.SetBool("hitEj", true);
            runSpeed = 10f;
            transform.Translate(Vector2.left * runSpeed * Time.deltaTime);
            if (transform.position.x <= target.transform.position.x)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);

            }
            else if (transform.position.x >= target.transform.position.x)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
        else
        {
            runSpeed = 7f;
            animator.SetBool("hitEj", false);
            transform.Translate(Vector2.left * runSpeed * Time.deltaTime);

            if (transform.position.x <= left.position.x)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);

            }
            else if (transform.position.x >= right.position.x)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }

    }
}
