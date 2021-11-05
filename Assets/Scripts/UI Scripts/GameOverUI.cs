using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _endText;

    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;


    [SerializeField] private string _winText = "Поздравляю, Вы выиграли!";
    [SerializeField] private string _loseText = "К сожалению, Вы проиграли.";

    private CanvasGroup _group;

    private void Awake()
    {
        _group = GetComponent<CanvasGroup>();
        _group.alpha = 0;
    }

    private void OnEnable()
    {
        _player.EndOfGame += EndOfGameHandler;
        _restartButton.onClick.AddListener(OnRestart);
        _exitButton.onClick.AddListener(OnExit);
    }

    private void OnDisable()
    {
        _player.EndOfGame -= EndOfGameHandler;
        _restartButton.onClick.RemoveListener(OnRestart);
        _exitButton.onClick.RemoveListener(OnExit);
    }

    private void EndOfGameHandler(bool success)
    {
        _group.alpha = 1;
        _restartButton.interactable = true;
        _exitButton.interactable = true;

        if (success)
            _endText.SetText(_winText);

        else _endText.SetText(_loseText);
    }

    private void OnRestart()
    {
        SceneManager.LoadScene(0);
    }

    private void OnExit()
    {
        Application.Quit();
    }
}

