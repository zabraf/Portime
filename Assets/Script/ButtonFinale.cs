using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFinale : MonoBehaviour
{
    // Start is called before the first frame update
    public GameController gameController;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            gameController.NextLevel();
        }
    }

}

