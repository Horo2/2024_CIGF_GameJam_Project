using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject Box;
    public Transform BoxSpawnPoint;
    public Transform detectionPoint;

    private GameObject currentBox;

    private bool isPlayerInTrigger = false;

    private bool isDisabled;
    // Start is called before the first frame update
    void Start()
    {
        isDisabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        isDisabled = PlayerController.GetisDisable();
        // If the current box exists and falls below the detection point, destroy it
        if (currentBox != null && currentBox.transform.position.y < detectionPoint.position.y)
        {
            Destroy(currentBox);
            currentBox = null;
        }

        // Detect key press and player is in trigger
        if (isPlayerInTrigger && !isDisabled && Input.GetKeyDown(KeyCode.F))
        {
            if (currentBox == null)
            {
                Debug.Log("Box Spawning....");
                SpawnBox();
            }
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            Debug.Log("Button: " + collision.gameObject.name + "enter");
            isPlayerInTrigger = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Button: " + collision.gameObject.name + "leave");
            isPlayerInTrigger = false;
        }
    }

    // Method to spawn a Box if not already present
    public void SpawnBox()
    {
        if (currentBox == null)
        {
            currentBox = Instantiate(Box, BoxSpawnPoint.position, BoxSpawnPoint.rotation);
        }
    }

}
