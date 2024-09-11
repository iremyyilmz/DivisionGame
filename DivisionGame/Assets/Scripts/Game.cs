using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Game : MonoBehaviour
{
    [SerializeField]
     public GameObject squarePrefab;

     [SerializeField]
     public Transform squarePanel;

     [SerializeField]
     public Text questionText;

     public GameObject[] squareArray = new GameObject[20];

     [SerializeField]
     public Transform questionPanel;

     List<int> divisionValue = new List<int>();

     int dividedNumber, divisorNumber;
     int numberOfQuestion;
     int buttonValue;
     int correctAnswer;

     string difficultyQuestion;
     int chance;

     bool buttonpressed;

     ChancePanel chancepanel;

     Scor scor;

     [SerializeField]
     private Sprite[] squareSprites;

     GameObject currentSquare;

     [SerializeField]
      private GameObject resultPanel;

      [SerializeField]
      AudioSource audioSource;

      public AudioClip buttonClick;

    private void Awake()
    {
        chance = 3;

        audioSource = GetComponent<AudioSource>();

        resultPanel.GetComponent<RectTransform>().localScale = Vector3.zero;

        chancepanel = Object.FindObjectOfType<ChancePanel>();
        scor = Object.FindObjectOfType<Scor>();

        chancepanel.ChanceControl(chance);
    }
    
    void Start()
    {
        buttonpressed = false;
        questionPanel.GetComponent<RectTransform>().localScale = Vector3.zero;

        squareCreate();
    }

    public void squareCreate()
    {
        for(int i = 0; i < 20; i++)
        {
            GameObject square = Instantiate(squarePrefab, squarePanel);
            square.transform.GetChild(1).GetComponent<Image>().sprite = squareSprites[Random.Range(0, squareSprites.Length)];
            square.transform.GetComponent<Button>().onClick.AddListener(() => ButtonPressed());
            squareArray[i] = square;
        }

        DivisionValuesText();
        StartCoroutine(DoFade());

        Invoke("OpenQuestionPanel", 1.5f);
    }

    void ButtonPressed()
    {
        if(buttonpressed)
        {
            audioSource.PlayOneShot(buttonClick);

            buttonValue = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text);
            
            currentSquare = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;

            CheckResult();
        }
        
    }

    void CheckResult()
    {
        if(buttonValue == correctAnswer)
        {
            currentSquare.transform.GetChild(1).GetComponent<Image>().enabled = true;
            currentSquare.transform.GetChild(0).GetComponent<Text>().enabled = false;
            currentSquare.transform.GetComponent<Button>().interactable = false;

            scor.increaseScor(difficultyQuestion);
            divisionValue.RemoveAt(numberOfQuestion);

            if(divisionValue.Count>0)
            {
                OpenQuestionPanel();
            }
            else
            {
                GameOver();
            }
        }
        else
        {
            chance--;
            chancepanel.ChanceControl(chance);
        }

        if(chance <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        buttonpressed = false;
        resultPanel.GetComponent<RectTransform>().DOScale(1, 0.3f).SetEase(Ease.OutBack);
    }

    IEnumerator DoFade()
    {
        foreach(var square in squareArray)
        {
            square.GetComponent<CanvasGroup>().DOFade(1, 0.2f);

            yield return new WaitForSeconds(0.06f);
        }
    }

    private void DivisionValuesText()
    {
        foreach(var square in squareArray)
        {
            int randomValue = Random.Range(1,13);
            divisionValue.Add(randomValue);

            square.transform.GetChild(0).GetComponent<Text>().text = randomValue.ToString();
        }
    }

    void OpenQuestionPanel()
    {
        AskQuestion();
        buttonpressed = true;
        questionPanel.GetComponent<RectTransform>().DOScale(1, 0.3f).SetEase(Ease.OutBack);
    }

    void AskQuestion()
    {
        divisorNumber = Random.Range(2,11);

        numberOfQuestion = Random.Range(0, divisionValue.Count);
        correctAnswer = divisionValue[numberOfQuestion];

        dividedNumber = divisorNumber * correctAnswer;

        if(dividedNumber <= 40)
        {
            difficultyQuestion = "easy";
        }
        else if(dividedNumber > 40 && dividedNumber < 80)
        {
            difficultyQuestion = "medium";
        }
        else
        {
            difficultyQuestion = "hard";
        }

        questionText.text = dividedNumber.ToString() + " : " + divisorNumber.ToString();
 }
}
