using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] Vector2 _offset;
    void Update()
    {
        Vector3 pos = _player.position + (Vector3)_offset;
        pos.z = Camera.main.transform.position.z;
        if (_player.position.y < 0)
        {
            pos.y = Camera.main.transform.position.y;
            Camera.main.transform.position = pos;
        }
        else
        {
            Camera.main.transform.position = pos;
        }

    }
}
