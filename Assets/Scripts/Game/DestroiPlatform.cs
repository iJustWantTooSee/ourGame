using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroiPlatform : MonoBehaviour
{
    public Transform platforma;
    public float deletForY; //при достяжении этой координаты удаляется объект
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (platforma.position.y < deletForY)
        {
            Destroy(gameObject);
        }
    }
}
