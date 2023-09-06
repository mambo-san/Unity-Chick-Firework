using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildChicken : Chicken
{
    private string m_name = "chick #";


    // Start is called before the first frame update
    void Start()
    {
        m_name += Random.Range(10000, 900000);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ClickAction()
    {
        base.ClickAction();
    }
}
