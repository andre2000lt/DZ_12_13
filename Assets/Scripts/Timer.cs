using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private const int DefaultValue = 60;
    private const string ParamName = "Time: ";
    private const float Second = 1f;

    [SerializeField] private TMP_Text _timerOutput;
    private float _partOfSecond;

    public int Value { get; private set; }
    private bool _isRunning;

    private void Start()
    {
        _partOfSecond = Second;
        Value = DefaultValue;
    }

    private void Update()
    {
        if (_isRunning == false) return;

        Run();
    }

    public void StartTimer(int time = DefaultValue)
    {
        Value = time;
        _isRunning = true;
    }

    public void StopTimer()
    {
        _isRunning = false;
    }

    public void Run()
    {
        _partOfSecond -= Time.deltaTime;

        if (_partOfSecond <= 0)
        {
            Value -= 1;
            UpdateTimerOutput();
            _partOfSecond = Second;
        }
    }

    private void UpdateTimerOutput()
    {
        _timerOutput.text = ParamName + Value;
    }
}