using UnityEngine;
using Random = UnityEngine.Random;

public class Rotator : MonoBehaviour
{
    private readonly int LeftRotation = -1;
    private readonly int RightRotation = 1;

    private const float RotationSpeed = 50f;

    private int _rotateDirection;

    private void Awake()
    {
        _rotateDirection = Random.Range(0, 2) == 0 ? LeftRotation : RightRotation;
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * (Time.deltaTime * RotationSpeed * _rotateDirection));
    }
}