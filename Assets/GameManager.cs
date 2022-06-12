using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : GenericSingletonClass<GameManager>
{
    private void Awake()
    {
        Time.timeScale = 1f;

    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void SlowGame()
    {
        Time.timeScale = 0.1f;

        Time.fixedDeltaTime = 0.02f * Time.timeScale;
     

    }

    public void FastGame()
    {
        Time.timeScale = 1f;

        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
}
