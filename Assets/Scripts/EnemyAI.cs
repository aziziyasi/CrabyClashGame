using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("VFX")]
    public GameObject bloodParticleSystem;

    [Header("Animation")]
    public Animation animation;
    public AnimationClip animDie;

    //public AnimationClip anim;

    public float Heealth=20f;

    [PunRPC]
    public void takedamage(int amount){
        Heealth-=amount;
        if(Heealth<=0){
            //animDie = GetComponent<AnimationClip>();
            animation.Play(animDie.name);
            Die();
        }
    }

    void Die(){ 
            
            Destroy(gameObject); 
    }
}
