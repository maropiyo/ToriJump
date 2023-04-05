using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    // AudioSource
    public AudioSource audioSource;
    // BGM
    public AudioSource bgm;
    // ジャンプ時の効果音
    public AudioClip jumpSound;
    // ハイジャンプ時の効果音
    public AudioClip highJumpSound;
    // スーパージャンプ時の効果音
    public AudioClip superJumpSound;
    // 落下時の効果音
    public AudioClip fallSound;

    void Awake()
    {
        // シングルトンパターンの実装
        Instance = Instance ? Instance : this;
        DontDestroyOnLoad(Instance.gameObject);
    }

    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    // ジャンプ時の効果音を再生する
    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpSound);
    }

    // ハイジャンプ時の効果音を再生する
    public void PlayHighJumpSound()
    {
        audioSource.PlayOneShot(highJumpSound);
    }

    // スーパージャンプ時の効果音を再生する
    public void PlaySuperJumpSound()
    {
        StartCoroutine(PauseAudioForSeconds(7f));
        audioSource.PlayOneShot(superJumpSound);
    }

    // 落下時の効果音を再生する
    public void PlayFallSound()
    {
        audioSource.PlayOneShot(fallSound);
    }

    IEnumerator PauseAudioForSeconds(float seconds)
    {
        bgm.Pause();
        yield return new WaitForSeconds(seconds);
        bgm.UnPause();
    }
}
