using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : MonoBehaviour
{

    public float speed=4;
    public Transform point_1;
    public Transform point_2;


    private bool moveingLeft = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x <= point_1.position.x)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            moveingLeft = true;
        }
        else if (transform.position.x >= point_2.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            moveingLeft = false;
        }
    }
}
