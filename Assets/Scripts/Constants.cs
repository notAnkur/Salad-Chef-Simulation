using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    // player1 controls
    public const KeyCode KeyForward1 = KeyCode.W;
    public const KeyCode KeyBackward1 = KeyCode.S;
    public const KeyCode KeyLeft1 = KeyCode.A;
    public const KeyCode KeyRight1 = KeyCode.D;
    public const KeyCode KeyRotateLeft1 = KeyCode.Q;
    public const KeyCode KeyRotateRight1 = KeyCode.E;
    public const KeyCode KeyPick1 = KeyCode.F;

    // player2 controls
    public const KeyCode KeyForward2 = KeyCode.UpArrow;
    public const KeyCode KeyBackward2 = KeyCode.DownArrow;
    public const KeyCode KeyLeft2 = KeyCode.LeftArrow;
    public const KeyCode KeyRight2 = KeyCode.RightArrow;
    public const KeyCode KeyRotateLeft2 = KeyCode.RightShift;
    public const KeyCode KeyRotateRight2 = KeyCode.RightControl;
    public const KeyCode KeyPick2 = KeyCode.Return;

    // common
    public const float powerupTime = 2.0f;
    public const float normalSpeed = 2.0f;
    public const float timePowerUp = 10.0f;
    public const float gameTime = 120.0f;
    public const int customerMinWaitTime = 20;
    public const int customerMaxWaitTime = 30;

    public const string Dustbin = "Dustbin";
    public const string SaladMixer = "SaladMixer";
    public const string SaladTag = "Salad";
    public const string CustomerTag = "Customer";

    // raw vege
    public const string Tomato = "Tomato";
    public const string Brocolli = "Brocolli";
    public const string Carrot = "Carrot";

    // vege combo
    public const string Tomolli = "Tomolli"; // tomato + brocolli
    public const string Tarrot = "Tarrot"; // tomato + carrot
    public const string Brorrocolli = "Brorrocolli"; // brocolli + Carrot

}
