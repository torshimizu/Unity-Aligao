using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGameButton : MonoBehaviour {

    [SerializeField]
    private GameObject resetGameButton;

    void Start()
    {

        //if(GameControl.seenExploreItems != null && GameControl.seenExploreItems.Count > 0)
        if(!GameControl.initialExploreVisit)
        {
            resetGameButton.SetActive(true);
        }
    }
}
