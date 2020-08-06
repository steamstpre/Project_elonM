using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public static float speed;
    private GameObject bg;
    public string type;
    public bool startImm; //if true, platform will move immidiatly   
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (ButtonStart.start||startImm)
        {
            switch (type)
            {
                case "far":
                    speed = ChunkGenerator.getChunkSpeed() / 20f;
                    break;
                case "middle":
                    speed = ChunkGenerator.getChunkSpeed() / 15f;
                    break;
                case "close":
                    speed = ChunkGenerator.getChunkSpeed() / 10f;
                    break;
            }
           
            Vector3 pos = transform.position;
            pos.x -= speed;
            transform.position = pos;
            if (pos.x <= -42.85f)
            {
                GameObject newBg;
                switch (type)
                {
                    case "far":
                        bg = (GameObject)Resources.Load("prefabs/back", typeof(GameObject));
                        newBg = Instantiate(bg, new Vector3(54.8f, 0, 1), transform.rotation);
                        break;
                    case "middle":
                        bg = (GameObject)Resources.Load("prefabs/middle", typeof(GameObject));
                        newBg = Instantiate(bg, new Vector3(54.8f, 0, 0.8f), transform.rotation);
                        break;
                    case "close":
                        bg = (GameObject)Resources.Load("prefabs/close", typeof(GameObject));
                        newBg = Instantiate(bg, new Vector3(54.8f, 8, 0.5f), transform.rotation);
                        break;
                }
               
                Destroy(gameObject);
            }
        }
    }
}
