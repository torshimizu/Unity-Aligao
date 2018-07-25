using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightModeButton : MonoBehaviour {

    [SerializeField]
    private GameObject flightModeButton;

    void Start()
    {

        //if(GameControl.seenExploreItems != null && GameControl.seenExploreItems.Count > 0)
        if(!GameControl.GetPrizeStatus())
        {
            flightModeButton.SetActive(true);
        }
    }
}
