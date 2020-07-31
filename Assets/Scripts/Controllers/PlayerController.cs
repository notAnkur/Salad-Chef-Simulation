using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{

    //public
    [SerializeField] TextMeshProUGUI timer;

    private bool canPlayerMove = false;
    private float gameTime;

    private void Awake()
    {
        canPlayerMove = true;
        gameTime = Constants.gameTime;
    }

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        PlayerMovement();
        UpdateTimer();
    }

    private void PlayerMovement()
    {
        if (!canPlayerMove) return;
        if(Input.GetKey(Constants.KeyForward1))
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(Constants.normalSpeed, 0, 0);
        }
        if (Input.GetKey(Constants.KeyBackward1))
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(-Constants.normalSpeed, 0, 0);
        }
        if (Input.GetKey(Constants.KeyLeft1))
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, Constants.normalSpeed);
        }
        if (Input.GetKey(Constants.KeyRight1))
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -Constants.normalSpeed);
        }
    }

    private void UpdateTimer()
    {
        gameTime -= Time.deltaTime;
        if (gameTime <= 0) canPlayerMove = false;
        timer.SetText((Math.Round(gameTime)).ToString() + "s");
    }
}
