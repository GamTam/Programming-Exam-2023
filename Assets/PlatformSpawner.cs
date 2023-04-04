using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _platform;
    [SerializeField] private GameObject _gem;
    [SerializeField] private BallController _player;

    private float _timer = 0.2f;

    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            SpawnPlatform();
        }
    }

    private void Update()
    {
        if (_player._falling || !GameManager.GameStarted) return;

        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            SpawnPlatform();
            _timer = 0.2f;
        }
    }

    void SpawnPlatform()
    {
        Random rand = new Random();
        int spawnPos = rand.Next(100);
        Vector3 newPos = transform.position;

        if (spawnPos % 2 == 0) newPos.x += 4;
        else newPos.z += 4;
        
        GameObject obj = Instantiate(_platform);
        obj.transform.position = newPos;
        transform.position = newPos;

        if (spawnPos < 10)
        {
            obj = Instantiate(_gem);
            newPos.y += 1;
            obj.transform.position = newPos;
        }
    }
}
