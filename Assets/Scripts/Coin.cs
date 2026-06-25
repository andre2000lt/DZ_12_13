using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Wallet wallet = other.GetComponent<Wallet>();

        if (wallet != null)
        {
            wallet.Add();
            gameObject.SetActive(false);
        }
    }
}