using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    private Recorder[] recorders;
    public float startingTime = 10f;
    private float currentTime = 0;

    public int totalNumberofClone = 3;
    private int numberofClone = 0;

    public TextMeshProUGUI time;
    public TextMeshProUGUI clones;
    void Start()
    {
        time.text = string.Format("{0:N2}", startingTime);
        clones.text = numberofClone.ToString() + "/" + totalNumberofClone.ToString();
        currentTime = startingTime;
        recorders = Object.FindObjectsOfType<Recorder>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (currentTime <= 0)
        {
            if (numberofClone >= totalNumberofClone)
            {
                Time.timeScale = 0;
                time.text = "Press ENTER to restart";
            }
            else
            {
                numberofClone++;
                foreach (Recorder recorder in recorders)
                {
                    recorder.StopRecord();
                }
                clones.text = numberofClone.ToString() + "/" + totalNumberofClone.ToString();
                currentTime = startingTime;
            }
        }
        else
        {
            currentTime -= 1 * Time.deltaTime;
            time.text = string.Format("{0:N2}", currentTime);
        }
    }
}
