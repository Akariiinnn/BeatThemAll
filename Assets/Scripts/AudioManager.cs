using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public const string PLAYER_COMBO_PUNCH_SOUND = "playerComboPunchSound";
    public const string PLAYER_COMBO_FINISH_SOUND = "playerComboFinishSound";
    public const string PLAYER_STRONG_KICK = "playerStrongKick";
    
    [SerializeField] private AudioClip playerComboPunchSound;
    [SerializeField] private AudioClip playerComboFinishSound;
    [SerializeField] private AudioClip playerStrongKick;
    
    private AudioSource audioSource;
    
    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    public AudioClip getSound(string sound)
    {
        switch (sound)
        {
            case PLAYER_COMBO_PUNCH_SOUND:
                return playerComboPunchSound;
            case PLAYER_COMBO_FINISH_SOUND:
                return playerComboFinishSound;
            case PLAYER_STRONG_KICK:
                return playerStrongKick;
            default:
                return null;
        }
    }
    
    public void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
