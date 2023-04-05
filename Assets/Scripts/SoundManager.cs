using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    // AudioSource
    public AudioSource audioSource;
    // GameBGM
    public AudioSource gameBgm;
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
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    // BGMを止める
    public void StopBgm()
    {
        audioSource.Stop();
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
        gameBgm.Pause();
        yield return new WaitForSeconds(seconds);
        gameBgm.UnPause();
    }
}
