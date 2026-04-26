using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public AudioSource bgm;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        bgm.loop = true;
        bgm.volume = 0.05f;
        bgm.Play();
    }
}