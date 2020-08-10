using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;


public class PlayerMove : MonoBehaviour
{
    public float JumpForce = 2f;
    public static int extraJumps;
    public int extraJumpValue;
    private Rigidbody2D _rg;
    public bool Ground;
    public LayerMask WhatIsGround;
    private Collider2D _Cl;
    public static int score;
    public Text scoreText;
    public Text coinText;
    public static int coinAmount;
    public static bool death = false;
    public GameObject loosePanel;
    private int newScore;
    private Animator animator;
    public Image CyberTruck;
    public Sprite[] spriteArray;
    public static SpriteRenderer sp;
    public static bool g;

    public static int health = 10;
    void Start()
    {
        animator = GetComponent<Animator>();
        extraJumps = extraJumpValue;
        _rg = GetComponent<Rigidbody2D>();
        _rg.constraints = RigidbodyConstraints2D.FreezeRotation;
        _Cl = GetComponent<Collider2D>();
        sp = GetComponent<SpriteRenderer>();



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

        if (Input.GetMouseButtonDown(0) && extraJumps > 0)
        {


            _rg.velocity = new Vector2(_rg.velocity.x, JumpForce);
            extraJumps--;

        }
        else if (Input.GetMouseButtonDown(0) && Ground && extraJumps == 0)
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
        if (sp.sprite == CyberTruck)
        {
            Debug.Log("real shit");
        }
        if (sp.sprite == null)
        {
            Debug.Log("pipka");
        }
        Debug.Log("xita");
        g = true;



    }
    void CyberTruckHealth()
    {
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.CompareTag("Kill_zone"))
            {
                health -= 20;

                loosePanel.SetActive(false);
                if (health == 0)
                {
                    animator.GetComponent<Animator>().enabled = true;
                    sp.sprite = spriteArray[0];
                    g = false;
                }
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
                score = newScore;
                scoreText.text = newScore.ToString();

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
                CyberTruckHealth();
                g = true;
            }
            else
            {
                BackgroundMovement.speed = 0;
                ChunkGenerator.speed = 0;
                loosePanel.SetActive(true);
                score = newScore;
                scoreText.text = newScore.ToString();
                death = true;
            }

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Truck")
        {
            ChangeSp();
            Debug.Log("yes");
            CyberTruckHealth();
            g = true;

        }
        if (collision.tag == "Rocket")
        {

        }
    }


}