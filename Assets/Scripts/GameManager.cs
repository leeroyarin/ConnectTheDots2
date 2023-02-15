using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Timeline;

public class GameManager : MonoBehaviour
{
    public GameObject[] balls;
    public GameObject[] answerBall;


    public QuestionizerScript[] questionizer;

    public TextMeshProUGUI question;
    public TextMeshProUGUI HideUnhideButtonText;
    private int _questionNumber = 0;
    private int answerBallCounts = 0;

    private AudioManager audios;

    public GameObject InstructingAnimation;

    private void Awake()
    {
        audios = FindObjectOfType<AudioManager>();
        balls = GameObject.FindGameObjectsWithTag("ball");
        answerBall = GameObject.FindGameObjectsWithTag("answer");
    }
    private void Start()
    {
        FindObjectOfType<ContainerBehaviour>().OnBallEnter += CountAnswerBall;
        FindObjectOfType<ContainerBehaviour>().OnWrongBallEnter += ShowGameOver;

        foreach(GameObject b in balls)
        {
            b.GetComponent<Rigidbody2D>().isKinematic = true;
        }
        foreach (GameObject b in answerBall)
        {
            b.GetComponent<Rigidbody2D>().isKinematic = true;
        }

        QuestionDeclarer(0);

    }

    void QuestionDeclarer(int questionNumber)
    {
        question.text = questionizer[questionNumber].problem;
        int ballLenth = questionizer[questionNumber].balls.Count;
        int answerLength = questionizer[questionNumber].answer.Count;
        for(int i= 0; i < balls.Length; i++)
        {
            if (balls[i].CompareTag("ball"))
            {
                balls[i].GetComponentInChildren<TextMeshPro>().text = questionizer[questionNumber].balls[i].ToString();
            }
        }
        for (int i = 0; i < answerBall.Length-1; i++)
        {
            answerBall[i].GetComponentInChildren<TextMeshPro>().text = questionizer[questionNumber].answer[i].ToString();
        }
        _questionNumber = questionNumber;
    }

    public void CountAnswerBall()
    {
        answerBallCounts++;
        if(answerBallCounts >= answerBall.Length)
        {
            GameCompleteMenu();
        }
    }
    public void GameCompleteMenu()
    {
        FindObjectOfType<UIManager>().OnGameCompleted();
        audios.PlayGameCompleteSFX();
    }
    public void ShowGameOver()
    {
        FindObjectOfType<UIManager>().OnGameOver();
        audios.PlayGameFailureSFX();

    }
    bool ok;
    public void OnHideButtonClick()
    {
        if (!ok)
        {
            OnHide();
            ok = true;
        }
        else
        {
            OnUnhide();
            ok = false;
        }
    }
     void OnHide()
    {
        question.text = "";
        HideUnhideButtonText.text = "Show";
    }

     void OnUnhide()
    {
        question.text = questionizer[_questionNumber].problem;
        HideUnhideButtonText.text = "Hide";
    }

    public void ActivePhysicsInBalls()
    {
        foreach(GameObject b in balls)
        {
            b.GetComponent<Rigidbody2D>().isKinematic = false;
        }
        foreach (GameObject b in answerBall)
        {
            b.GetComponent<Rigidbody2D>().isKinematic = false;
        }
        if (InstructingAnimation == null)
            return;
        InstructingAnimation.SetActive(false);
    }
    

}
