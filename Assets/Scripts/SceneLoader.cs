using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadGameplay()
    {
        // Add your scene loading logic here
        Debug.Log("Loading Main Menu...");
        SceneManager.LoadScene("Gameplay");
    }

    public void LoadHome()
    {
        // Add your scene loading logic here
        Debug.Log("Loading Home...");
        SceneManager.LoadScene("Home");
    }
}