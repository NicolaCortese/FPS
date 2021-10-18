using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
   [SerializeField] float hitPoints = 100f;

    public bool isDead = false;

    public void TakingDamage(float damage){
        if(isDead){return;}
        hitPoints -= damage;
        BroadcastMessage("OnDamageTaken");
        if(hitPoints <= 0){
            isDead = true;            
            GetComponent<Animator>().SetTrigger("Death");
        }
    }
   

}
