using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinMenu : UIPopup
{
    [SerializeField]
    private Button _homeButton;
    [SerializeField]
    private TMP_Text _scoreText;

    private void Awake()
    {
        this.RegisterListener(EventID.OnWin, OnWin);
        _homeButton.onClick.AddListener(ReturnHome);
    }

    private void OnDestroy()
    {
        this.RemoveListener(EventID.OnWin, OnWin);
    }

    private void OnWin(object param)
    {
        Time.timeScale = 0;
        _scoreText.text = $"Score: {param}";
        Show();
    }

    private void ReturnHome()
    {
        Close();
        SceneLoader.Instance.LoadHome();
    }
}
