using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{

    public float spawnOffsetY;

    public List<GameObject> enemyPrefabs = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemies", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemies()
    {
        if (GameManager.instance.player != null)
        {
            spawnOffsetY = Random.Range(-4f, 4f);

            int toSpawn;

            if (Random.Range(0, 5) == 0) //rocket
            {
                toSpawn = 0;
            }
            else
            {
                toSpawn = 1;
            }
            Instantiate(enemyPrefabs[toSpawn], new Vector2(10, spawnOffsetY), enemyPrefabs[toSpawn].transform.rotation);
        }
        
        
    }
}
