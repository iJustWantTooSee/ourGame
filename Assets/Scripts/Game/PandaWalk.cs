using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PandaWalk : MonoBehaviour
{
    public float speed = 10f;
    public Transform PandaTransform;
    public Transform Fox; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Fox.position.x > 175)
        {
            if (PandaTransform.position.x> 185) 
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
            
        }
    }
}
