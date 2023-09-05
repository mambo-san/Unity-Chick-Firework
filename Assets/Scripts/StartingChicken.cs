using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class StartingChicken : MonoBehaviour, IClickable
{
    [SerializeField]
    protected GameObject childChick;
    private Vector3 previousPos;
    private float speed = 10;
    private bool hasReachedCentre = false;
    

    // Start is called before the first frame update
    void Start()
    {
        previousPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Check boundary
        CheckBoundary();
        //Move until it reaches the center of the screen
        if (!hasReachedCentre) 
        {
            MoveUpwards();
        }
    }

    private void CheckBoundary()
    {
        if (!hasReachedCentre && previousPos.y > 0)
        {
            hasReachedCentre = true;
            //Display click me message 
            //TODO
        }
    }

    private void MoveUpwards()
    {
        //TODO - add side movements
        Vector3 newPos = previousPos + (Vector3.up * speed * Time.deltaTime);
        gameObject.transform.position = newPos;
        previousPos = newPos;
    }

    

    public virtual void ClickAction()
    {
        throw new System.NotSupportedException("Make sure the child use OVERRIDE for this method!");
    }
}
