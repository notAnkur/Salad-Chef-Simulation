using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaladMixerController : MonoBehaviour
{
    [SerializeField] private GameObject mixerOutputEmpty;
    [SerializeField] private GameObject SaladOutput;

    private MessageController messageController;

    private void Start()
    {
        messageController = FindObjectOfType<MessageController>();
    }

    public void MakeSalad(List<string> rawVege)
    {
        Debug.Log(rawVege.Count);
        if (mixerOutputEmpty.transform.childCount > 0)
        {
            // if previous output is on the transform, cancel current salad and return;
            return;
        }
        if (rawVege.Count <= 0) return;
        if(rawVege.Count == 1)
        {
            GameObject SaladOutputInstance = Instantiate(SaladOutput, mixerOutputEmpty.transform.position, Quaternion.identity);
            SaladOutputInstance.GetComponentInChildren<TextMesh>().text = rawVege[0];
        } else if(rawVege.Count == 2)
        {
            if(rawVege[0].Equals(rawVege[1]))
            {
                InstantiateSalad(rawVege[0]);
            } else if(rawVege.Contains(Constants.Tomato) && rawVege.Contains(Constants.Brocolli))
            {
                InstantiateSalad(Constants.Tomolli);
            } else if(rawVege.Contains(Constants.Tomato) && rawVege.Contains(Constants.Carrot))
            {
                InstantiateSalad(Constants.Tarrot);
            } else if(rawVege.Contains(Constants.Brocolli) && rawVege.Contains(Constants.Carrot))
            {
                InstantiateSalad(Constants.Brorrocolli);
            } else
            {
                messageController.DisplayMessage("Salad combination not found");
            }
        }
    }

    private void InstantiateSalad(string SaladLabel)
    {
        GameObject SaladOutputInstance = Instantiate(SaladOutput, mixerOutputEmpty.transform, false);
        SaladOutputInstance.GetComponentInChildren<TextMesh>().text = SaladLabel;
    }

}
