using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageTextField;
    private float messageDisplayDuration;
    private bool isMessageFieldActive;

    private void Awake()
    {
        messageDisplayDuration = 4.0f;
        isMessageFieldActive = false;
    }

    public void DisplayMessage(string message)
    {
        if(isMessageFieldActive)
        {
            StopCoroutine(MessageRoutine(""));
            StartCoroutine(MessageRoutine(message));
        } else
        {
            StartCoroutine(MessageRoutine(message));
        }
    }

    IEnumerator MessageRoutine(string message)
    {
        messageTextField.gameObject.SetActive(true);
        messageTextField.SetText(message);
        isMessageFieldActive = true;

        yield return new WaitForSeconds(messageDisplayDuration);

        messageTextField.SetText("");
        messageTextField.gameObject.SetActive(false);
        isMessageFieldActive = false;
    }
}
