using UnityEngine;
using UnityEngine.InputSystem;


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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                OpenPausePanel();
            }
            else
            {
                ClosePausePanel();
                settingsPanel.SetActive(false);
            }
        }
    }
    public void StartGame()
    {
        Time.timeScale = 1.0f;
    }
    public void OpenMenuPanel()
    {
        cursorView.ViewCursor();
        playerController.isPaused = true;
        playerInteraction.isPaused = true;
        timer.isPaused = true;
        menuPanel.SetActive(true);

    }

    public void OpenPausePanel()
    {
        Time.timeScale = 0f;
        cursorView.ViewCursor();
        playerController.isPaused = true;
        playerInteraction.isPaused = true;
        timer.isPaused = true;
        isPaused = true;
        pausePanel.SetActive(true);

    }

    public void OpenSettinsPanel()
    {
        cursorView.ViewCursor();
        playerController.isPaused = true;
        playerInteraction.isPaused = true;
        timer.isPaused = true;
        cursorView.ViewCursor();
        settingsPanel.SetActive(true);
        isPaused = true;
    }

    public void CloseMenuPanel()
    {
        cursorView.HideCursor();


        playerController.isPaused = false;
        playerInteraction.isPaused = false;
        timer.isPaused = false;
        menuPanel.SetActive(false);
        isPaused = false;



    }

    public void ClosePausePanel()
    {
        Time.timeScale = 1f;
        cursorView.HideCursor();
        playerController.isPaused = false;
        playerInteraction.isPaused = false;
        timer.isPaused = false;
        isPaused = false;
        pausePanel.SetActive(false);

    }

    public void CloseSettingsPanel()
    {
        playerController.isPaused = false;
        playerInteraction.isPaused = false;
        timer.isPaused = false;

        cursorView.HideCursor();
        settingsPanel.SetActive(false);
    }


}
