using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening.Core.Easing;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public List<AudioClip> audioClips;
    public List<AudioClip> MusicClips;

    [Header("SFX")]
    public AudioSource NonPitchSounds;
    public AudioSource PitchSounds;

    [Header("Music")]
    public AudioSource MusicSound;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Sounds
    // 0 - Spawn
    // 1 - Mj Fall
    // 2 - MetalPot2
    // 3 - PoliceFootStep1
    // 4 - PoliceFootStep2
    // 5 - PrisonerFootStep1
    // 6 - PrisonerFootStep2
    // 7 - ButtonBeep
    // 8 - TrueBeep
    // 9 - FalseBeep
    // 10 - WaterFill
    // 11 - Confirm
    // 12 - Beep Negative
    // 13 - MetalDoor1
    // 14 - MetalDoor2
    // 15 - MemoryBeep
    // 16 - MemoryBeep2
    // 17 - Swing
    // 18 - Swing2
    // 19 - Swing3
    // 20 - DoorShake
    // 21 - CatchChoir1
    // 22 - CatchChoir2
    // 23 - CatchChoir3
    // 24 - Police1
    // 25 - Police2
    // 26 - Police3
    // 27 - Police4
    // 28 - Police5
    // 29 - Police6
    // 30 - DoorOpenWood
    // 31 - Prisoner1
    // 32 - Prisoner2
    // 33 - Prisoner3
    // 34 - Prisoner4
    // 35 - Electric Lever
    // 36 - Electric Sfx
    // 37 - FalseLock
    // 38 - TakeKey


    public void PlaySound(int index, float pitch = 1)
    {
        //PitchSounds.volume = SaveManager.instance.saveData.SfxVolume;
        PitchSounds.pitch = pitch;
        PitchSounds.PlayOneShot(audioClips[index]);
    }

    public void PlaySound(int index)
    {
        //NonPitchSounds.volume = SaveManager.instance.saveData.SfxVolume;
        NonPitchSounds.PlayOneShot(audioClips[index]);
    }


    public void PlayMusic()
    {
        //MusicSound.volume = SaveManager.instance.saveData.MusicVolume;
        MusicSound.clip = MusicClips[0];
        MusicSound.Play();
    }


    public void StopMusic()
    {
        if (MusicSound.isPlaying)
        {
            MusicSound.Stop();
        }

    }


}