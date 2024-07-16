using UnityEngine;

[RequireComponent(typeof(Rotator))]
public class Cannon : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _shotPoint;
    [SerializeField] private Animator _animator;
    [SerializeField] private ParticleSystem _shotEffect;

    private Rotator _rotator;
    private Vector2 _direction;
    private float _time;
    private float _cooldown = 1f;

    private void Awake()
    {
        _rotator = GetComponent<Rotator>();

        _time -= _cooldown;
    }

    private void Update()
    {
        transform.rotation = _rotator.LookAt((Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized);
        Shoot(Input.GetKeyDown(KeyCode.Mouse0));
    }

    private void Shoot(bool isShoot)
    {
        if (_time + _cooldown <= Time.time && isShoot)
        {
            _animator.SetTrigger("Shot");
            _shotEffect.Play();
            Instantiate(_bulletPrefab, _shotPoint.position, transform.rotation);

            _time = Time.time;
        }
    }
}
