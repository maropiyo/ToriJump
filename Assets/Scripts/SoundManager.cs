using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    // AudioSource
    public AudioSource audioSource;
    // ジャンプ時の効果音
    public AudioClip jumpSound;
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

    // ジャンプ時の効果音を再生する
    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpSound);
    }

    // スーパージャンプ時の効果音を再生する
    public void PlaySuperJumpSound()
    {
        audioSource.PlayOneShot(superJumpSound);
    }

    // 落下時の効果音を再生する
    public void PlayFallSound()
    {
        audioSource.PlayOneShot(fallSound);
    }
}
