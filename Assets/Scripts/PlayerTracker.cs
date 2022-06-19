using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private OurPlayerTower _outPlayerTower;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Vector3 _offsetPosition;
    [SerializeField] private Vector3 _offsetRotation;

    private Vector3 _targetOffsetPosition;

    private void OnEnable()
    {
        _outPlayerTower.HumanAdded += OnHumanAdded;
    }

    private void OnDisable()
    {
        _outPlayerTower.HumanAdded -= OnHumanAdded;
    }

    private void Update()
    {
        UpdatePosition();
        _offsetPosition = Vector3.MoveTowards(_offsetPosition, _targetOffsetPosition, _moveSpeed * Time.deltaTime);
    }

    private void UpdatePosition()
    {
        transform.position = _outPlayerTower.transform.position;
        transform.localPosition += _offsetPosition; 

        Vector3 lookAtPoint = _outPlayerTower.transform.position + _offsetRotation;

        transform.LookAt(lookAtPoint); 
    }

    private void OnHumanAdded(int count)
    {
        _targetOffsetPosition = _offsetPosition + (Vector3.up + Vector3.back) * count;
        UpdatePosition();
    }
}
