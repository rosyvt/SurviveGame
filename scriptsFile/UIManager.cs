using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using General;

namespace Player
{
    public class UIManager : MonoBehaviour
    {
        public GameObject pauseMenuUI;
        public GameObject deathMenuUI;
        public GameObject inventoryMenuUI;
        [SerializeField] bool gameIsPaused = false;
        public bool inventoryOpen = false;
        public static bool playerDead = false;
        void Update()
        {
            // if (HealthManager.IsDead())
            // {
            //     Invoke("DeathMenu", 1.25f);
            // }
            if (Input.GetKeyDown("escape"))
             {
                if (gameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }

            if(Input.GetKeyDown("i"))
            {
                // OpenCloseInventory();
            }
            if(playerDead)
            {
                DeathMenu();
            }
        }

        public void OpenCloseInventory()
        {
            if(inventoryOpen)
            {
                inventoryMenuUI.SetActive(false);
                gameIsPaused = false;
                inventoryOpen = false;
                Resume();
            }
            else
            {
                inventoryMenuUI.SetActive(true);
                gameIsPaused = true;
                inventoryOpen = true;
                Time.timeScale = 0f;
            }
        }

        void Pause()
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            gameIsPaused = true;
        }
        

        public void DeathMenu()
        {
            deathMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }

        public void Resume()
        {
            pauseMenuUI.SetActive(false);
            deathMenuUI.SetActive(false);
            inventoryMenuUI.SetActive(false);
            Time.timeScale = 1f;
            gameIsPaused = false;
        }

        public void LoadMenu()
        {
            Debug.Log("Loading Main Menu...");
            //Do this later since I don't have main menu yet.
            SceneManager.LoadScene("Main Menu");
            Resume();
        }

        public void Quit()
        {
            Debug.Log("Quitting Game (Only works on prod)");
            Application.Quit();
        }
    }

}
