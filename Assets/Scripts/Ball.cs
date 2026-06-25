using UnityEngine;

public class Ball : MonoBehaviour
{
    public void StartAt(Vector3 position)
    {
        Controller controller = GetComponent<Controller>();
        controller.Stop();

        gameObject.SetActive(true);
        transform.position = position;
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}