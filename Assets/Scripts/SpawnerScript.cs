using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{

    public float spawnOffsetY;

    public List<GameObject> enemyPrefabs = new List<GameObject>();

    public List<GameObject> pickupPrefabs = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemies", 2, 1f);
        InvokeRepeating("SpawnPickup", 10, 10);
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
            int randomizer = Random.Range(0, 10);
            Debug.Log("Spawn " + randomizer);

            if (randomizer > 7) //rocket launcher
            {
                toSpawn = 2;
            }

            else if (randomizer > 0)
            {
                toSpawn = 1;
            }
            else //rocket
            {
                toSpawn = 0;
            }
            Instantiate(enemyPrefabs[toSpawn], new Vector2(10, spawnOffsetY), enemyPrefabs[toSpawn].transform.rotation);
        }
    }

    void SpawnPickup()
    {
        if (GameManager.instance.player != null)
        {
            spawnOffsetY = Random.Range(-4f, 4f);
            Instantiate(pickupPrefabs[Random.Range(0, pickupPrefabs.Count)], new Vector2(10, spawnOffsetY), Quaternion.identity);
        }
    }

}
