using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class HamburgerScore : MonoBehaviour
{

    public Health HealthScore;
    public AudioSource audio;

    void Start()
    {
       audio = GetComponent<AudioSource>();

    }


    [Header("Animation")]
    public Animation animation;
    public AnimationClip Zoom;

  void OnTriggerEnter(Collider other){
    audio.PlayOneShot(audio.clip);
    
      if(other.gameObject.tag == "Player"){
            HealthScore=FindObjectOfType<Health>();
            HealthScore.health += 10;
            HealthScore.healthBar.sizeDelta = new Vector2(HealthScore.originalHealthBarSize * HealthScore.health / 100f, HealthScore.healthBar.sizeDelta.y);
            Destroy(gameObject);

        }
        
       // other.GetComponent<Health>().TakeDamageScore(score); 
    }
}
