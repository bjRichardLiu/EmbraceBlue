using UnityEngine;

public class ActivateAndDeactivate : MonoBehaviour
{
    public GameObject objectToActivateDeactivate;

    private void Start()
    {
        // Activate the game object
        objectToActivateDeactivate.SetActive(true);

        // Call a method to deactivate the game object after 1 second
        Invoke("DeactivateGameObject", 1f);
    }

    private void DeactivateGameObject()
    {
        // Deactivate the game object
        objectToActivateDeactivate.SetActive(false);
    }
}
