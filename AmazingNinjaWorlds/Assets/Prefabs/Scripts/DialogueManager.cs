using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [System.Serializable]
    public struct Interaction
    {
        public GameObject dialogue;
        public TextMeshProUGUI mainText;

        public int currentMessage;
        public string[] messages;
    }

    public Interaction[] interactions;

    private Interaction _activeInteraction;

    void NextMessage()
    {
        if (_activeInteraction.dialogue == null) return;

        if (_activeInteraction.currentMessage >= _activeInteraction.messages.Length)
        {
            _activeInteraction.dialogue.SetActive(false);
            return;
        }
        _activeInteraction.mainText.text =
            _activeInteraction.messages[_activeInteraction.currentMessage];
        _activeInteraction.currentMessage++;
    }

    public void StartInteraction(int interactionNumber)
    {
        if (interactionNumber < 0 || interactionNumber >= interactions.Length) return;
        if(_activeInteraction.dialogue != null)
        {
            _activeInteraction.dialogue.SetActive(false);
        }
        _activeInteraction = interactions[interactionNumber];
        _activeInteraction.dialogue.SetActive(true);
        NextMessage();
    }

    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        if( Input.GetKeyDown(KeyCode.Return))
        {
            NextMessage();
        }
    }
}
