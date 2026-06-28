using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuControllerComponent : MonoBehaviour
{
    private void Update()
    {
        InputSystem.Update();
    }

    public void UiHostGame()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void UiJoinGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void UiOpenSettings()
    {
        Debug.Log("Settings Not Implimented yet");
    }

    public void UiQuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
