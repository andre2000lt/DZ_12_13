using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    private const KeyCode StartKey = KeyCode.F;
    private const float MinYPosition = -10f;
    private const int CoinsToWin = 3;
    private const int TimePerTry = 45;

    [SerializeField] private Ball _ball;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private List<Coin> _coins;
    [SerializeField] private TMP_Text _message;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Timer _timer;


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

        if (_timer.Value <= 0)
        {
            LoseGame();
        }

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
        _timer.StartTimer(45);

        _message.gameObject.SetActive(false);

        _isRunning = true;
    }

    private void LoseGame()
    {
        EndGame();
        ShowMessage(_loseMessage);
    }

    private void WinGame()
    {
        EndGame();
        ShowMessage(_winMessage);
    }

    private void EndGame()
    {
        _ball.Die();
        _timer.StopTimer();
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