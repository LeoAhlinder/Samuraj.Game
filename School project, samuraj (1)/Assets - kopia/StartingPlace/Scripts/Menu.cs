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
    private bool SettingsFromPaused2;
    private bool Menu3;
    private bool SettingsFromStart2;
    public bool Menus;
    private bool SettingsMenu;
    private bool StartMenus;
    private bool PauseMenus;
    private bool SettingsMenus;
    private bool DeathScreenMenu;
    public GameObject Player;
    Goblin Goblin;
    private bool overrideSorting;
    private void Awake()
    {
        Goblin = GameObject.Find("Goblin").GetComponent<Goblin>();
        SettingsMenuFromStart.SetActive(false);
    }

    public void StartButton() 
    {
        Menus = false;
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
        Menus = false;
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
        {
            if (Menu3 == false)
            {
                if (Menus == true)
                {
                    if (SettingsFromStart2 == false)
                    {
                        if (SettingsFromPaused2 == false)
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
                                    PauseMenu.SetActive(true);
                                }
                            }
                        }
                    }
                }
            }
        }       
        if (DeathScreen.activeSelf)
        {
            DeathScreenMenu = false;
            Menus = true;
        }
        else
        {
            Menus = false;
            DeathScreenMenu = true ;
        }
        if (StartMenu.activeSelf)
        {
            Menus = true;
            Menu3 = true; 
        }
        else
        {
            Menus = false;
            Menu3 = false;
        }
        if (SettingsMenuFromPaused.activeSelf) 
        {
            SettingsFromPaused2 = true;
        }
        else
        {
            Menus = false;
            SettingsFromPaused2 = false;
        }
        if (SettingsFromPaused2 == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SettingsMenuFromPaused.SetActive(false);
                PauseMenu.SetActive(true);
            }
        }

        if (SettingsMenuFromStart.activeSelf)
        {
            Menus = true;
            SettingsFromStart2 = true;
        }
        else
        {
            Menus = false;
            SettingsFromStart2 = false;
        }
        if (SettingsFromStart2 == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SettingsMenuFromStart.SetActive(false);
                StartMenu.SetActive(true);
            }
        }

        if (StartMenu.activeSelf)
        {
            Menus = true;
            StartMenus = false;
        }
        else
        {
            Menus = false;
            StartMenus = true;
        }
        if (SettingsMenuFromPaused.activeSelf)
        {
            Menus = true;
            SettingsMenus = false;
        }
        else
        {
            Menus = false;
            SettingsMenus = true;
        }
        if (SettingsMenuFromStart.activeSelf)
        {
            Menus = true;
            SettingsMenu = false;
        }
        else
        {
            Menus = false;
            SettingsMenu = true;
        }
        if (PauseMenu.activeSelf)
        {
            Menus = true;
            PauseMenus = false;
        }
        else
        {
            Menus = false;
            PauseMenus = true;
        }
        if (DeathScreenMenu)
        { 
             if (PauseMenus)
        {
                if (SettingsMenus)
                {
                    if (SettingsMenu)
                    {
                        if (StartMenus)
                        {
                            Menus = true;
                        }
                    }
                }
            }
        }        
    }   
}


