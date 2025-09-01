using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] CoverPopup coverPopup;
    [SerializeField] SettingsPopup settingsPopup;
    [SerializeField] CreditsPopup creditsPopup;
    //[SerializeField] SettingsPopup settingsHomePopup;
    [SerializeField] CreditsPopup creditsHomePopup;
    [SerializeField] Image whiteTransparentBackground;
    [SerializeField] Image homeWhiteTransparentBackground;
    [SerializeField] AudioSource backgroundMusic;
    [SerializeField] AudioSource openingSounds;

#if UNITY_WEBGL
        public static string webPlayerQuitURL = "http://google.com";
#endif

    void Start()
    {
        settingsPopup.ClosePopup();
        creditsPopup.CloseCredits();
        //settingsHomePopup.ClosePopup();
        creditsHomePopup.CloseCredits();
        whiteTransparentBackground.enabled = false;
        homeWhiteTransparentBackground.enabled = false;
        OnPauseGame(true);
    }

    public void OnStartGame() //Cover
    {
        coverPopup.CloseCover();
        //settingsHomePopup.ClosePopup();
        OnPauseGame(false);
        homeWhiteTransparentBackground.enabled = false;
        backgroundMusic.Play();
        openingSounds.Pause();
    }

    public void OnSettings() //Cover
    {
        //settingsHomePopup.OpenPopup();
        homeWhiteTransparentBackground.enabled = true;
    }

    public void OnHome() //Cover
    {
        //settingsHomePopup.ClosePopup();
        creditsHomePopup.CloseCredits();
        coverPopup.OpenCover();
        whiteTransparentBackground.enabled = false;
        homeWhiteTransparentBackground.enabled = false;
    }

    public void OnCredits() //Cover
    {
        creditsHomePopup.OpenCredits();
        homeWhiteTransparentBackground.enabled = true;
        whiteTransparentBackground.enabled = false;
        Time.timeScale = 0f;
    }

    public void OnPauseGame(bool pause) //Freeze player mvmt
    {
        if (pause)
        {
            Time.timeScale = 0f;
            whiteTransparentBackground.enabled = true;
        }
        else
        {
            Time.timeScale = 1f;
            whiteTransparentBackground.enabled = false;
        }
    }

    public void OnResumeGame() //Settings
    {
        settingsPopup.ClosePopup();
        OnPauseGame(false);
    }

    public void OnButtonRestart() //Settings
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        coverPopup.CloseCover();
    }

    public void OnExitGame() //Settings
    {
        StartCoroutine(Exit());
    }

    IEnumerator Exit()
    {
        yield return new WaitForSeconds(0f);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBGL
        Application.OpenURL(webPlayerQuitURL);
#else
        Application.Quit();
#endif
    }

    public void OnButtonCredit() //Settings
    {
        creditsPopup.OpenCredits();
        whiteTransparentBackground.enabled = true;
    }

    public void OnButtonSettings() //Credit
    {
        creditsPopup.CloseCredits();
        settingsPopup.OpenPopup();
        whiteTransparentBackground.enabled = true;
    }
}