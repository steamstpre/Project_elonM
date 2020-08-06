using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSpawn : MonoBehaviour
{

    public int spawnChance;
    // Start is called before the first frame update
    void Start()
    {
        int luck = Random.RandomRange(0, 100);
        if (luck < spawnChance)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
