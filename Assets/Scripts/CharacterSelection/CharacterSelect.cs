using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    // UI要素の参照
    [SerializeField] private Text characterName;
    [SerializeField] private Image characterImage;
    [SerializeField] private Text characterDescription;
    [SerializeField] private Button[] characterButtons;
    [SerializeField] private Button backButton;
    [SerializeField] private Button confirmButton;

    // 選択されたキャラクターのインデックス
    private int selectedIndex = 0;

    // キャラクター情報のリスト
    [SerializeField] private List<CharacterData> characterDataList;

    private void Start()
    {
        // キャラクター選択ボタンにリスナーを追加
        for (int i = 0; i < characterButtons.Length; i++)
        {
            int index = i;
            characterButtons[i].onClick.AddListener(() => SelectCharacter(index));
        }

        // 戻るボタンと決定ボタンにリスナーを追加
        backButton.onClick.AddListener(BackToTitle);
        confirmButton.onClick.AddListener(ConfirmSelection);

        // 初期キャラクター選択
        SelectCharacter(0);
    }

    // キャラクター選択処理
    private void SelectCharacter(int index)
    {
        // 選択インデックスの更新
        selectedIndex = index;

        // 選択されたキャラクター情報の取得
        CharacterData selectedCharacter = characterDataList[index];

        // UI要素の更新
        characterName.text = selectedCharacter.Name;
        characterImage.sprite = selectedCharacter.Image;
        characterDescription.text = selectedCharacter.Description;

        // 選択されたボタン以外を有効にする
        for (int i = 0; i < characterButtons.Length; i++)
        {
            characterButtons[i].interactable = (i != selectedIndex);
        }
    }

    // タイトル画面に戻る処理
    private void BackToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }

    // キャラクター選択確定処理
    private void ConfirmSelection()
    {
        // 選択されたキャラクターのIDを保存
        PlayerPrefs.SetString("SelectedCharacter", characterDataList[selectedIndex].Id);
        PlayerPrefs.Save();

        // タイトル画面に戻る
        SceneManager.LoadScene("TitleScene");
    }

}
