using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enamy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Destroy(gameObject);
            PlayerMove.health -= 50;
            Debug.Log("true");
            Debug.Log(PlayerMove.health);


        }
    }
}
