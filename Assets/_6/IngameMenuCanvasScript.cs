using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class IngameMenuCanvasScript : MonoBehaviour
{
    [SerializeField] private ContinuousMoveProviderBase continuousMoveProvider;
    [SerializeField] private ActionBasedControllerManager manager;
    [SerializeField] private InputActionReference m_Menu;
    // private InputAction menuAction;
    [SerializeField] private GameObject pauseMenuUI; // Ссылка на панель паузы
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject settingsPanel;
    private bool isPaused = false;

    private void Awake()
    {
        m_Menu.action.performed += ToggleMenu;
        continuousMoveProvider.beginLocomotion += (_) => Resume();
    }

    private void ToggleMenu(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() < 1.0f) return;
        if (!isPaused)
        {
            Pause();
        } else
        {
            Resume();
        }
    }

    public void ToggleLocoCont()
    {
        manager.smoothMotionEnabled = !manager.smoothMotionEnabled;
    }

    public void Menu()
    {
        mainPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    public void Resume()
    {
        Menu();
        pauseMenuUI.SetActive(false); // Скрываем меню паузы
        // Time.timeScale = 1f; // Возобновляем игровой процесс
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2f;
        pauseMenuUI.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
        pauseMenuUI.SetActive(true); // Показываем меню паузы
        // Time.timeScale = 0f; // Останавливаем игровой процесс
        isPaused = true;
    }

    public void Settings()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void QuitGame()
    {
        // Time.timeScale = 1f; // Возобновляем время перед выходом

#if UNITY_EDITOR
        // Завершаем игровой режим в редакторе
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Закрываем приложение в сборке
        Application.Quit();
#endif

        Debug.Log("Quit Game!");
    }
}
