using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Message[] messages;
    public Character[] characters;

    public void StartDialogue()
    {
        FindObjectOfType<DialogueManager>().OpenDialogue(messages, characters);
    }
}

[System.Serializable]
public class Message
{
    public int characterID;
    public string message;
}

[System.Serializable]
public class Character
{
    public string name;
    public Sprite sprite;
}