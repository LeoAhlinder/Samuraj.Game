using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject SettingsMenuFromPaused = default;
    [SerializeField] GameObject StartMenu = default;
    [SerializeField] GameObject MenuCanvas = default;
    [SerializeField] GameObject PauseMenu = default;
    [SerializeField] GameObject SettingsMenuFromStart = default;
    [SerializeField] GameObject DeathScreen = default;
    public bool Menus;
    public GameObject Player;
    Goblin Goblin;
    private void Awake()
    {
        Goblin = GameObject.Find("Goblin").GetComponent<Goblin>();
        SettingsMenuFromStart.SetActive(false);
    }

    public void StartButton() 
    {
        Menus = true;
        StartMenu.SetActive(false);
        GameObject.Find("Player").GetComponent<Player>().speed = 3;
        GameObject.Find("Player").GetComponent<Player>().MovingInMenus = true;
    }

    public void SettingsButton() 
    {
        StartMenu.SetActive(false);
        SettingsMenuFromPaused.SetActive(true);
    }
    public void Start()
    {
       GameObject.Find("Player").GetComponent<Player>().MovingInMenus = false;
        StartMenu.SetActive(true);
        MenuCanvas.SetActive(true);
        GameObject.Find("Player").GetComponent<Player>().speed = 0; 
    }
        
    public void QuitButton()
    {
        Application.Quit();
    }
    public void BackFromSettings()
    {
        SettingsMenuFromPaused.SetActive(false);
        PauseMenu.SetActive(true);        
    }
    public void Resume()
    {
        Menus = true;
        PauseMenu.SetActive(false);
        GameObject.Find("Player").GetComponent<Player>().speed = 3;
        GameObject.Find("Player").GetComponent<Player>().MovingInMenus = true;
    }
    public void BackFromSettingsFromStart()
    {
        SettingsMenuFromStart.SetActive(false);
        StartMenu.SetActive(true);       
    }
    public void SettingsFromStart()
    {
        SettingsMenuFromStart.SetActive(true);
        StartMenu.SetActive(false);       
    }
    public void SettingsFromPaused()
    {
        PauseMenu.SetActive(false);
        SettingsMenuFromPaused.SetActive(true);
    }
       
    public void MainMenuButtonFromDeathScreen()
    {
        Goblin.GoblinBackToSpawn = true;
        DeathScreen.SetActive(false);
        StartMenu.SetActive(true);
        Player.transform.position = new Vector2(-0.86f, 1.69f);
        Player.SetActive(true);
        GameObject.Find("Player").GetComponent<Player>().Health = 10;
    }
    public void RespawnButtonFromDeathScreen()
    {
        Goblin.GoblinBackToSpawn = true;
        DeathScreen.SetActive(false);
        Player.transform.position = new Vector2(-0.86f, 1.69f);
        Player.SetActive(true);
        GameObject.Find("Player").GetComponent<Player>().Health = 10;
    }

    public void Update()
    {   
        if (Menus == true)
        {                   
           if (Input.GetKeyDown(KeyCode.Escape))
           {
              if (PauseMenu.activeSelf)
              {
                 PauseMenu.SetActive(false);
                 Menus = true;
              }
              else
              {
                 Menus = false;
                 PauseMenu.SetActive(true);
              }
           }                                        
        }              
    }
}


