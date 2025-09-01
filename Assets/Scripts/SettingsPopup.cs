using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class SettingsPopup : MonoBehaviour
{
    [SerializeField] Slider music;
    [SerializeField] AudioSource bgMusic;
    [SerializeField] Slider soundEffects;
    [SerializeField] AudioSource jumping;
    [SerializeField] AudioSource collectionDing;
    [SerializeField] AudioSource walking;
    [SerializeField] AudioSource explosion;
    [SerializeField] AudioSource digging;
    [SerializeField] AudioSource watergun;
    [SerializeField] AudioSource crabSound;
    [SerializeField] AudioSource frogSound;
    [SerializeField] AudioSource eggSound;
    [SerializeField] Toggle landMine;
    [SerializeField] TMP_Dropdown playerSpeed;
    [SerializeField] Button resume;
    [SerializeField] Button exitGame;
    [SerializeField] Button restart;
    [SerializeField] Button creditScreen;
    [SerializeField] BetterPlayerMovement player;


    public void ChangeMusicVolume()
    {
        bgMusic.volume = music.value;
    }

    public void ChangeSoundEffectsVolume()
    {
        jumping.volume = soundEffects.value;
        collectionDing.volume = soundEffects.value;
        walking.volume = soundEffects.value;
        explosion.volume = soundEffects.value;
        digging.volume = soundEffects.value;
        watergun.volume = soundEffects.value;
        crabSound.volume = soundEffects.value;
        frogSound.volume = soundEffects.value;
        eggSound.volume = soundEffects.value;
    }

    public void OpenPopup()
    {
        gameObject.SetActive(true);
    }

    public void ClosePopup()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OnToggleLandMine (bool blowUp)
    {
        TurtleMineScript.explode = blowUp;
    }

    public void DropdownPlayerSpeed()
    {
        if (playerSpeed.value == 0)
        {
            player.moveSpeed = 7f;
        }
        else if (playerSpeed.value == 1)
        {
            player.moveSpeed = 4f;
        }
        else if (playerSpeed.value == 2)
        {
            player.moveSpeed = 10f;
        }
    }
}
