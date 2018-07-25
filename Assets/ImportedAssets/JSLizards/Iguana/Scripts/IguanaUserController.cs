using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class IguanaUserController : MonoBehaviour {
	//IguanaCharacter iguanaCharacter;
	
	//void Start () {
	//	iguanaCharacter = GetComponent < IguanaCharacter> ();
	//}
	
	//void Update () {	
	//	if (Input.GetButtonDown ("Fire1")) {
	//		iguanaCharacter.Attack();
	//	}
		
	//	if (Input.GetKeyDown (KeyCode.H)) {
	//		iguanaCharacter.Hit();
	//	}
		
	//	if (Input.GetKeyDown (KeyCode.E)) {
	//		iguanaCharacter.Eat();
	//	}

	//	if (Input.GetKeyDown (KeyCode.K)) {
	//		iguanaCharacter.Death();
	//	}
		
	//	if (Input.GetKeyDown (KeyCode.R)) {
	//		iguanaCharacter.Rebirth();
	//	}		



	//}
	
	//private void FixedUpdate()
	//{
	//	float h = Input.GetAxis ("Horizontal");
	//	//float v = Input.GetAxis ("Vertical");
	//	iguanaCharacter.Move (v,h);
	//}

    public Animator iguanaAnimator;

    // Transforms to act as start and end markers for the journey.
    public Transform startMarker;
    public Transform endMarker;

    // Movement speed in units/sec.
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    void Start()
    {
        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    // Follows the target position like with a spring
    void Update()
    {
        // Distance moved = time * speed.
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed = current distance divided by total distance.
        float fracJourney = distCovered / journeyLength;
        Debug.Log(fracJourney); 
        iguanaAnimator.SetFloat("Forward", fracJourney);


        // Set our position as a fraction of the distance between the markers.
        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
    }
}

