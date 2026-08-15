using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _damage;
    private float _speed;
    private float _maxRange;
    private float _distanceTravelled;

    private Coroutine _updateCoroutine;

    public void Initialize(float damage, float speed, float maxRange)
    {
        this._damage = damage;
        this._speed = speed;
        this._maxRange = maxRange;

        _distanceTravelled = 0f;

        _updateCoroutine = StartCoroutine(UpdateRoutine());
    }

    IEnumerator UpdateRoutine()
    {
        while(true)
        {
            float distance =
                _speed * Time.deltaTime;

            transform.position +=
                transform.up * distance;

            _distanceTravelled += distance;

            if (_distanceTravelled >= _maxRange)
            {
                ReturnToPool();
                yield break;
            }

            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamageable target =
            other.GetComponentInParent<IDamageable>();

        if (target != null)
        {
            target.TakeDamage(_damage);
        }

        ReturnToPool();
        StopCoroutine(_updateCoroutine);
    }

    private void ReturnToPool()
    {
        // Tạm thời
        gameObject.SetActive(false);
        Destroy(gameObject);

        // Sau này đổi thành BulletPool.Release(this)
    }
}