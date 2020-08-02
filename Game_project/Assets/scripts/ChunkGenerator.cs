using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ChunkGenerator : MonoBehaviour
{
  //  private GameObject spawner;
    private GameObject chunk;
    public static float speed = 0.1f;
    public GameObject[] chunks;
    private bool gaveChild;

    // Start is called before the first frame update
    void Start()
    {
        gaveChild = false;
      //  spawner = GameObject.FindGameObjectWithTag("Respawn");
    }

    // Update is called once per frame
    void Update()
    {
        if (ButtonStart.start)
        {
            Vector3 pos = transform.position;
            pos.x -= speed;
            transform.position = pos;
            
            if (transform.position.x <= (-35.75f)&&!gaveChild)
            {
                gaveChild = true;
                int i = Random.RandomRange(0, chunks.Length);
                chunk = chunks[i];
             //   chunk = (GameObject)Resources.Load("prefabs/chunk", typeof(GameObject));
                // GameObject newChunk = Instantiate(chunk, spawner.transform.position, spawner.transform.rotation);
                GameObject newChunk = Instantiate(chunk, new Vector3(71.2f, 0f), transform.rotation);
                newChunk.name = chunk.name;
            }
            if(transform.position.x < (-35.75f))
                Destroy(this.gameObject);
        }
    }

    public static float getChunkSpeed() => speed;
}
