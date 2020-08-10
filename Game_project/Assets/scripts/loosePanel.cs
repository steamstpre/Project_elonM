using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loosePanel : MonoBehaviour
{
    public Text scoreText;
    public Text coinText;
    private int a;

    // Start is called before the first frame update
    void Start()
    {

       // a = PlayerPrefs.GetInt("Coins", PlayerMove.coinAmount);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = PlayerMove.score.ToString();
        coinText.text = PlayerMove.coinAmount.ToString();
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("MainScene");
        BackgroundMovement.speed = 0.3f;
        ChunkGenerator.speed = 0.3f;
    }
    public void Shop()
    {

    }
    public void Settings()
    {

    }
}
