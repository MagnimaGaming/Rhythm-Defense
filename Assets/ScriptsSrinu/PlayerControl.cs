using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private PlayerAnimations playerAnim;

    private void Start()
    {
        playerAnim = GetComponent<PlayerAnimations>();
    }

    private void Update()
    {
        LegsMovement();
    }


    private void LegsMovement()
    {
        string input = Input.inputString;
        switch (input)
        {
            case "a":
                playerAnim.LeftLegUP();
                break;
            case "s":
                playerAnim.LeftLegDown(); 
                break;
            case "d":
                playerAnim.RightLegUP();
                break;
            case "f":
                playerAnim.RightLegDown();
                break;
        } 
    }
}
