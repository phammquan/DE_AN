using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Controller : MonoBehaviour
{
    [SerializeField] List<LoopImage> loopImages = new List<LoopImage>();
    [SerializeField] List<float> speed = new List<float>();

    void Update()
    {
        int way = 1;
        if (PlayerController.Instance.playerState == PlayerController.PlayerState.IDEL)
        {
            return;
        }
        if (GameManager.Instance.Player.transform.localScale.x > 0)
            way = -1;
        if (GameManager.Instance.Player.transform.localScale.x < 0)
            way = 1;
        for (int i = 0; i < loopImages.Count; i++)
        {
            loopImages[i].transform.position += speed[i] * new Vector3(way, 0, 0) * Time.deltaTime;
        }
    }
}
