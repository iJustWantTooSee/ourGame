using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame

    private GameObject Character;

    private void Start()
    {
        Character = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Character.GetComponent<hero>().isInCutscene = true;
    }
}
