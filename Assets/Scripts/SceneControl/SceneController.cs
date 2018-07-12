using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneController : MonoBehaviour {


    //private bool isFading;

    //private IEnumerator Start() // at start of scene do this?
    //{
    //    faderCanvasGroup.alpha = 1f;
    //    playerSaveData.Save(PlayerMovement.startingPositionKey, initialStartingPositionName);
    //    yield return StartCoroutine(LoadSceneAndSetActive(startingSceneName));
    //    StartCoroutine(Fade(0f));
    //}

    //public void FadeAndLoadScene(SceneReaction sceneReaction) // I don't have a sceneReaction
    //{
    //    if (!isFading) // if not fading
    //    {
    //        StartCoroutine(FadeAndSwitchScenes(sceneReaction.sceneName));
    //    }
    //}

    //private IEnumerator FadeAndSwitchScenes(string sceneName)
    //{
    //    yield return StartCoroutine(Fade(1f)); // fade to black
    //    if (BeforeSceneUnload != null) // if there are subscribers do the BeforeSceneUnload() action
    //        BeforeSceneUnload();
    //    yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex); // unload the current/active scene
    //    yield return StartCoroutine(LoadSceneAndSetActive(sceneName)); // load the next scene, make it active
    //    if (AfterSceneLoad != null) // if there are subscribers do the AfterSceneLoad action
    //        AfterSceneLoad();

    //    yield return StartCoroutine(Fade(0f)); // fade out from black
    //}

    //private IEnumerator LoadSceneAndSetActive(string sceneName)
    //{
    //    // I will probably want to just load one scene (maybe load more if I have more scenes for explore)
    //    // or maybe this 
    //    yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive); // load by scene name and add it to loaded scenes
    //    Scene newlyLoadedScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1); // make the last scene added the newly loaded scene 
    //    SceneManager.SetActiveScene(newlyLoadedScene); // make that scene active
    //}

    //private IEnumerator Fade(float finalAlpha)
    //{
    //    isFading = true;
    //    faderCanvasGroup.blocksRaycasts = true;
    //    float fadeSpeed = Mathf.Abs(faderCanvasGroup.alpha - finalAlpha) / fadeDuration;
    //    while (!Mathf.Approximately(faderCanvasGroup.alpha, finalAlpha))
    //    {
    //        faderCanvasGroup.alpha = Mathf.MoveTowards(faderCanvasGroup.alpha, finalAlpha,
    //            fadeSpeed * Time.deltaTime);
    //        yield return null;
    //    }
    //    isFading = false;
    //    faderCanvasGroup.blocksRaycasts = false;
    //}

}
