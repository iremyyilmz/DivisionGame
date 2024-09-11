using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scor : MonoBehaviour
{
   private int totalScor;
   private int scorValue;

   [SerializeField]
   private Text scoreText;

    void Start()
    {
        scoreText.text = totalScor.ToString();
    }

    public void increaseScor(string difficultyLevel)
    {
        switch(difficultyLevel)
        {
            case "easy":
              scorValue = 5;
                break;

            case "medium":
              scorValue = 10;
                break;

            case "hard":
              scorValue = 15;
                break;
        }

        totalScor += scorValue;
        scoreText.text = totalScor.ToString();
    }
}