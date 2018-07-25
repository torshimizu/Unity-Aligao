using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneControl : MonoBehaviour {

    [SerializeField]
    private Camera camera;

    float speed = 90.0f;
	
	// Update is called once per frame
	void Update () 
    {

        UpdateCameraPosition();


        // this might not work if putting rigidbody/collider on the plane
        // plane forward and banking
        transform.position += transform.forward * Time.deltaTime * speed;
        speed -= transform.forward.y * Time.deltaTime + 50.0f;

        // setting minimum speed
        if (speed < 35.0f)
            speed = 35.0f;
        
        transform.Rotate(-Input.GetAxis("Vertical"), 0.0f, -Input.GetAxis("Horizontal"));

         //should figure out a rigidbody for this
        float terrainHeightWhereWeAre = Terrain.activeTerrain.SampleHeight(transform.position);

         //ensuring that you can't hit the ground
        if(terrainHeightWhereWeAre > transform.position.y)
            transform.position = new Vector3(transform.position.x,
                                             terrainHeightWhereWeAre + 10.0f,
                                             transform.position.z);

	}



    void UpdateCameraPosition()
    {
        Vector3 moveCamTo = transform.position - transform.forward * 10.0f + Vector3.up * 5.0f;

        float bias = 0.96f;

        camera.transform.position = camera.transform.position * bias +
            moveCamTo * (1.0f - bias);
        
        camera.transform.LookAt(transform.position + transform.forward * 30.0f);
    }
}
