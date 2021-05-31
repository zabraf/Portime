using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : Activable
{
    public override void Activate()
    {
        this.transform.gameObject.SetActive(false);
    }


    public override void Deactivate()
    {
        this.transform.gameObject.SetActive(true);
    }

}
