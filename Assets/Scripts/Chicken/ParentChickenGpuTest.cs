using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentChickenChaotic: Chicken
{
    public override void ClickAction()
    {
        Instantiate(childChick);
        Destroy(gameObject);
    }
}
