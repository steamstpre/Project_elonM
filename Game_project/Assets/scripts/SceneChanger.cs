using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{

    public GameObject scoreText;
    public string nextScene;
    public int maxScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreText.GetComponent<Text>().text.Equals(maxScore.ToString()))
        {
            StartCoroutine(changeScene());
        }
    }

    IEnumerator changeScene()
    {

        yield return new WaitForSeconds(3f);

      

        SceneManager.LoadScene(nextScene);
    }
}
