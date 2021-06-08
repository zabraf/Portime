using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : Activable
{
    public bool Resverse = false;
    public int nbrActivabe = 1;
    private int nb;
    private void Start()
    {
        nb = nbrActivabe;
    }
    public void Restart()
    {
        nb = nbrActivabe;
    }
    public override void Activate()
    {
        nb--;
        if(nb == 0)
        { 
            if (Resverse) { 
                this.transform.gameObject.SetActive(true);
            }
            else
            {
                this.transform.gameObject.SetActive(false);
            }
        }
    }

    public override void Desactivate()
    {
        if (nb == 0)
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
        nb++;
       
    }
}
