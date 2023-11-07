using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType(typeof(PlayerManager)) as PlayerManager;

            return instance;
        }
        set
        {
            instance = value;
        }
    }
    private static PlayerManager instance;


    public UnityAction<float> OnPlayerDamage;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayerDamage(float damage)
    {
        /*NullReferenceException: Object reference not set to an instance of an object
        PlayerManager.PlayerDamage (System.Single damage) (at Assets/Scripts/Player/PlayerManager.cs:29)
        No tengo idea de por que sigue saliendo este error. Ayuda, por favor*/
        OnPlayerDamage.Invoke(damage);
    }

    public void AddOnPlayerObserver(UnityAction<float> action)
    {
        OnPlayerDamage += action;
    }
}
