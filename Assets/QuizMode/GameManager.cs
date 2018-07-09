using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameManager : MonoBehaviour {

    // this will be all questions
    public Question[] questions;
    // this is a list of remaining questions
    private static List<Question> unansweredQuestions;

    private Question currentObject;
    private GameObject currentGameObject;
    //private GameObject responseTextObject;

    [SerializeField]
    private Text responseText;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float timeBetweenQuestions = 3f;

	private void Start()
	{
        if (unansweredQuestions == null || unansweredQuestions.Count == 0) {
            unansweredQuestions = questions.ToList<Question>(); // turns the array into a list
        }

        SetCurrentQuestion();

        // finding the ACTIVE game object
        currentGameObject = GameObject.Find(currentObject.objectName);
        // activating the inactive child
        currentGameObject.transform.Find(currentObject.objectName).gameObject.SetActive(true);
	}

    void SetCurrentQuestion() 
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentObject = unansweredQuestions[randomQuestionIndex];
    }

    IEnumerator TransitionToNextQuestion() 
    {
        // remove from the list
        unansweredQuestions.Remove(currentObject);

        // not sure what this does - something about pausing for a bit then doing more
        yield return new WaitForSeconds(timeBetweenQuestions);

        // load this same scene 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void UserAnswerCorrect(GameObject textObject) 
    {
        string userText = textObject.GetComponentInChildren<Text>().text;
        if (userText == currentObject.answer) 
        {
            responseText.text = "CORRECT!";
        }
        else 
        {
            responseText.text = "wrong - " + currentObject.answer;
        }

        animator.SetTrigger("responseGiven");
        StartCoroutine(TransitionToNextQuestion());
    }
}
