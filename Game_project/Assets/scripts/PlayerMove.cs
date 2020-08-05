using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMove : MonoBehaviour
{
    public float JumpForce;
    private int extraJumps;
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

    void Start()
    {

        extraJumps = extraJumpValue;
        _rg = GetComponent<Rigidbody2D>();
        _rg.constraints = RigidbodyConstraints2D.FreezeRotation;
        _Cl = GetComponent<Collider2D>();


    }
    void Update()
    {
        Ground = Physics2D.IsTouchingLayers(_Cl, WhatIsGround);
        _rg.velocity = new Vector2(0, _rg.velocity.y);
        
        //extra jump 
        if (Ground)
        {
            extraJumps = extraJumpValue;

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
        //score++;
        //scoreText.text = score.ToString();
        dead();
        coinText.text = coinAmount.ToString();
        


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
            
            BackgroundMovement.speed = 0;
            ChunkGenerator.speed = 0;
            loosePanel.SetActive(true);
            score = newScore;
            scoreText.text = newScore.ToString();
            death = true;
        }
    }
}