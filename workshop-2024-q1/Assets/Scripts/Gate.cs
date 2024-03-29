using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{
    [Header("Settings")]
    public string nextScene;
    public int collectableCount;


    // Start is called before the first frame update
    void Start()
    {
        collectableCount = FindObjectsByType<Collectable>(FindObjectsSortMode.None).Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.GetComponent<Ball>();

        if (ball != null && ball.collected == collectableCount)
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
