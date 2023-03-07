using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    // �X�R�A
    public static int score;

    // �v���C���[��Transform
    public Transform player;
    // �X�R�A�̃e�L�X�g
    public TextMeshProUGUI scoreText;
    // ���C���J����
    public Transform mainCamera;

    // �J�n�ʒu
    private float playerStartPositionY;

    void Start()
    {
        // �t���[�����[�g��60�ɐݒ�
        Application.targetFrameRate = 60;
        // �v���C���[�̊J�n�������擾
        playerStartPositionY = player.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        WrapObject();

        UpdateScore();
    }

    private void WrapObject()
    {
        // �v���C���[�����C���J�����͈̔͊O�i���j�ɍs�����ꍇ
        if (player.position.y < mainCamera.position.y - 5.5)
        {
            // �n�C�X�R�A���X�V����
            UpdateHighScore();

            // ���U���g��ʂɑJ��
            SceneManager.LoadScene("ResultScene");
        }
    }

    private void UpdateScore()
    {
        // �v���C���[���J�n�ʒu�𒴂���܂ł͉������Ȃ�
        if (player.position.y < playerStartPositionY) return;

        // �X�R�A���擾
        int currentScore = ((int)((player.position.y - playerStartPositionY) * 50));

        // �X�R�A���X�V���ꂽ�ꍇ
        if (currentScore > score)
        {
            // �X�R�A���X�V����
            score = currentScore;
            scoreText.text = $"Score: {currentScore}";
        }
    }

    // �n�C�X�R�A���X�V����
    private void UpdateHighScore()
    {
        // �n�C�X�R�A���擾����
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        //  �X�R�A���n�C�X�R�A��荂����΃n�C�X�R�A���X�V����
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }
}
