using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHelthAndDie : MonoBehaviour
{
    public int maxHelth = 100;
    int currentHelth;
    private UnityEngine.Object explocion;

    void Start()
    {
        currentHelth = maxHelth;
        explocion = Resources.Load("Explosion");
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
        GameObject explocionEnemy = (GameObject)Instantiate(explocion);
        explocionEnemy.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        Destroy(gameObject);
    }

}
