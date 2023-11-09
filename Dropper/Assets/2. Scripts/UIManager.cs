using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if(instance == null)
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

    [SerializeField] private GameObject[] screenUIs;
    private Dictionary<string, GameObject> uiDic = new Dictionary<string, GameObject>();
    void Start()
    {
        foreach(GameObject ui in screenUIs)
        {
            uiDic.Add(ui.name, ui);
        }
    }

    public void OnclickButton(Button button)
    {
        SoundManager.Instance.PlaySFX("ClickButton");
        
        if(button.name == "StartButton")
        {
            HideUIWithName("Title");
            Animator anim = Camera.main.GetComponent<Animator>();
            anim.SetTrigger("GameStart");
            Invoke("Intro", 5.27f);
        }
        else if(button.name == "ExitButton")
        {
            Application.Quit();
        }
        else if(button.name == "SettingButton")
        {
            SetUIWithName("Setting");
            Time.timeScale = 0;
        }
        else if(button.name == "ContinueButton")
        {
            Time.timeScale = 1;
            HideUIWithName("Setting");
        }
        else if(button.name == "ContinueButtonInGameOver")
        {
            Time.timeScale = 1;
            HideUIWithName("GameOver");
            SoundManager.Instance.PlayBGM("GameScene");
            PlayerController playerController = FindObjectOfType<PlayerController>();
            playerController.Die();
        }
        else if(button.name == "ExitButtonInGameScene")
        {
            Time.timeScale = 1;
            ObstacleManager.Instance.Count = 0;
            GameManager.Instance.LoadScene("Title");
            HideUIWithName("Setting");
            HideUIWithName("Ending");
            HideUIWithName("GameOver");
            HideUIWithName("GameScene");
            SetUIWithName("Title");
        }
    }

    private void Intro()
    { 
        GameManager.Instance.LoadScene("GameScene");
        SetUIWithName("GameScene");
    }
    public void HideUIWithName(string name)
    {
        if(uiDic.ContainsKey(name))
        {
            uiDic[name].SetActive(false);
        }
    }

    public void SetUIWithName(string name)
    {
        if(uiDic.ContainsKey(name))
        {
            uiDic[name].SetActive(true);
        }
    }
}
