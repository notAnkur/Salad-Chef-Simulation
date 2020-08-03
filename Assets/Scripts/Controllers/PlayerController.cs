using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{

    //public
    [SerializeField] TextMeshProUGUI timer;
    [SerializeField] GameObject pickupLabelContainer;
    [SerializeField] GameObject eye;

    private bool canPlayerMove = false;
    private float gameTime;
    private float playerSpeed = Constants.normalSpeed;

    private List<GameObject> Cart;

    private void Awake()
    {
        canPlayerMove = true;
        gameTime = Constants.gameTime;
    }

    void Start()
    {
        Cart = new List<GameObject>(2);
    }

    void FixedUpdate()
    {
        PlayerMovement();
        UpdateTimer();
        ShootRaycast();
    }

    private void PlayerMovement()
    {
        if (!canPlayerMove) return;

        if (Input.GetKey(Constants.KeyForward1))
        {
            transform.Translate(0, 0, 10 * Time.deltaTime);
        }
        if(Input.GetKey(Constants.KeyBackward1))
        {
            transform.Translate(0, 0, -10 * Time.deltaTime);
        }
        if (Input.GetKey(Constants.KeyLeft1))
        {
            transform.Translate(-10 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(Constants.KeyRight1))
        {
            transform.Translate(10 * Time.deltaTime, 0, 0);
        }
        if(Input.GetKey(Constants.KeyRotateLeft1))
        {
            transform.Rotate(0, transform.rotation.y - 5, 0);
        }
        if(Input.GetKey(Constants.KeyRotateRight1))
        {
            transform.Rotate(0, transform.rotation.y + 5, 0);
        }
    }

    private void UpdateTimer()
    {
        gameTime -= Time.deltaTime;
        if (gameTime <= 0) canPlayerMove = false;
        timer.SetText((Math.Round(gameTime)).ToString() + "s");
    }

    private void ShootRaycast()
    {
        RaycastHit hit;
        Debug.Log("attempting");
        Debug.DrawRay(eye.transform.position, eye.transform.forward * 10, Color.red);
        if (Physics.Raycast(eye.transform.position, eye.transform.forward, out hit, 10))
        {
            Debug.Log(hit.transform.name);
            Debug.Log(hit.transform.tag);
            if (hit.transform.CompareTag("Vegetable"))
            {
                pickupLabelContainer.SetActive(true);
                pickupLabelContainer.GetComponentInChildren<TextMeshProUGUI>().SetText($"F to pickup {hit.transform.name}");

                // handle pickup and drop
                HandleObject(hit.transform.gameObject);
            }
        } else
        {
            pickupLabelContainer.SetActive(false);
        }
    }

    private void HandleObject(GameObject interactableObject)
    {
        if(Input.GetKeyDown(Constants.KeyPick1))
        {
            PickObject(interactableObject);
        }
    }

    private void PickObject(GameObject interactableObject)
    {
        if(Cart.Count > 2)
        {
            return;
        }

        if(interactableObject.CompareTag("Vegetable"))
        {
            // item is raw vege

        }
    }

}
