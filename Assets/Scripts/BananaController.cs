using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaController : MonoBehaviour
{
    public GameObject bananaObject; // Reference to the banana GameObject

    public static BananaController Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Function to place the banana at the player's foot position
    public void PlaceBananaAtPlayerFeet()
    {
        GameObject player = GameObject.Find("Player (1)");

        if (player != null)
        {
            // Get the character controller component of the player
            CharacterController playerController = player.GetComponent<CharacterController>();

            if (playerController != null)
            {
                // Calculate the position at the player's feet
                Vector3 playerFeetPosition = player.transform.position - new Vector3(0, playerController.height, 0);

                // Instantiate the bananaObject at the calculated position
                Instantiate(bananaObject, playerFeetPosition, Quaternion.identity);
            }
            else
            {
                Debug.LogError("CharacterController component not found on the player!");
            }
        }
        else
        {
            Debug.LogError("Player GameObject not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
