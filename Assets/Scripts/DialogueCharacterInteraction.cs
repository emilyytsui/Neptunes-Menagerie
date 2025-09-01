using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCharacterInteraction : MonoBehaviour
{
    public DialogueTrigger trigger;
    [SerializeField] Canvas dialogueCanvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dialogueCanvas.gameObject.SetActive(true);
            trigger.StartDialogue();
        }
    }
}
