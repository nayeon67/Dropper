using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }

            return instance;
        }
    }
    private void Awake() 
    {
        if (Instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        else
        {
            Destroy(this.gameObject);
        }
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
        SoundManager.Instance.PlayBGM(scene);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        UIManager.Instance.SetUIWithName("GameOver");
        ObstacleManager.Instance.Count = 0;
        SoundManager.Instance.PlayBGM("GameOver");
    }

    public void GameClear()
    {
        Time.timeScale = 0;
        UIManager.Instance.SetUIWithName("Ending");
        SoundManager.Instance.PlayBGM("Ending");
        ObstacleManager.Instance.Count = 0;
    }
}
