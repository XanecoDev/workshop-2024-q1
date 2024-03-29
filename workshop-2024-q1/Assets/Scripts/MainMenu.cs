using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Settings")]
    public string firstLevel = "Level 01";


    // Start is called before the first frame update
    void Start()
    {
        // Show Cursor
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        // Hide Cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Load Level
        SceneManager.LoadScene(firstLevel);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
