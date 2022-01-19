using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : Interactable
{
    [SerializeField]
    public int keyValue;
    [SerializeField]
    private CalculatorModule module;

    public override void Interact()
    {
        Debug.Log("Pressed " + keyValue);
        module.enterDigit(keyValue);
    }
}
