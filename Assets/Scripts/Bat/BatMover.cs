using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BatMover : MonoBehaviour
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private InputReader _input;
    [SerializeField] private Camera _camera;

    private Rigidbody2D _rigidbody2D;
    private Vector3 _startPosition;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;
    private bool _isJump;

    private void OnEnable()
    {
        _isJump = true;
        _input.IsFlyes += Fly;
    }

    private void OnDisable()
    {
        _input.IsFlyes -= Fly;
    }

    private void Start()
    {
        _startPosition = transform.position;
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
    }

    private void FixedUpdate()
    {
        if (_isJump && transform.position.y < _camera.orthographicSize)
        {
            _rigidbody2D.velocity = new Vector2(_speed, _tapForce);
            transform.rotation = _maxRotation;
            _isJump = false;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.fixedDeltaTime);
    }

    private void Fly()
    {
        _isJump = true;
    }

    public void Reset()
    {
        transform.position = _startPosition;
        _isJump = true;
    }
}
