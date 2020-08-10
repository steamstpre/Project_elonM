
using UnityEngine;

public class CyberTrack_MOvment : MonoBehaviour
{
    public float increaseSpeed = 0.2f;
    public GameObject Player;
    public Sprite CyberTruck;
    private SpriteRenderer sp;
    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {


            // Player.gameObject.GetComponent<SpriteRenderer>().sprite = CyberTruck;
            //sp.sprite = CyberTruck;
            BackgroundMovement.speed += increaseSpeed;
            ChunkGenerator.speed += increaseSpeed;
            Destroy(gameObject);

            
            
            
        }
    }
}
