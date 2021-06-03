using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : Activable
{
    public bool Resverse = false;
    public override void Activate()
    {
        if (Resverse) { 
            this.transform.gameObject.SetActive(true);
        }
        else
        {
            this.transform.gameObject.SetActive(false);
        }
    }

    public override void Desactivate()
    {
        if (Resverse)
        {
            this.transform.gameObject.SetActive(false);
        }
        else
        {
            this.transform.gameObject.SetActive(true);
        }
    }
}
