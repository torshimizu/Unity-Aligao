using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtonClick : MonoBehaviour
{
    [SerializeField]
    private GameObject verificationPanel;

    public void HandleClick()
    {
        // do not activate the pop up panel if the game is over
        // not sure what will happen to unanswered questions and everything else set up in QuizManager
        if (QuizManager.gameOver)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            verificationPanel.SetActive(true);
        }
    }

}
