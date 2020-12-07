using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject MainCamera;
    public GameObject BossBattleEngaged;
    public GameObject PauseMenuUI;
      void Update() 
      {
          if (Input.GetKeyDown(KeyCode.Escape))
          {
              if (GameIsPaused)
              {
                  Resume();
              }
              else
              {
                  Pause();
              }
          }
      }

      public void Resume()
      {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameObject BossBattleEngaged = GameObject.Find("Boss(Clone)");

        if (BossBattleEngaged)
        {
          Debug.Log("Do not unpause");
            
        }
        else
        {
          Debug.Log("Pause");
          MainCamera.GetComponent<UnityStandardAssets.Utility.WaypointProgressTracker>().enabled = true;
          GameIsPaused = false;
        }

      }

      public void Pause()
      {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        MainCamera.GetComponent<UnityStandardAssets.Utility.WaypointProgressTracker>().enabled = false;

        GameIsPaused = true;
      }

}