using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    private int selectedWeapon = 0;

    private AudioSource audio;

    public Animation _animation;
    public AnimationClip changeweapon;

    void Start()
    {
        audio = GetComponent<AudioSource>();

        SelectWeapon();
    }

    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

        if (Input.GetKeyDown(KeyCode.Alpha1)){
            selectedWeapon = 0;
            audio.PlayOneShot(audio.clip);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)){
            selectedWeapon = 1;
            audio.PlayOneShot(audio.clip);
        }

        if(Input.GetAxis("Mouse ScrollWheel") > 0){
            if (selectedWeapon >= transform.childCount - 1 ){
                selectedWeapon = 0;
            } else {
                selectedWeapon +=1 ;
            }
        }
        if(Input.GetAxis("Mouse ScrollWheel") < 0){
            if (selectedWeapon <= 0){
                selectedWeapon = transform.childCount - 1 ;
            } else {
                selectedWeapon -=1 ;
            }
        }

        if (previousSelectedWeapon != selectedWeapon){
            SelectWeapon();
        }
    }

    void SelectWeapon(){
        if(selectedWeapon >= transform.childCount){
            selectedWeapon = transform.childCount -1;
        }

        //_animation.stop();
        _animation.Play(changeweapon.name);

        int i = 0;
        foreach(Transform _weapon in transform){
            if(i == selectedWeapon){
                _weapon.gameObject.SetActive(true);
            } else{
                _weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
