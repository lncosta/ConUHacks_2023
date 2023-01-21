using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI text;
    [SerializeField] public Rigidbody planeRB;
    [SerializeField] public GameObject gameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Speed: " + (int) planeRB.velocity.magnitude + " unit/second";
        CheckForGameOver(); 
    }

    public void Restart()
    {
        if (Globals.gameOver)
        {
            Time.timeScale = 1;
            gameOverPanel.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Restarts the simulation
            
        }
    }


    public void CheckForGameOver()
    {
        if (Globals.gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
    }
}
