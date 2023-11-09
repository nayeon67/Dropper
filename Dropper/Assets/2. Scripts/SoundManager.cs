using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance
    {
        get
        {
            if(instance == null)
            {
                return null;
            }
            return instance;
        }
    }
    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    //BGM을 재생할 source
    [SerializeField] private AudioSource bgmSource;
    //효과음을 재생할 source
    [SerializeField] private AudioSource sfxSource;
    //배경음 오디오 클립들
    [SerializeField] private AudioClip[] bgmClips;
    //배경음을 저장해둘 딕셔너리
    private Dictionary<string, AudioClip> bgmClipDic = new Dictionary<string, AudioClip>();
    //효과음 오디오 클립들
    [SerializeField] private AudioClip[] sfxClips;
    //효과음을 저장해둘 딕셔너리
    private Dictionary<string, AudioClip> sfxClipDic = new Dictionary<string, AudioClip>();
    void Start()
    {
        //딕셔너리에 오디오 클립 이름과 오디오 클립으로 저장
        foreach(AudioClip cilp in bgmClips)
        {
            bgmClipDic.Add(cilp.name, cilp);
        }
        foreach(AudioClip cilp in sfxClips)
        {
            sfxClipDic.Add(cilp.name, cilp);
        }

        PlayBGM("Title");
    }

    public void PlayBGM(string bgmName)
    {
        if(bgmClipDic.ContainsKey(bgmName))
        {
            bgmSource.clip = bgmClipDic[bgmName];
            bgmSource.Play();
        }
    }

    public void PlaySFX(string sfxName)
    {
        if(sfxClipDic.ContainsKey(sfxName))
        {
            sfxSource.PlayOneShot(sfxClipDic[sfxName]);
        }
    }
}
