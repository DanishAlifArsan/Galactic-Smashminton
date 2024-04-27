using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private Image[] characterSelectImage;
    [SerializeField] private Button[] characterButtonList;
    [SerializeField] private Sprite[] characterSpriteList;

    private void Awake() {
        LoadGame();
    }

    private void LoadGame() {
        int defeatedEnemies;

        SaveModel saveData = SaveSystem.LoadGame();
        if (saveData == null)
        {
            defeatedEnemies = 0;
            SaveSystem.SaveGame(0);
        } else {
            defeatedEnemies = saveData.defeatedEnemies;
        }

        for (int i = 0; i <= defeatedEnemies; i++)
        {
            characterSelectImage[i].sprite = characterSpriteList[i];
            characterButtonList[i].enabled = true;
        }
    }
}
