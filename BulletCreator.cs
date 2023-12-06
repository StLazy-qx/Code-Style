using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCreator : MonoBehaviour
{
    [SerializeField] private float _shotForce;
    [SerializeField] private float _timeWaitShooting;
    [SerializeField] private Rigidbody _templateBullet;

    private Transform _shootPoint;

    private void Start()
    {
        StartCoroutine(TakeShoot());
    }

    private IEnumerator TakeShoot()
    {
        while (true)
        {
            Vector3 shootDirection = (_shootPoint.position - transform.position).normalized;
            Rigidbody newBullet = Instantiate(_templateBullet, transform.position + shootDirection, Quaternion.identity);

            newBullet.transform.up = shootDirection;
            newBullet.velocity = shootDirection * _shotForce;

            yield return new WaitForSeconds(_timeWaitShooting);
        }
    }
}