using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Outline))]
public class Interactable : MonoBehaviour
{
    private Outline outline;

    [TextArea]
    public List<string> messages = new List<string>() { "Press E to interact" }; // Add more in Inspector

    public UnityEvent onInteraction;

    private string currentMessage;

    void Start()
    {
        outline = GetComponent<Outline>();
        DisableOutline();
        UpdateMessage(); // Set initial message
    }

    public void Interact()
    {
        onInteraction.Invoke();
    }

    public void EnableOutline()
    {
        outline.enabled = true;
        UpdateMessage(); // Update the message every time it’s highlighted
        Debug.Log("Message: " + currentMessage);
    }

    public void DisableOutline()
    {
        outline.enabled = false;
    }

    private void UpdateMessage()
    {
        if (messages.Count == 0)
        {
            currentMessage = "";
            return;
        }

        // Cycle through based on how many times the player reset
        int index = EndTrigger.resetCount % messages.Count;
        currentMessage = messages[index];
    }

    public string GetCurrentMessage()
    {
        return currentMessage;
    }
}
