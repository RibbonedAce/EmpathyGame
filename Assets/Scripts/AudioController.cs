using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private AudioSource source;                                     // Where to play the audio from
    [SerializeField]
    private AudioClip[] clips;                                      // The audio clips to play in game
    #endregion

    #region Properties
    public static AudioController Instance { get; private set; }    // The instance to reference
    #endregion

    #region Events
    // Awake is called before Start
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }
    #endregion

    #region Methods
    // Play a given clip
    public void PlayClip(int index)
    {
        if (index < clips.Length)
        {
            source.clip = clips[index];
            source.Play();
        }
    }
    #endregion

    #region Coroutines

    #endregion
}
