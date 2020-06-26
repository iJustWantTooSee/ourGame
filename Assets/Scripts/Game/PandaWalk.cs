using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PandaWalk : MonoBehaviour
{
    public float speed = 10f;
    public Transform PandaTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PandaTransform.position.x > 2)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }
}
