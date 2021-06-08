using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorController : Activable
{
    public bool Resverse = false;
    public int nbrActivabe = 1;
    public TextMeshPro textMeshPro;
    public AudioClip audioClip;
    private void Start()
    {
        textMeshPro.text = nbrActivabe.ToString();
    }
    public override void Activate()
    {
        nbrActivabe--;
        textMeshPro.text = nbrActivabe.ToString();
        if (nbrActivabe == 0)
        {
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
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
        if (nbrActivabe == 0)
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
        nbrActivabe++;
        textMeshPro.text = nbrActivabe.ToString();

    }
}
