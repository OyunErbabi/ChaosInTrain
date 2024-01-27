using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] audioClips;

    private AudioSource audioSource;

    private void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();

        // Make sure there are audio clips assigned in the inspector
        if (audioClips.Length == 0)
        {
            Debug.LogError("No audio clips assigned!");
        }
    }

    private void Update()
    {
        // Check for button presses
        CheckButtonPress();
    }

    private void CheckButtonPress()
    {
        // Check for numeric keys (1 to 9)
        for (int i = 1; i <= 9; i++)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                PlayAudioClip(i - 1); // Subtract 1 because array indices start from 0
                break;
            }
        }
    }

    private void PlayAudioClip(int index)
    {
        // Make sure the index is within the array bounds
        if (index >= 0 && index < audioClips.Length)
        {
            // Stop any currently playing audio and play the selected clip
            audioSource.Stop();
            audioSource.clip = audioClips[index];
            audioSource.Play();
        }
        else
        {
            Debug.LogError("Invalid audio clip index!");
        }
    }
}