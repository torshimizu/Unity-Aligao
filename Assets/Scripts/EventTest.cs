using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class EventTest : MonoBehaviour
{

    private UnityAction someListener;

    void Awake()
    {
        someListener = new UnityAction(SomeFunction);
    }

    void OnEnable()
    {
        EventManager.StartListening("test", someListener);
        EventManager.StartListening("test2", AnotherTestFunction);

    }

    void OnDisable()
    {
        EventManager.StopListening("test", someListener);

    }

    void SomeFunction()
    {
        Debug.Log("Some Function was called!");
    }

    void AnotherTestFunction()
    {
        Debug.Log("Another Test Fuction was called!");
    }

}