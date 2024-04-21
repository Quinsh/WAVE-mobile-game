using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelsLock : MonoBehaviour
{
    public Button[] lvlButtons;
    public Image[] line;
    public Text[] title;
    void Start()
    {
        int SavedInd = PlayerPrefs.GetInt("savedSceneIndex", 1);
        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 1 > SavedInd)
            {
                lvlButtons[i].gameObject.SetActive(false);
            }
        }


        if (SavedInd <= 4)
        {
            title[1].gameObject.SetActive(false);
            for (int i = 0; i < 3; i++)
            {
                line[i].gameObject.SetActive(false);
            }
        }
        if (SavedInd <= 10)
        {
            title[2].gameObject.SetActive(false);
            for (int i = 3; i < 9; i++)
            {
                line[i].gameObject.SetActive(false);
            }
        }
        if (SavedInd <= 15)
        {
            title[3].gameObject.SetActive(false);
            for (int i = 9; i < 14; i++)
            {
                line[i].gameObject.SetActive(false);
            }
        }
        if (SavedInd <= 23)
        {
            title[4].gameObject.SetActive(false);
            for (int i = 14; i < 21; i++)
            {
                line[i].gameObject.SetActive(false);
            }
        }
        if (SavedInd <= 28)
        {
            title[5].gameObject.SetActive(false);
            for (int i = 21; i < 29; i++)
            {
                line[i].gameObject.SetActive(false);
            }
        }

    }

    
    private void Update() // ERASE THIS PART LATER!!!!!!!!!!
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            int SavedInd = PlayerPrefs.GetInt("savedSceneIndex", 1);
            PlayerPrefs.SetInt("savedSceneIndex", SavedInd + 1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            PlayerPrefs.DeleteAll();
        }

    }
}
