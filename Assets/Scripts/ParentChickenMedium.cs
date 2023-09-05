using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentChickenMedium: StartingChicken
{
    public override void ClickAction()
    {
        Instantiate(childChick);
        Destroy(gameObject);
    }
}
