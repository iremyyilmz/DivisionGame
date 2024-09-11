using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
   public void RestartGame()
   {
        SceneManager.LoadScene("Game");
   }

   public void MainMenu()
   {
        SceneManager.LoadScene("Menu");
   }
}

