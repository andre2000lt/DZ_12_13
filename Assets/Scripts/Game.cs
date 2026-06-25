using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    private const KeyCode StartKey = KeyCode.F;
    private const float MinYPosition = -10f;
    private const int CoinsToWin = 3;

    [SerializeField] private Ball _ball;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private List<Coin> _coins;
    [SerializeField] private TMP_Text _message;
    [SerializeField] private Wallet _wallet;


    private bool _isRunning;

    private readonly string _startMessage = $"Нажмите {StartKey} для старта игры";
    private readonly string _loseMessage = "Вы проиграли !";
    private readonly string _winMessage = "Победа !";

    private void Awake()
    {
        ShowMessage(_startMessage);
    }

    private void Update()
    {
        if (_ball.transform.position.y < MinYPosition)
            LoseGame();

        if (_wallet.CoinCount == CoinsToWin)
            WinGame();


        if (Input.GetKeyDown(StartKey))
        {
            if (_isRunning == false)
                StartPlay();
        }
    }

    private void StartPlay()
    {
        _ball.StartAt(_startPosition.position);
        InitCoins();
        _wallet.Reset();

        _message.gameObject.SetActive(false);

        _isRunning = true;
    }

    private void LoseGame()
    {
        _ball.Die();

        ShowMessage(_loseMessage);

        _isRunning = false;
    }

    private void WinGame()
    {
        _ball.Die();

        ShowMessage(_winMessage);

        _isRunning = false;
    }

    private void InitCoins()
    {
        foreach (Coin coin in _coins)
        {
            coin.gameObject.SetActive(true);
        }
    }

    private void ShowMessage(string message)
    {
        _message.gameObject.SetActive(true);
        _message.text = message;
    }
}