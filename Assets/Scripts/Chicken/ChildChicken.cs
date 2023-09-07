using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildChicken : Chicken
{
    private string m_name = "chick #";

    private float yBoundary = -40;

    // Start is called before the first frame update
    void Start()
    {
        m_name += Random.Range(10000, 900000);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < yBoundary)
        {
            Destroy(gameObject);
        }
    }

    public override void ClickAction()
    {
        base.ClickAction();
    }
}
