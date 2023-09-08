using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class ParentChickenStandard : Chicken
{
    // Not POLYMORPHISM
    public override void ClickAction()
    {
        base.ClickAction();
    }
}
