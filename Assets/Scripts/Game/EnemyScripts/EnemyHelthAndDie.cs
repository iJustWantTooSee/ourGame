using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHelthAndDie : MonoBehaviour
{
    public int maxHelth = 100;
    int currentHelth;

    void Start()
    {
        currentHelth = maxHelth;   
    }

    public void TakeDamage(int damage)
    {
        currentHelth -= damage;

        if (currentHelth <= 0 )
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

}
