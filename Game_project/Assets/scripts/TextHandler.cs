using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class TextHandler : MonoBehaviour
{
    private string text = "Привет. Вижу ты собираешь акции теслы. Но как профессионал, скажу тебе, она просто пузырь, который скоро лопнет. \n Но не переживай.Ты можешь сейчас же купить у меня акции тойоты и со временем приумножить свое состояние в разы.";
    public Text uiText;
    private int characterIndex;
    private float timePerCharacter;
    private float timer;
    public GameObject timeline;

    void Start()
    {

        // Debug.Log("WAKAWAKA");
        // TextWriter.AddWriter(textUi, Text, 1f);
        AddWriter(text, 0.08f);
    }
   
    public void AddWriter(string text, float timePerCharacter)
    {
        this.text = text;
        this.timePerCharacter = timePerCharacter;
        characterIndex = 0;
        timeline.GetComponent<PlayableDirector>().Pause();
    }

    private void Update()
    {
        if (uiText != null)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                //display next
                timer += timePerCharacter;
                characterIndex++;
                uiText.text = text.Substring(0, characterIndex) + "<color=#00000000>" + text.Substring(characterIndex) + "</color>";
                if(characterIndex == text.Length)
                {
                    uiText = null;
                    timeline.GetComponent<PlayableDirector>().Play();
                }
            }
        }
    }
}
