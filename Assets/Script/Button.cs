using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    // Start is called before the first frame update
    private Material material;
    private int numberOfElement;
    public Activable activable;
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player" || collision.tag == "Cube" || collision.tag == "Clone")
        {
            activable.Activate();
            material.color = Color.green;
            numberOfElement++;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        
        if (collision.tag == "Player" || collision.tag == "Cube" || collision.tag == "Clone")
        {
            
            numberOfElement--;
            if (numberOfElement == 0)
            { 
                activable.Deactivate();
                material.color = Color.black;
            }

        }
    }
}
