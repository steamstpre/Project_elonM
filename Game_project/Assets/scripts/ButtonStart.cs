using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStart : MonoBehaviour
{
    public static bool start;
    public GameObject pauseChecker;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        this.Player.SetActive(false);
        this.gameObject.SetActive(true);

        start = false;
   //     Time.timeScale = 0;
        
    }

    private void OnMouseUp()
    {
        //   Time.timeScale = 1;
        this.Player.SetActive(true);
        this.gameObject.SetActive(false);
        start = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
