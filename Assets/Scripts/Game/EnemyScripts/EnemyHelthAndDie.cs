using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHelthAndDie : MonoBehaviour
{
    //звук смерти врага
    private AudioSource EnemyDeathSound;
    //звук удара ежа
    private AudioSource EjHit;

    //звук удара босса ежа
    private AudioSource BossEjHit;

    public int maxHelth = 100;
    int currentHelth;
    private UnityEngine.Object explocion;
    private UnityEngine.Object explocionEj;

    void Start()
    {
        EnemyDeathSound = GameObject.FindGameObjectWithTag("EnemyDeathSound").GetComponent<AudioSource>();
        EjHit = GameObject.FindGameObjectWithTag("EjHitSound").GetComponent<AudioSource>();
        BossEjHit = GameObject.FindGameObjectWithTag("BossEjHitSound").GetComponent<AudioSource>();
        currentHelth = maxHelth;
        explocion = Resources.Load("Explosion");
        explocionEj = Resources.Load("BossEjDeath");
    }

    public void TakeDamage(int damage)
    {
        currentHelth -= damage;


        if (currentHelth <= 0)
        {
            Die();
        }
        else
        {
            if (tag == "BossEj")
            {
                BossEjHit.Play();
                GameObject explocionEnemy = (GameObject)Instantiate(explocionEj);
                explocionEnemy.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * 40f, ForceMode2D.Impulse);
            }
            else
            {
                EjHit.Play();
                GameObject explocionEnemy = (GameObject)Instantiate(explocion);
                explocionEnemy.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * 40f, ForceMode2D.Impulse);
            }

        }
    }

    private void Die()
    {
        if (tag == "BossEj")
        {

            GameObject explocionEnemy = (GameObject)Instantiate(explocionEj);
            explocionEnemy.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * 40f, ForceMode2D.Impulse);

            Destroy(gameObject);
        }
        else
        {
            EnemyDeathSound.Play();
            GameObject explocionEnemy = (GameObject)Instantiate(explocion);
            explocionEnemy.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            explocionEnemy.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            Destroy(gameObject);
        }

    }

}
