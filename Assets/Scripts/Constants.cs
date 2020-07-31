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

    // player2 controls
    public const KeyCode KeyForward2 = KeyCode.UpArrow;
    public const KeyCode KeyBackward2 = KeyCode.DownArrow;
    public const KeyCode KeyLeft2 = KeyCode.LeftArrow;
    public const KeyCode KeyRight2 = KeyCode.RightArrow;

    // common
    public const float powerupTime = 2.0f;
    public const float normalSpeed = 10.0f;
    public const float timePowerUp = 10.0f;
    public const float gameTime = 120.0f;
}
