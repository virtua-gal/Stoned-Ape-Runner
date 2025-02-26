using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PressEnterToStart : MonoBehaviour
{
    public Button startButton;

// Reference to the InputActionAsset
    public InputActionAsset inputActionAsset;

    private InputAction startAction;

    private void OnEnable()
    {
        // Get the "Start" action from the InputActionAsset
        var actionMap = inputActionAsset.FindActionMap("UI");
        startAction = actionMap?.FindAction("Start");

        if (startAction != null)
        {
            // Enable the action
            startAction.Enable();

            // Add a callback to trigger when the action is performed
            startAction.performed += OnStartActionPerformed;
        }
        else
        {
            Debug.LogError("Start action not found in InputActionAsset.");
        }
    }

    private void OnDisable()
    {
        // Disable the action and remove the callback when the object is disabled
        if (startAction != null)
        {
            startAction.performed -= OnStartActionPerformed;
            startAction.Disable();
        }
    }

    // Callback method when the "Start" action is performed
    private void OnStartActionPerformed(InputAction.CallbackContext context)
    {
        // Trigger the button click
        if (startButton != null)
        {
            startButton.onClick.Invoke();
        }
    }
}
