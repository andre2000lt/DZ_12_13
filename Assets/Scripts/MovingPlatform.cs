using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private const int ForwardDirection = 1;
    private const int BackwardDirection = -1;

    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _zOffset = 13f;

    private float _startZposition;
    private int _direction;

    private void Awake()
    {
        _startZposition = transform.localPosition.z;
        _direction = ForwardDirection;
    }

    private void Update()
    {
        if (transform.position.z > _startZposition + _zOffset)
        {
            _direction = BackwardDirection;
        }

        if (transform.position.z < _startZposition)
        {
            _direction = ForwardDirection;
        }

        transform.Translate(Vector3.forward * (_direction * _speed * Time.deltaTime), Space.Self);
    }
}