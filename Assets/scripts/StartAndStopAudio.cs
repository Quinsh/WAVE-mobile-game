using UnityEngine.SceneManagement;
using UnityEngine;

public class StartAndStopAudio : MonoBehaviour
{
    public AudioManager aud;

    // Start is called before the first frame update
    void Awake()
    {
        aud = FindObjectOfType<AudioManager>();
    }


    void Start()
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        bool TheSceneBeforeWasMM = PlayerPrefs.GetInt("MM", 0) == 1;

        
        if(CurrentSceneIndex == 0) 
        {
            aud.Stop("GeminiBGM");// stop everything hhere, put more later
            aud.Stop("CancerBGM");
            aud.Stop("LeoBGM");
            aud.Stop("LibraBGM");
            aud.Stop("CapricornusBGM");
            aud.Stop("SiriusBGM");
            aud.Stop("AldebaranBGM");
            aud.Stop("PolarisABGM");
            aud.Stop("RigelBGM");

            aud.Play("MainMenuBGM");
        }




        else if(CurrentSceneIndex == 5) //saveandEnd Playmusic
        {

            aud.Play("GeminiBGM");
        }
        else if(CurrentSceneIndex == 11)
        {
            aud.Play("CancerBGM");
        }
        else if (CurrentSceneIndex == 16)
        {
            aud.Play("LeoBGM");
        }
        else if (CurrentSceneIndex == 24)
        {
            aud.Play("LibraBGM");
        }
        else if (CurrentSceneIndex == 29)
        {
            aud.Play("CapricornusBGM");
        }
 



        if (CurrentSceneIndex >= 5 && CurrentSceneIndex <= 10 && TheSceneBeforeWasMM)
        {
            aud.Stop("MainMenuBGM");
            aud.Play("GeminiBGM");
        }
        else if (CurrentSceneIndex >= 11 && CurrentSceneIndex <= 15 && TheSceneBeforeWasMM)
        {
            aud.Stop("MainMenuBGM");
            aud.Play("CancerBGM");
        }
        else if (CurrentSceneIndex >= 16 && CurrentSceneIndex <= 23 && TheSceneBeforeWasMM)
        {
            aud.Stop("MainMenuBGM");
            aud.Play("LeoBGM");
        }
        else if (CurrentSceneIndex >= 24 && CurrentSceneIndex <= 28 && TheSceneBeforeWasMM)
        {
            aud.Stop("MainMenuBGM");
            aud.Play("LibraBGM");
        }
        else if (CurrentSceneIndex >= 29 && CurrentSceneIndex <= 34 && TheSceneBeforeWasMM)
        {
            aud.Stop("MainMenuBGM");
            aud.Play("CapricornusBGM");
        }
        else if (CurrentSceneIndex >= 35 && TheSceneBeforeWasMM)
        {
            aud.Stop("MainMenuBGM");
        }


        if (CurrentSceneIndex == 0) // to see if the scene before was Main Menu, if it was, we have to pause the main menu music and load the new one
        {
            PlayerPrefs.SetInt("MM", 1);
        }
        else
        {
            PlayerPrefs.SetInt("MM", 0);
        }

    }


}
