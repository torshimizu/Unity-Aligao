using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGame : MonoBehaviour
{
    void OnMouseDown()
    {
        GameControl.ResetExplore();
        Debug.Log("Reset Explore called from button");
    }
}
