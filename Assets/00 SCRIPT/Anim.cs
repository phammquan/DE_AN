using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerState = PlayerController.PlayerState;

public class Anim : MonoBehaviour
{
    Animator _ani;
    private void Start()
    {
        _ani = GetComponent<Animator>();
    }
    public void UpdateAnimation(PlayerState _playerState) 
    {
        for(int i = 0;  i <= (int)PlayerState.JUMP; i++)
        {
            string StateName = ((PlayerState)i).ToString();
            if(_playerState == (PlayerState)i)
            {
                _ani.SetBool(StateName, true);
            }
            else
            {
                _ani.SetBool(StateName, false);
            }
        }
    }
}
