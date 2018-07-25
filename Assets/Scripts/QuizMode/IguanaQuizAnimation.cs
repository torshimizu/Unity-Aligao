using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IguanaQuizAnimation : MonoBehaviour {
    public Animator iguanaAnimator;

	private void Start()
	{
        iguanaAnimator.SetFloat("Forward", 0.5f);
	}

	private void OnDisable()
	{
        iguanaAnimator.SetFloat("Forward", 1.0f);
    }
}
