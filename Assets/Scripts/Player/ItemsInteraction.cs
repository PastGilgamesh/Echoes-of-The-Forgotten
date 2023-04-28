using UnityEngine;

public class ItemsInteraction : MonoBehaviour
{
    private bool playerInRange;
    public GameObject InteractButton;
    

    // Update is called once per frame
    void Update()
    {

        if (playerInRange && Input.GetMouseButton(0))
        {

            InteractButton.SetActive(false);

            
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interaction"))
        {
            playerInRange = true;

            InteractButton.SetActive(true);

        }





    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interaction"))
        {
            playerInRange = false;

            InteractButton.SetActive(false);

            

        }


    }



}
