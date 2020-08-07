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
    [SerializeField] TextMeshProUGUI scoreTextField;

    //private
    private bool canPlayerMove;
    private float gameTime;
    private float playerSpeed;
    private int playerScore;
    private MessageController messageController;

    private List<string> Cart;

    private void Awake()
    {
        canPlayerMove = true;
        gameTime = Constants.gameTime;
        playerSpeed = Constants.normalSpeed;
        playerScore = 0;
        messageController = FindObjectOfType<MessageController>();
    }

    void Start()
    {
        Cart = new List<string>(2);
    }

    private void Update()
    {
        ShootRaycast();
        if (!canPlayerMove) FindObjectOfType<GameMenu>().GameOver(playerScore);
        scoreTextField.SetText($"{playerScore}");
    }

    void FixedUpdate()
    {
        PlayerMovement();
        UpdateTimer();
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
        if (gameTime <= 0)
        {
            canPlayerMove = false;
            Time.timeScale = 0;
        }
        else timer.SetText((Math.Round(gameTime)).ToString() + "s");
    }

    private void ShootRaycast()
    {
        RaycastHit hit;
        Debug.DrawRay(eye.transform.position, eye.transform.forward * 10, Color.red);
        if (Physics.Raycast(eye.transform.position, eye.transform.forward, out hit, 10))
        {
            if (hit.transform.CompareTag("Vegetable"))
            {
                DisplayPickupMessage(hit);
                // handle pickup
                HandleObject(hit.transform.gameObject);
            } else if (hit.transform.name.Equals(Constants.Dustbin))
            {
                DisplayPickupMessage(hit);
                DustbinHandler();
            } else if (hit.transform.name.Equals(Constants.SaladMixer))
            {
                DisplayPickupMessage(hit);
                SaladMixerHandler(hit.transform.GetComponent<SaladMixerController>());
            } else if(hit.transform.CompareTag(Constants.SaladTag))
            {
                DisplayPickupMessage(hit);
                HandleObject(hit.transform.gameObject);
            } else if(hit.transform.CompareTag(Constants.CustomerTag))
            {
                DisplayPickupMessage(hit);
                HandleOrder(hit.transform.gameObject);
            }
        } else
        {
            pickupLabelContainer.SetActive(false);
        }
    }

    private void DisplayPickupMessage(RaycastHit hit)
    {
        pickupLabelContainer.SetActive(true);
        pickupLabelContainer.GetComponentInChildren<TextMeshProUGUI>().SetText($"F to interact with {hit.transform.name}");
    }

    private void HandleObject(GameObject interactableObject)
    {
        if(Input.GetKeyDown(Constants.KeyPick1))
        {
            PickObject(interactableObject);
        }
    }

    private void HandleOrder(GameObject order)
    {
        if(Input.GetKeyDown(Constants.KeyPick1))
        {
            order.transform.GetComponent<CustomerController>().ServeOrder(Cart, gameObject);
        }
    }

    private void PickObject(GameObject interactableObject)
    {
        if (Cart.Count >= 2)
        {
            // player cant have more than two items in the cart
            messageController.DisplayMessage("Cart full");
            return;
        }

        if(interactableObject.CompareTag("Vegetable"))
        {
            // item is raw vege
            Cart.Add(interactableObject.transform.name);
            messageController.DisplayMessage($"{interactableObject.transform.name} added to Cart");
        } else if(interactableObject.CompareTag(Constants.SaladTag))
        {
            // item is salad
            Cart.Add(interactableObject.GetComponentInChildren<TextMesh>().text);
            Debug.Log(interactableObject.GetComponentInChildren<TextMesh>().text);
            messageController.DisplayMessage($"{interactableObject.GetComponentInChildren<TextMesh>().text} added to Cart");
            Destroy(interactableObject);
        }
    }

    public void UpdateCart(List<string> Cart)
    {
        this.Cart = Cart;
    }

    private void DustbinHandler()
    {
        if(Input.GetKeyDown(Constants.KeyPick1))
        {
            if (Cart.Count > 0)
            {
                Cart.Clear();
                ModifyScore(-10);
                messageController.DisplayMessage("Cart cleared.");
            }
            else
            {
                messageController.DisplayMessage("Cart is already empty.");
            }
        }
    }

    private void SaladMixerHandler(SaladMixerController saladMixerController)
    {
        if(Input.GetKeyDown(Constants.KeyPick1))
        {
            saladMixerController.MakeSalad(Cart);
            Cart.Clear();
        }
    }

    public void ModifyScore(int score)
    {
        playerScore += score;
    }

}
