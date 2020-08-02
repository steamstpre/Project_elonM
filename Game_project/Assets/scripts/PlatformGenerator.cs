using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public float platformSpawnChance;
    public GameObject platformSpawn1;
    public GameObject platformSpawn2;
    public GameObject platformSpawn3;
    public GameObject platformSpawn4;
    public GameObject[,] platformSpawners;
    public GameObject platform;
    // Start is called before the first frame update
    void Start()
    {
        platformSpawners = new GameObject[,] { { platformSpawn1, platformSpawn2 }, { platformSpawn3, platformSpawn4 } };
        for (int i = 0; i < platformSpawners.GetLength(0); i++)
        {
            float localChance = platformSpawnChance;
            for (int j = 0; j < platformSpawners.GetLength(1); j++)
            {
                float luck = Random.RandomRange(0, 100);
               // Debug.Log(luck);
                if (luck < localChance)
                {
                    //spawn platform
                    Instantiate(platform, platformSpawners[i, j].transform.position, platformSpawners[i, j].transform.rotation, gameObject.transform);

                    localChance /= 4;
                }
                else
                {
                    //increase chance
                    localChance *= 2;
                }
                //Debug.Log(luck + " duck");
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
