using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private float _damage;
    [SerializeField] private float _force;
    [SerializeField] private LayerMask _layerMask;

    private WaitForSeconds _wait;
    private float _waitTime = 3f;

    private void OnEnable()
    {
        _wait = new WaitForSeconds(_waitTime);

        StartCoroutine(nameof(GetInPool));
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, _distance, _layerMask);

        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.TryGetComponent(out Enemy enemy))
            {
                enemy.TakeDamage(_damage);
                Destroy(gameObject);
            }
        }

        transform.Translate(Vector2.up * _force * Time.deltaTime);
    }

    private IEnumerator GetInPool()
    {
        yield return _wait;

        Destroy(gameObject);
    }
}
