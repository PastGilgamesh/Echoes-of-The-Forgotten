using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    public Image actorImage;
    public Text actorName;
    public Text messageText;
    public RectTransform backgroundBox;
    public GameObject dialoguePanel;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    public static bool isActive = false;

    public bool isTalking;

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;
        DisplayMessage();


    }

    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;

    }

    public void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {
            isTalking = true;
            isActive = true;
            DisplayMessage();
        }
        else
        {
            isActive = false;
            Debug.Log("Conversation Ended");
            FindObjectOfType<DialogueManager>().dialoguePanel.SetActive(false);
            isTalking = false;
        }
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && isActive == true)
        {
            if (FindObjectOfType<DialogueManager>() != null)
            {
                FindObjectOfType<DialogueManager>().NextMessage();
            }
        }

    }



}

