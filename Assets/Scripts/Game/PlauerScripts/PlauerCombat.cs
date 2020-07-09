using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlauerCombat : MonoBehaviour
{

    public Animator animator;
    public AudioSource HitSound;
    public Transform attakPoint;

    public LayerMask enemyLauers;

    public int attakeDamage = 100;
    public float attakRange = 1f;
    public float attakRate = 2f;
    float nextAttakTime = 0f;

    
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttakTime)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attak();
                nextAttakTime = Time.time + 0.5f / attakRate;
            }
        }
        
    }

    void Attak()
    {
        animator.SetTrigger("Attak");
        HitSound.Play();

        Collider2D[] hitEnemis = Physics2D.OverlapCircleAll(attakPoint.position,attakRange, enemyLauers);

        foreach(Collider2D enemy in hitEnemis)
        {
            enemy.GetComponent<EnemyHelthAndDie>().TakeDamage(attakeDamage);
        }

    }

    private void OnDrawGizmos()
    {
        if (attakPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attakPoint.position, attakRange);
    }
}
