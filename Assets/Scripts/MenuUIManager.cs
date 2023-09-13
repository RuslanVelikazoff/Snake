using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour
{
    public Button level;

    public Button soundButton;
    public Sprite onSoundSprite;
    public Sprite offSoundSprite;

    public Button musicButton;
    public Sprite onMusicSprite;
    public Sprite offMusicSprite;

    public Text highScoreText;

    private void Start()
    {
        SetMusicSprite();
        SetSoundSprite();

        highScoreText.text = "High score: " + PlayerPrefs.GetInt("HighScore");

        ButtonFunc();
    }

    private void ButtonFunc()
    {
        if (level != null)
        {
            level.onClick.RemoveAllListeners();
            level.onClick.AddListener(() =>
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(1);
            });
        }

        if (musicButton != null)
        {
            musicButton.onClick.RemoveAllListeners();
            musicButton.onClick.AddListener(() =>
            {
                if (PlayerPrefs.GetFloat("MusicVolume") == 0)
                {
                    AudioManager.instance.OnMusic();
                    SetMusicSprite();
                }
                else
                {
                    AudioManager.instance.OffMusic();
                    SetMusicSprite();
                }
            });
        }

        if (soundButton != null)
        {
            soundButton.onClick.RemoveAllListeners();
            soundButton.onClick.AddListener(() =>
            {
                if (PlayerPrefs.GetFloat("SoundVolume") == 0)
                {
                    AudioManager.instance.OnSound();
                    SetSoundSprite();
                }
                else
                {
                    AudioManager.instance.OffSound();
                    SetSoundSprite();
                }
            });
        }
    }

    private void SetMusicSprite()
    {
        if (PlayerPrefs.GetFloat("MusicVolume") == 0)
        {
            musicButton.GetComponent<Image>().sprite = offMusicSprite;
            musicButton.GetComponent<Image>().color = Color.red;
        }
        else
        {
            musicButton.GetComponent<Image>().sprite = onMusicSprite;
            musicButton.GetComponent<Image>().color = Color.green;
        }
    }

    private void SetSoundSprite()
    {
        if (PlayerPrefs.GetFloat("SoundVolume") == 0)
        {
            soundButton.GetComponent<Image>().sprite = offSoundSprite;
            soundButton.GetComponent<Image>().color = Color.red;
        }
        else
        {
            soundButton.GetComponent<Image>().sprite = onSoundSprite;
            soundButton.GetComponent<Image>().color = Color.green;
        }
    }
}
