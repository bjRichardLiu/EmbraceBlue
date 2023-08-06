using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GoToScene : MonoBehaviour
{
    // Enter the build index of the scene you want to switch to in the Inspector.
    public int targetSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This function will be called when the UI button is clicked.
    public void OnButtonClick()
    {

        // Load the target scene using the build index.
        SceneManager.LoadScene(targetSceneIndex);

    }
}
