using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOver : UIPopup
{
    [SerializeField]
    private Button _homeButton;
    [SerializeField]
    private TMP_Text _scoreText;

    private void Awake()
    {
        this.RegisterListener(EventID.OnGameOver, OnDeath);
        _homeButton.onClick.AddListener(ReturnHome);
    }

    private void OnDestroy()
    {
        this.RemoveListener(EventID.OnGameOver, OnDeath);
    }

    private void OnDeath(object param)
    {
        Time.timeScale = 0;
        _scoreText.text = $"Score: {param}";
        Show();
    }

    private void ReturnHome()
    {
        Close();
        SceneLoader.Instance.LoadHome();
        Time.timeScale = 1;
    }
}
