using System;
using GameAssets.scripts;
using UnityEngine;

public class Avatar: MonoBehaviour
{
    public PlayerModel Player;

    private void Start()
    {
        InvokeRepeating(nameof(updateStamina),0f, 1f);
    }

    private void Update()
    {
        throw new NotImplementedException();
    }

    private void updateStamina()
    {
        Player.Stamina += 1;
    }
}