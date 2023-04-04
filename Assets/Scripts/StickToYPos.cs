using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToYPos : MonoBehaviour
{
    private float _yPos;
    [SerializeField] private BallController _ball;
    
    void Start()
    {
        _yPos = transform.position.y;
    }

    void LateUpdate()
    {
        if (_ball._falling) transform.SetParent(null, true);
        transform.position = new Vector3(transform.position.x, _yPos, transform.position.z);
    }
}
