using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {


            // Player.gameObject.GetComponent<SpriteRenderer>().sprite = CyberTruck;
            //sp.sprite = CyberTruck;
            PlayerMove.extraJumps += 1;
            Destroy(gameObject);


            // PlayerMove.JumpForce += increaseSpeed;

        }
    }
}
