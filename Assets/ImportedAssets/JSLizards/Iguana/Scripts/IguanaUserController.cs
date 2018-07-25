using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class IguanaUserController : MonoBehaviour {

    public Animator iguanaAnimator;

    // Transforms to act as start and end markers for the journey.
    public Transform startMarker;
    public Transform endMarker;
    private Transform destination;
    private Transform start;

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

        // Start the animation.
        iguanaAnimator.SetFloat("Forward", 0.5f);

        // set the direction of the movement.
        start = startMarker;
        destination = endMarker;


    }

    // Follows the target position like with a spring
    void Update()
    {
        // Distance moved = time * speed.
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed = current distance divided by total distance.
        float fracJourney = distCovered / journeyLength;
         
        transform.position = Vector3.Lerp(start.position, destination.position, fracJourney);


        if(fracJourney > 0.99f)
        {
            startTime = Time.time;
            Debug.Log("switching directions");
            if(destination == startMarker)
            {
                start = startMarker;
                destination = endMarker;
                transform.RotateAround(transform.position, transform.up, 180f);
            }
            else
            {
                start = endMarker;
                destination = startMarker;
                transform.RotateAround(transform.position, transform.up, 180f);
            }
        }
   
    }
}

