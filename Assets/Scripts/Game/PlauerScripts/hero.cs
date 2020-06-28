using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class hero : MonoBehaviour
{
	public AudioSource FootstepsSound, CrouchingSound, JumpingSound;
	public CharacterController2D controller;
	public Animator animator;
	public Transform trig;
	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

	// Update is called once per frame
	void Update()
	{

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		if (Mathf.Abs(horizontalMove) > 0.01 && !crouch)
		{
			if (!FootstepsSound.isPlaying)
				FootstepsSound.Play();
		}
		else
			FootstepsSound.Stop();
		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("IsJumping", true);
			if (!JumpingSound.isPlaying)
				JumpingSound.Play();
		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
			if (!CrouchingSound)
				CrouchingSound.Play();
		}
		else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
			CrouchingSound.Stop();
		}
	
	}

	public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
		JumpingSound.Stop();
	}

	public void OnCrouching(bool isCrouching)
	{
		animator.SetBool("IsCrouching", isCrouching);
	}

	void FixedUpdate()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}
