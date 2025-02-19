using System;
using UnityEngine;
using UnityEngine.UIElements;

[Serializable]
public class PlayerData : MonoBehaviour
{
    public ToolType _currentTool;
    public bool isDead;
    float health;

    public PlayerData(PlayerStats player)
    {
        health = player.currentHealth;
    }
}
