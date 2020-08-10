using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour

{

    private Text uiText;
    private string text;
    private int characterIndex;
    private float timePerCharacter;
    private float timer;

   public void AddWriter(Text uiText,string text, float timePerCharacter)
    {
        this.uiText = uiText;
        this.text = text;
        this.timePerCharacter = timePerCharacter;
        characterIndex = 0;
    }

    private void Update()
    {
           if(uiText != null)
        {
            timer -= Time.deltaTime;
            if(timer <= 0f)
            {
                //display next
                timer += timePerCharacter;
                characterIndex++;
                uiText.text = text.Substring(0, characterIndex);
            }
        }      
    }
}
