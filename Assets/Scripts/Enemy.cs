using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Rotator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _speed;
    [SerializeField] private Cannon _target;

    private Rigidbody2D _rigidbody;
    private Rotator _rotator;
    private Vector2 _direction;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rotator = GetComponent<Rotator>();

        _direction = (_target.transform.position - transform.position).normalized;
    }

    private void Update()
    {
        transform.rotation = _rotator.LookAt(_direction);

        _rigidbody.velocity = _direction * _speed;
    }

    public void Init(Cannon target) => _target = target;

    public void TakeDamage(float damage)
    {
        if ((_health -= damage) <= 0)
            Destroy(gameObject);
    }
}
