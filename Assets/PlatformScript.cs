using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;

    private float _timer = 0;
    private bool _startTimer;

    private float _yPos;

    private BoxCollider _col;
    private BallController _player;
    
    private void Start()
    {
        _yPos = transform.position.y;
        _col = GetComponent<BoxCollider>();
        _player = FindObjectOfType<BallController>();
    }

    private void Update()
    {
        if (_player._falling)
        {
            _col.enabled = false;
        }
        
        if (!_startTimer)
        {
            transform.position = new Vector3(transform.position.x, _yPos, transform.position.z);
            return;
        }
        _timer += Time.deltaTime;
        _rb.useGravity = true;
        _rb.freezeRotation = false;

        if (_timer >= 2f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                _startTimer = true;
                break;
        }
    }
}
