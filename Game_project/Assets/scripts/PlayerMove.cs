using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;
using System;

public class PlayerMove : MonoBehaviour
{
    private const float spriteScalePlayerXY = 0.6679568f;
    private const float spriteScaleCyberTrackX = 1f;
    private const float spriteScaleCyberTrackY = 1f;
    private const float collisionScalePlayerX = 2.61f;
    private const float collisionScalePlayerY = 5.151879f;
    private const float collisionScaleCyberTrackX = 6.42f;
    private const float collisionScaleCyberTrackY = 2.13f;

    public static float JumpForce = 25;
    private int extraJumps;
    public int extraJumpValue;
    private Rigidbody2D _rg;
    public bool Ground;
    public LayerMask WhatIsGround;
    private BoxCollider2D _Cl;
    public static int score;
    public Text scoreText;
    public Text coinText;
    public static int coinAmount;
    public static bool death = false;
    public GameObject loosePanel;
    private int newScore;
    private Animator animator;
    public Image CyberTruck;
    public  Sprite[] spriteArray;
    public static SpriteRenderer sp;
    public static bool g;
    private bool jump;
 
    public static int health = 10;
    void Start()
    {
        jump = true;
        animator = GetComponent<Animator>();
        extraJumps = extraJumpValue;
        _rg = GetComponent<Rigidbody2D>();
        _rg.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
        _Cl = GetComponent<BoxCollider2D>();
        sp = GetComponent<SpriteRenderer>();
        //Physics2D.gravity
        changeToCT(false);

    }
    void Update()
    {
        Ground = Physics2D.IsTouchingLayers(_Cl, WhatIsGround);
        _rg.velocity = new Vector2(0, _rg.velocity.y);
        
        //extra jump 
        if (Ground)
        {
            animator.SetBool("onGround", true);
            extraJumps = extraJumpValue;

        }
        else
        {
            animator.SetBool("onGround", false);
        }

        if (Input.GetMouseButtonDown(0) && extraJumps > 0 && jump)
        {


            _rg.velocity = new Vector2(_rg.velocity.x, JumpForce);
            extraJumps--;

        }
        else if (Input.GetMouseButtonDown(0) && Ground && extraJumps == 0 && jump)
        {
            _rg.velocity = new Vector2(_rg.velocity.x, JumpForce);

        }
        
        
        dead();
        coinText.text = coinAmount.ToString();
        PlayerPrefs.SetInt("Coins", coinAmount);
        
       

    }
    void ChangeSp()
    {
        //this.gameObject.GetComponent<SpriteRenderer>().sprite = CyberTruck;
        // sp.sprite = CyberTruck;
        animator.GetComponent<Animator>().enabled = false;
        sp.sprite = spriteArray[1];
        
       /* if(sp.sprite == CyberTruck)
        {
            Debug.Log("real shit");
        }
        if(sp.sprite == null)
        {
            Debug.Log("pipka");
        }*/
       // Debug.Log("xita");
       


        }
    void CyberTruckHealth(Collision2D collision)
    {
     
            if (collision.transform.CompareTag("Kill_zone"))
            {
                Debug.Log("crushed(");
                health -= 5;
                Destroy(collision.gameObject);
                loosePanel.SetActive(false);
                if(health <= 0)
                {
                    ChunkGenerator.speed -= CyberTrack_MOvment.increaseSpeed;
                changeToCT(false);
                }
            }

        
    }
    
    void dead()
    {

        switch (death)
        {
            case false:

                score++;
                scoreText.text = score.ToString();
                break;
            case true:
                //score = newScore;
                scoreText.text = score.ToString();
                //Destroy(coinText);
                //Destroy(scoreText);
               
                PlayerPrefs.SetInt("Coins", coinAmount);
                break;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Kill_zone"))
        {
            if (sp.sprite == spriteArray[1])
            {
                loosePanel.SetActive(false);
                CyberTruckHealth(collision);
                g = true;
            }
            else
            {
                BackgroundMovement.speed = 0;
                ChunkGenerator.speed = 0;
                loosePanel.SetActive(true);
                //score = newScore;
                scoreText.text = score.ToString();
                death = true;
                doDeathStuff();
            }
           
        }

    }

    private void doDeathStuff()
    {
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Truck")
        {
            // ChangeSp();
            changeToCT(true);
            //  Debug.Log("yes");
            //CyberTruckHealth(collision);
            g = true;
            
        }
    }

    private void changeToCT(bool v)
    {
        if (v)
        {
            //enable CT
            animator.enabled = false;
            sp.sprite = spriteArray[1];

            Vector3 ctSpriteSize = new Vector3(spriteScaleCyberTrackX, spriteScaleCyberTrackY);
            gameObject.transform.localScale = ctSpriteSize;
            Vector2 ctColSize = new Vector2(collisionScaleCyberTrackX, collisionScaleCyberTrackY);
            _Cl.size = ctColSize;
            jump = false;
        }
        else
        {
            //disable CT
            animator.enabled = true;
            sp.sprite = spriteArray[0];

            Vector3 playerSpriteSize = new Vector3(spriteScalePlayerXY, spriteScalePlayerXY);
            gameObject.transform.localScale = playerSpriteSize;
            //  Debug.Log("Jopa");
            Vector2 playerColSize = new Vector2(collisionScalePlayerX, collisionScalePlayerY);
            _Cl.size = playerColSize;
            jump = true;
        }

    }
}