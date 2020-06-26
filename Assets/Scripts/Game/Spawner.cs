using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    public Transform SpawPos;
    public GameObject Coner;
    public int RangeCorner;
    public float TimeSpawn;
    void Start()
    {
        StartCoroutine(SpawnCD());
    }

   
    // Update is called once per frame
    void Repeat()
    {
        StartCoroutine(SpawnCD());
    }

    IEnumerator SpawnCD()
    {
        yield return new WaitForSeconds(TimeSpawn);
        Instantiate(Coner,new Vector3(Random.Range(SpawPos.position.x - RangeCorner, SpawPos.position.x + RangeCorner), SpawPos.position.y, SpawPos.position.z), Quaternion.identity);
        Repeat();
    }
}
