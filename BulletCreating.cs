using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class BulletCreating : MonoBehaviour
{
    [SerializeField] private float _number;
    [SerializeField] private float _timeWaitShooting;
    [SerializeField] private GameObject _template;

    private Transform _shootObject;

    private void Start()
    {
        StartCoroutine(TakeShoot());
    }

    private IEnumerator TakeShoot()
    {
        while (true)
        {
            var shootDirection = (_shootObject.position - transform.position).normalized;
            var NewBullet = Instantiate(_template, transform.position + shootDirection, Quaternion.identity);

            NewBullet.GetComponent<Rigidbody>().transform.up = shootDirection;
            NewBullet.GetComponent<Rigidbody>().velocity = shootDirection * _number;

            yield return new WaitForSeconds(_timeWaitShooting);
        }
    }
}