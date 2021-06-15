using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject DeathEffect;
    private void OnTriggerEnter(Collider other)
    {
        PlayerDeath();
    }
    void PlayerDeath()
    {
        Debug.Log("Player is dead");
        //SendMessage("OnPlayerDeath");
        //DeathEffect.SetActive(true);
    }
}
