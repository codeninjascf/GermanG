using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public int interaction;

    private bool _activated; 

    void Start()
    {
        _activated = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D (Collider2D other)
    {
        Debug.Log($"{other.name}");

        if (_activated || !other.CompareTag("Player")) return;

        _activated = true;
        dialogueManager.StartInteraction(interaction);
    }
}
