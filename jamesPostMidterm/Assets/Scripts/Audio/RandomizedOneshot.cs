using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//make sure that gameobject has an audio source attached to it
[RequireComponent(typeof(AudioSource))]
public class RandomizedOneshot : MonoBehaviour
{
    //a component that plays a sound back as a one shot with user defined random pitch and volume parameters

    //fields
    //audio source (allows the user to add multiple sounds to be selected at random)
    private AudioSource audioSource;    
    //audio clip to play
    [SerializeField] List<AudioClip> audioClips;
    //random pitch amount
    [SerializeField] float pitchRandomAmount = 0;
    //random volume amount
    [SerializeField] float volumeRandomAmount = 0;
    //audioClip to play
    private int playClip = 0;

    //initialize fields
    private void Awake()
    {
        //set audioSource to the gameobject's Audio Source component
        audioSource = GetComponent<AudioSource>()
    }

    //methods
    //select a random audio clip to play from the audioClips List
    private void SelectRandomAudioClip()
    {

    }
    //randomize the clips pitch
    private void RandomizeAudioClipPitch()
    {

    }
    //randomize the clips volume
    private void RandomizeAudioClipVolume()
    {

    }
    //play audio clip with randomized parameters


}
