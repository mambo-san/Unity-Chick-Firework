using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    
    private Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsGameActive && Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, 200))
            {
                //Implement something to ignore when plane is clicked.
                if (!hit.transform.gameObject.CompareTag("Plane")) 
                {
                    Chicken chick = hit.transform.gameObject.GetComponent<Chicken>();
                    chick.ClickAction();
                }
            }
        }
    }

    
}
