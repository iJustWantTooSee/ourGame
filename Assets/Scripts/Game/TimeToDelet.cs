using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToDelet : MonoBehaviour
{
    public float StartTime;
    public float EndTime;
    public float speedTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        StartTime += speedTime*Time.deltaTime;

        if (StartTime >= EndTime)
        {
            Destroy(gameObject);
        }
    }
}
