using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] bool debugEnabled = false;

    [SerializeField] private TMP_Text messageText;

    private string currentMessage = "";

    private void Start()
    {
        currentMessage = "";
    }

    public void DisplayMessage(string message)
    {

        currentMessage = message;

        //pass message through UI manager to text display
        messageText.text = currentMessage;


    }

}
