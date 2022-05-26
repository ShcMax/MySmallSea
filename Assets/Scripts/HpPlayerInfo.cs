using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HpPlayerInfo : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] Image _hpImage;

    private float maxHealth;
   
    
    void Start()
    {
        _player.changeHealth += HealthChange;
        maxHealth = _player.PlayerMaxHealth;
    }

    void HealthChange(float health)
    {
        _hpImage.fillAmount = health / maxHealth;
    }
}
