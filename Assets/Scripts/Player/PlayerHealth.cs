using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerHitPoints = 100f;


    public void PlayerTakingDamage(float damage){
        Debug.Log("player getting hit");
        playerHitPoints -= damage;
        if(playerHitPoints <= 0){
            GetComponent<DeathHandler>().HandleDeath();
        }
    }


}
