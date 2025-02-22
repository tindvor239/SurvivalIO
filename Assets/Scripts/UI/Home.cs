using UnityEngine;
using UnityEngine.UI;

public class Home : MonoBehaviour
{
    [SerializeField]
    private Button _startButton;
    [SerializeField]
    private Button _closeButton;

    private void Awake()
    {
        _startButton.onClick.AddListener(StartGame);
        _closeButton.onClick.AddListener(CloseGame);
    }

    private void StartGame()
    {
        // Add your scene loading logic here
        Debug.Log("Starting Game...");
        SceneLoader.Instance.LoadGameplay();
    }

    private void CloseGame()
    {
        // Add your scene loading logic here
        Debug.Log("Close Game...");
        Application.Quit();
    }
}
