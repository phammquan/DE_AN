using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopImage : MonoBehaviour
{
    Texture texture;
    [SerializeField] int _pixelWidth;
    [SerializeField] Transform _player;
    float _inGameWidth;
    void Start()
    {
        texture = this.GetComponent<SpriteRenderer>().sprite.texture;
        _inGameWidth = texture.width / _pixelWidth;
    }

    void Update()
    {
        if (Mathf.Abs(_player.position.x - this.transform.position.x) >= _inGameWidth)
        {
            Vector2 pos = this.transform.position;
            pos.x = _player.transform.position.x;
            this.transform.position = pos;
        }
    }
}
