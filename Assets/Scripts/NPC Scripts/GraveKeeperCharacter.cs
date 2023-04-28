using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class GraveKeeperCharacter : MonoBehaviour
{
    public NPCConversation myConversation;

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            ConversationManager.Instance.StartConversation(myConversation);
        }
    }

}
