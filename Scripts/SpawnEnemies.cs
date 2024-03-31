using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{

    public List<GameObject> enemiesList = new List<GameObject>();

    private float timeCount; 
    public float spawnTime;


    private void Start()
    {
        SpawnEnemy();
    }

    private void Update()
    {
        timeCount += Time.deltaTime;

        if (timeCount >= spawnTime) 
        {
            //Instanciar inimigos
            SpawnEnemy();
            timeCount = 0;
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemiesList[0], transform.position + new Vector3(0, Random.Range(-2.5f, 2.5f), 0), transform.rotation);
    }

}
