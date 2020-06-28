using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    public Animator anim;
    public AudioSource footsteps;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        footsteps = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.GetComponent<CharacterControl>().isInDialog)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                anim.SetBool("isWalking", true);
                if (!footsteps.isPlaying)
                    footsteps.Play();
            }
            else {
                anim.SetBool("isWalking", false);
                footsteps.Stop();
            }
        }
        else if (footsteps.isPlaying)
            footsteps.Stop();
    }
}
