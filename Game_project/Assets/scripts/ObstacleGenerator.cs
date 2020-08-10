using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{

    public float obstaclespawnChance;
//    public GameObject Spawn1;
  //  public GameObject Spawn2;
    //public GameObject Spawn3;
    public GameObject[] Spawners;
    public GameObject obstacle;
    // Start is called before the first frame update
    void Start()
    {
        //float localChance = obstaclespawnChance;
        for (int j = 0; j < Spawners.GetLength(0); j++)
        {
            float luck = Random.RandomRange(0, 100);
            if (luck < obstaclespawnChance)
            {
                //spawn
                float offsetX = Random.RandomRange(-100, 100)/100f;
                float offsetScale = Random.RandomRange(-30, 30)/100f;
                //Debug.Log(offsetX + "   " + offsetScale);
                
                GameObject obs = Instantiate(obstacle, Spawners[j].transform.position, Spawners[j].transform.rotation, gameObject.transform);
                Vector3 scale = new Vector3(offsetScale, offsetScale);
                Vector3 pos = new Vector3(offsetX, 0f);
                obs.transform.localScale += scale;
                obs.transform.position += pos;

                obstaclespawnChance = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
