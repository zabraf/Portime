using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    // Start is called before the first frame update
    private Material material;
    private int numberOfElement;
    public List<Activable> activables;
    private Color color;
    void Start()
    {
        material = GetComponent<Renderer>().material;
        color = material.color;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player" || collision.tag == "Cube" || collision.tag == "Clone")
        {
            foreach (Activable activable in activables)
            {
                activable.Activate();
            }
            material.color = Color.red;
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
                foreach (Activable activable in activables)
                {
                    activable.Desactivate();
                }
                material.color = color;
            }

        }
    }
}
