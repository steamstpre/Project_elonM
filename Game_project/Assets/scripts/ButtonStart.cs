using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonStart : MonoBehaviour
{
    public static bool start;
    public GameObject pauseChecker;
    public GameObject Player;
    public GameObject coinText;
    
    // Start is called before the first frame update
    void Start()
    {
        this.Player.SetActive(false);
        this.gameObject.SetActive(true);
        this.coinText.SetActive(false);
        
        start = false;
   //     Time.timeScale = 0;
        
    }

    private void OnMouseUp()
    {
        //   Time.timeScale = 1;
        this.Player.SetActive(true);
        this.gameObject.SetActive(false);
        this.coinText.SetActive(true);

        start = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
