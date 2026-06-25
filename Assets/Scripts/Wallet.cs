using TMPro;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinCountText;

    public int CoinCount { get; private set; }

    private void Awake()
    {
        UpdateBallanceOutput();
    }

    public int Add()
    {
        CoinCount++;
        UpdateBallanceOutput();

        return CoinCount;
    }

    public void Reset()
    {
        CoinCount = 0;
        UpdateBallanceOutput();
    }

    private void UpdateBallanceOutput()
    {
        _coinCountText.text = $"Количество монет: {CoinCount}";
    }
}