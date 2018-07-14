using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class QuizManager : MonoBehaviour {

    // this will be all questions
    public Question[] questions;
    // this is a list of remaining questions
    private static List<Question> unansweredQuestions;
    private static int scoreCount = 0;
    private static int foundItemCount;
    public static bool gameOver;

    // the current question
    private Question currentObject;
    // the object in the game of that question
    private GameObject currentGameObject;

    public AudioClip correctAudio;
    public AudioClip incorrectAudio;
    public AudioSource audioSource;

    [SerializeField]
    private Transform propsHolder;

    [SerializeField]
    private Text responseText;

    [SerializeField]
    private Text scoreKeeper;

    [SerializeField]
    private Text hintText;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float timeBetweenQuestions = 3f;


	private void Start()
	{
        // if no explore items
        // game over = true
        // start animation for no words
        // don't set unanswered questions
        if (GameControl.seenExploreItems == null)
        {
            gameOver = true;
            animator.SetBool("NoWords", true);

        }
        else
        {
            gameOver = false;
            animator.SetBool("NoWords", false);
            if (unansweredQuestions == null)
            {
                //unansweredQuestions = questions.ToList<Question>(); // turns the array into a list
                SetUnansweredQuestions();
            }

            if (unansweredQuestions.Count != 0)
            {
                SetCurrentQuestion();

                // finding the inactive item
                currentGameObject = propsHolder.Find(currentObject.objectName).gameObject;

                // activating the item
                currentGameObject.SetActive(true);
                scoreKeeper.text = scoreCount.ToString() + "/" + foundItemCount;
            }
        }

	}


    void SetCurrentQuestion() 
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentObject = unansweredQuestions[randomQuestionIndex];
        SetHintText();
    }

    void SetHintText() 
    {
        hintText.text = currentObject.hint;
    }

    IEnumerator TransitionToNextQuestion() 
    {
        // remove from the list
        unansweredQuestions.Remove(currentObject);

        // once you get to the end of unanswered questions
        if(unansweredQuestions.Count == 0)
        {
            gameOver = true;
            animator.SetTrigger("QuizEnd");
        }
        else
        {
            // not sure what this does - something about pausing for a bit then doing more
            yield return new WaitForSeconds(timeBetweenQuestions);

            // load this same scene 
            SetCurrentQuestion();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

    public void UserAnswerCorrect(GameObject textObject) 
    {
        string userText = textObject.GetComponentInChildren<Text>().text;
        if (userText == currentObject.answer) 
        {
            responseText.text = "CORRECT!";
            scoreCount += 1;
            audioSource.clip = correctAudio;
            audioSource.Play();
            animator.SetTrigger("ResponseGiven");
            StartCoroutine(TransitionToNextQuestion());

        }
        else 
        {
            responseText.text = "wrong";
            audioSource.clip = incorrectAudio;
            audioSource.Play();
            animator.SetTrigger("ResponseGiven");

        }

    }

    public void VerificationYesButtonClick()
    {
        // reset the scene
        scoreCount = 0;
        unansweredQuestions = null;

        SceneManager.LoadScene(0);
    }

    private void SetUnansweredQuestions()
    {

        //if(GameControl.seenExploreItems == null)
        //{
        //    gameOver = true;
        //    animator.SetBool("NoWords", true);
        //}
        //else
        //{
            List<string> exploreItems = GameControl.seenExploreItems;
            foundItemCount = exploreItems.Count;
            unansweredQuestions = new List<Question>();

            foreach (Question q in questions)
            {
                if (exploreItems.Contains(q.objectName))
                {
                    Debug.Log(q.objectName);
                    unansweredQuestions.Add(q);
                }
            }
  
        //}

    }

}
