using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CustomerController : MonoBehaviour
{
    [SerializeField] private GameObject CustomerTimer;
    private float CustomerTime;
    public string CustomerOrder { get; private set; }

    private MessageController messageController;

    private void Awake()
    {
        CustomerTime = new System.Random().Next(Constants.customerMinWaitTime, Constants.customerMaxWaitTime);
        CustomerTimer.GetComponent<TextMesh>().text = $"{CustomerTime}s";
        messageController = FindObjectOfType<MessageController>();
    }

    private void FixedUpdate()
    {
        UpdateTimer();
    }

    public void SetCustomerOrder(string order)
    {
        CustomerOrder = order;
    }

    private void UpdateTimer()
    {
        if (CustomerTime <= 0)
        {
            foreach (PlayerController player in FindObjectsOfType<PlayerController>())
            {
                player.ModifyScore(-20);
                messageController.DisplayMessage("Customer not served in time.");
            }

            Destroy(gameObject);
        }

        CustomerTime -= Time.deltaTime;

        CustomerTimer.GetComponent<TextMesh>().text = ((Math.Round(CustomerTime)).ToString() + "s");
    }

    public void ServeOrder(string orderServed, GameObject ServedBy)
    {
        PlayerController OrderServedBy = ServedBy.GetComponent<PlayerController>();
        if(orderServed.Equals(CustomerOrder))
        {
            OrderServedBy.ModifyScore(50);
            messageController.DisplayMessage("Good Job!");
        } else
        {
            OrderServedBy.ModifyScore(-20);
            messageController.DisplayMessage("Unhappy Customer :(");
        }

        Destroy(gameObject);
    }
}
