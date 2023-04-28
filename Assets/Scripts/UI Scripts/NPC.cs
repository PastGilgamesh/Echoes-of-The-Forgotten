using UnityEngine;

public class NPC : MonoBehaviour
{
    public bool readyToSpeak = false;
    public DialogueTrigger trigger;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && readyToSpeak == true)
        {
            trigger.StartDialogue();
            FindObjectOfType<DialogueManager>().dialoguePanel.SetActive(true);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") == true)
        {
            readyToSpeak = true;

        }


    }
}
