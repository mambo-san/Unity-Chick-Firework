using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentChickenMedium: Chicken
{
    public override void ClickAction()
    {
        Instantiate(childChick);
        Destroy(gameObject);
    }
}
