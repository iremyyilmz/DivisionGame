using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    public GameObject playButton, exitButton;

    // Start is called before the first frame update
    void Start()
    {
        FadeOut();
    }

    public void FadeOut()
    {
        playButton.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
        exitButton.GetComponent<CanvasGroup>().DOFade(1, 0.5f).SetDelay(0.4f);

    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
}
