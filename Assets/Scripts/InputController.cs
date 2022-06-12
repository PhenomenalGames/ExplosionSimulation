using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    bool isPressed=false;
    ObjectController objectController;
    private void Awake()
    {
        objectController = GetComponent<ObjectController>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            isPressed = true;
           
        }
    }
    void FixedUpdate()
    {
        if (isPressed)
        {
            Press();
        }
    }
    void Press()
    {
        objectController.Action();
        isPressed = false;
        Debug.Log("pressed");
    }
}
