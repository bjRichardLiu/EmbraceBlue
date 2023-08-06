using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    [System.Serializable]
    public class DialogueLine
    {
        public string characterName;
        [TextArea(3, 5)]
        public string line;
    }

    public TMP_Text characterNameText;
    public TMP_Text dialogueText;
    public DialogueLine[] dialogueLines;
    public bool backToMenu;
    public float textSpeed = 0.05f;

    private int currentLineIndex = 0;
    private Coroutine displayCoroutine;
    private bool canProceed = true;

    void Start()
    {
        ShowCurrentLine();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (displayCoroutine != null && !canProceed)
            {
                // If the current line hasn't been fully displayed, display it fully
                StopCoroutine(displayCoroutine);
                dialogueText.text = dialogueLines[currentLineIndex].line;
                canProceed = true;
            }
            else
            {
                ShowNextCharacter();
            }
        }
    }

    void ShowCurrentLine()
    {
        if (currentLineIndex < dialogueLines.Length)
        {
            characterNameText.text = dialogueLines[currentLineIndex].characterName;
            dialogueText.text = "";
            displayCoroutine = StartCoroutine(AnimateText(dialogueLines[currentLineIndex].line));
            canProceed = false;
        }
        else
        {
            // If there are no more dialogue lines, jump to the specified scene
            JumpToScene();
        }
    }

    void ShowNextCharacter()
    {
        if (displayCoroutine != null && !canProceed)
        {
            // If the current line hasn't been fully displayed, display it fully
            StopCoroutine(displayCoroutine);
            dialogueText.text = dialogueLines[currentLineIndex].line;
            canProceed = true;
        }
        else
        {
            ShowNextLine();
        }
    }

    void ShowNextLine()
    {
        currentLineIndex++;
        ShowCurrentLine();
    }

    IEnumerator AnimateText(string line)
    {
        for (int i = 0; i < line.Length; i++)
        {
            dialogueText.text = line.Substring(0, i + 1);
            yield return new WaitForSeconds(textSpeed);
        }
        canProceed = true; // Set the flag to allow proceeding to the next line
        displayCoroutine = null;
    }

    void JumpToScene()
    {
        if (backToMenu)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            int index = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(index + 6);
        }
    }
}
