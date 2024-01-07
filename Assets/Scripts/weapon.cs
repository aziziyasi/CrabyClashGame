using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    private AudioSource audio;
    public int damage;
    public float fireRate;
    public Camera camera;

    private float nextFire;

    [Header("VFX")]
    public GameObject hitVFX;

    void Start()
    {
       audio = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (nextFire > 0) {
            nextFire -= Time.deltaTime;
        }

        if (Input.GetButton("Fire1") && nextFire <=0 ) {
            nextFire = 1 / fireRate;

            Fire();
        }
    }
    void Fire() {
        Ray ray = new Ray(camera.transform.position,camera.transform.forward);

        RaycastHit hit;
           audio.PlayOneShot(audio.clip);
        if (Physics.Raycast(ray.origin, ray.direction, out hit, 100f)) {
            PhotonNetwork.Instantiate(hitVFX.name,hit.point,Quaternion.identity);
            if (hit.transform.gameObject.GetComponent<Health>()) {
                hit.transform.gameObject.GetComponent<PhotonView>().RPC("TakeDamage", RpcTarget.All,damage);  
            }
            
        }
    }
}
