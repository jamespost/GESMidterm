using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//a component that plays a sound back as a one shot with user defined random pitch and volume parameters
//make sure that gameobject has an audio source attached to it
[RequireComponent(typeof(AudioSource))]
public class RandomizedOneshot : MonoBehaviour
{    
    //fields
    //audio source 
    AudioSource audioSource;
    //audio clips to play (allows the user to add multiple sounds to be selected at random)
    [SerializeField] List<AudioClip> audioClips;
    //initial pitch
    float initialPitch = 1f;
    //initial volume
    float initialVolume = 1f;
    //random pitch amount
    [SerializeField] float pitchRandomAmount = 0f;
    //random volume amount
    [SerializeField] float volumeRandomAmount = 0f;
    
    //initialize fields
    private void Awake()
    {
        //set audioSource to the gameobject's Audio Source component
        audioSource = GetComponent<AudioSource>();
        //set audioSource to *not* play on awake
        audioSource.playOnAwake = false;

        //functionality testing REMOVE WHEN FINISHED WRITING CLASS
        InvokeRepeating("PlayRandomizedAudioClip", 1f, 1f);
    }

    //methods
    //select a random audio clip to play from the audioClips List
    private int SelectRandomAudioClip()
    {
        //declare a local int to return as result of method
        int randomClipResult = 0;
        //get the size of the audioClips List and assigns it to randomClipUpperBound
        int randomClipUpperBound = audioClips.Count;
        //assign randomClipResult to the result of the Random.Range() method
        randomClipResult = Random.Range(0, randomClipUpperBound);
        //return the resulting int
        return randomClipResult;        
    }

    //randomize the clips pitch
    private void RandomizeAudioClipPitch()
    {
        //set randomPitch to the result of Random.Range() where the user defined pitchRandomAmount is the lower and upper bound
        float randomPitch = Random.Range(-pitchRandomAmount, pitchRandomAmount);
        //scale the randomPitch result to 12TET
        audioSource.pitch = (initialPitch * Mathf.Pow(1.05946f, randomPitch));
    }

    //randomize the clips volume
    private void RandomizeAudioClipVolume()
    {
        //set randomVolume to the result of Random.Range() where the user defined volumeRandomAmount is the lower and upper bound
        float randomVolume = Random.Range(-volumeRandomAmount, volumeRandomAmount);
        audioSource.volume = initialVolume + randomVolume;
    }

    //play audio clip with randomized parameters
    public void PlayRandomizedAudioClip()
    {
        //select an audio clip to play from audioClips list
        //default is 0th position (first audio clip the user added)
        int audioClipToPlay = 0;
        //if user has added more than one audio clip to the audioClips List select one clip to play at random
        if(audioClips.Count > 1)
        {
            audioClipToPlay = SelectRandomAudioClip();
        }
        
        //check if the user wants the clip's pitch to be randomized
        if (pitchRandomAmount != 0)
        {
            //randomize the audio clip's pitch
            RandomizeAudioClipPitch();
        }
        //check if the user wants the clip's volume to be randomized
        if (volumeRandomAmount != 0)
        {
            //randomize the audio clip's volume
            RandomizeAudioClipVolume();
        }

        //play the audio clip selected by default or at random
        audioSource.PlayOneShot(audioClips[audioClipToPlay]);
    }
}
