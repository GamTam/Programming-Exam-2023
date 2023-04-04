using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class BallController : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private bool _flipped;
    [SerializeField] private Rigidbody _rb;
    public bool _falling;
    private float _fallTimer;
    private float _gameOverTimer = 1f;

    void Update()
    {
        if (!GameManager.GameStarted) return;

        if (_falling)
        {
            _gameOverTimer -= Time.deltaTime;
            if (_gameOverTimer <= 0)
            {
                if (GameManager.Score > GameManager.HighScore) GameManager.HighScore = GameManager.Score;
                UIManager.Instance.GameOver();
            }
        }

        float distance = _speed * Time.deltaTime;
        Vector3 newPos = transform.position;

        if (Input.GetMouseButtonDown(0)) _flipped = !_flipped;
        
        if (_flipped) newPos.z += distance;
        else newPos.x += distance;

        transform.position = newPos;
        if (_rb.velocity.y < -0.5)
        {
            _fallTimer += Time.deltaTime;
            if (_fallTimer >= 0.2f) _falling = true;
        }
        else
        {
            _fallTimer = 0;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Gem":
                Destroy(other.gameObject);
                ScoreManager.Instance.IncrementScore();
                break;
        }
    }
}