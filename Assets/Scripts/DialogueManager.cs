using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Image characterImage;
    public TMP_Text characterName;
    public TMP_Text messageText;
    public RectTransform backgroundBox;
    public Button continueButton;
    public Canvas dialogueCanvas;

    Message[] currentMessages;
    Character[] currentCharacters;
    int activeMessage = 0;
    public static bool isActive = false;


    public void OpenDialogue(Message[] messages, Character[] characters)
    {
        currentMessages = messages;
        currentCharacters = characters;
        activeMessage = 0;
        isActive = true;

        DisplayMessage();
    }

    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Character characterToDisplay = currentCharacters[messageToDisplay.characterID];
        characterName.text = characterToDisplay.name;
        characterImage.sprite = characterToDisplay.sprite;
    }

    public void NextMessage()
    {
        activeMessage++;
        if(activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            dialogueCanvas.gameObject.SetActive(false);
            isActive = false;
            Time.timeScale = 1f;
        }
    }

    public void OnContinue()
    {
        NextMessage();
    }
}
