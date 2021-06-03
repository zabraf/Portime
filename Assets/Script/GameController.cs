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
    public TextMeshProUGUI Gameover;
    void Start()
    {
        Time.timeScale = 1;
        time.text = string.Format("{0:N2}", startingTime);
        clones.text = "clones : " + numberofClone.ToString() + "/" + totalNumberofClone.ToString();
        currentTime = startingTime;
        recorders = Object.FindObjectsOfType<Recorder>();
    }
    public void NextLevel()
    {
        int level = SceneManager.GetActiveScene().buildIndex + 1;
        PlayerPrefs.SetInt("level", level);
        SceneManager.LoadScene(level);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyUp(KeyCode.Return))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (currentTime <= 0)
        {
            if (numberofClone >= totalNumberofClone)
            {
                Gameover.text = "This puzzle is now impossible in this timeline,\n press ENTER key to create a new timeline.";
                Time.timeScale = 0; 
            }
            else
            {
                numberofClone++;
                foreach (Recorder recorder in recorders)
                {
                    recorder.StopRecord();
                }
                clones.text = "clones : " + numberofClone.ToString() + "/" + totalNumberofClone.ToString();
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
