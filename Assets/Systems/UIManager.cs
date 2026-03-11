using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class UIManager : MonoBehaviour
{
    [SerializeField] bool debugEnabled = false;

    [SerializeField] private TMP_Text messageText;

    [Header("Interact Prompt")]

    [SerializeField] private TMP_Text promptText;
    [SerializeField] private string prompt;


    private Coroutine fadeCoroutine;

    [Header("Interact Message")] 

    [SerializeField] float messageDuration = 3f; 
    [SerializeField] float fadeOutTime = 0.5f;
    [SerializeField] float elaspedTime = 0f;


    public void DisplayMessage(string message)
    {
        
        if (debugEnabled) Debug.Log("Displaying message");

        if(fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }

        fadeCoroutine = StartCoroutine(DisplayMessageAndFade(message));
    }

    public void ShowPrompt()
    {
        promptText.text= prompt;
    }

    public void HidePrompt()
    {
        promptText.text = "";
    }

    private IEnumerator DisplayMessageAndFade(string message)
    {
        //pass message through UI manager to text display
        messageText.text = message;
        messageText.alpha = 1;
        elaspedTime = 0;

        yield return new WaitForSeconds(messageDuration);

        Color originalColor = messageText.color;

        while (elaspedTime < messageDuration)
        {
            elaspedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elaspedTime / fadeOutTime);

            //messageText.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            messageText.alpha = alpha; //easier way

            yield return null;
        }

        messageText.text = "";

    }

}
