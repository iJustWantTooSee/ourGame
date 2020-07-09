using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surprise : MonoBehaviour
{
    public float runSpeed = 4;
    public Transform left;
    public Transform playerTrigger;


    private bool moveingLeft = true;
    // Start is called before the first frame update
    void Start()
    {
        playerTrigger = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTrigger.transform.position.x >= left.transform.position.x)
        {
            //wal
            transform.Translate(Vector2.left * runSpeed * Time.deltaTime);
            if (transform.position.x <= playerTrigger.transform.position.x)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);

            }
            else if (transform.position.x >= playerTrigger.transform.position.x)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
    }
}
