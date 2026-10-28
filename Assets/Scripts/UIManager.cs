using UnityEngine;


public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;

    [SerializeField] private GameObject pausePanel;

    [SerializeField] private GameObject settingsPanel;

    public PlayerController playerController;

    public PlayerInteraction playerInteraction;

    public Timer timer;
    

    public CursorManager cursorView;

    public bool isPaused;

public void Update()
    {
       
    }
    public void OpenMenuPanel()
    {
        cursorView.ViewCursor();
        playerController.isPaused = true;
        playerInteraction.isPaused = true;
        timer.isPaused = true;

    }

    public void OpenPausePanel()
    {
        Time.timeScale = 0f;
        cursorView.ViewCursor();
        playerController.isPaused = true;
        playerInteraction.isPaused = true;
        timer.isPaused = true;
       
    }

    public void OpenSettinsPanel()
    {
         cursorView.ViewCursor();
         playerController.isPaused = true;
        playerInteraction.isPaused = true;
        timer.isPaused = true;
       cursorView.ViewCursor();
    }

    public void CloseMenuPanel()
    {
        cursorView.HideCursor();

        
         playerController.isPaused = false;
         playerInteraction.isPaused = false;
        timer.isPaused = false;
            
    
        
    }

    public void ClosePausePanel()
    {
        Time.timeScale = 1f;
        cursorView.HideCursor();
        playerController.isPaused = false;
         playerInteraction.isPaused = false;
        timer.isPaused = false;
    }

    public void CloseSettingsPanel()
    {
         playerController.isPaused = false;
         playerInteraction.isPaused = false;
        timer.isPaused = false;
            
        cursorView.HideCursor();
    }

                                                                        
}
                   