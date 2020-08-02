using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAboveFix : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private Collider2D collider;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        collider = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < gameObject.transform.position.y)
        {
            collider.enabled = false;
        }
        else
        {
            if (gameObject.transform.position.y - player.transform.position.y <= -2)
            {
                collider.enabled = true;
            }
        }
    }
}
