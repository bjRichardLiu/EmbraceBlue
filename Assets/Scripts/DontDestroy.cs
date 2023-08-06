using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    public AudioClip bgm;
    private void Start()
    {
        musicSource.clip = bgm;
        musicSource.Play();
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
