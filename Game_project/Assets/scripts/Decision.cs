using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Decision : MonoBehaviour
{

    public bool isRight;
    public string nextScene;
    public string endScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseUp()
    {
        if (isRight)
        {
            //right decision
            //next lvl
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            //Game Over
            SceneManager.LoadScene(endScene);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
