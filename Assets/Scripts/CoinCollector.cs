using TMPro;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinCountText;

    public int CoinCount { get; private set; }

    private void Awake()
    {
        UpdateBallanceOutput();
    }

    private void OnTriggerEnter(Collider other)
    {
        Coin coin = other.GetComponent<Coin>();

        if (coin != null)
        {
            Add();
            coin.Collect();
        }
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