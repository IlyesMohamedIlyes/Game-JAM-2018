using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PanelState
{
    MenuPanel,
    StoryPanel,
    OnPlayPanel,
    PausePanel,
    GameOverPanel
}

public class UIManager : MonoBehaviour
{
    private bool _soundOn = true;
    private Image _soundImage;
    private int _currentIndexRaw = 0;


    public GameObject _alwaysOnDisplayPanel;
    public GameObject _menuPanel;
    public GameObject _storyPanel;
    public GameObject _onPlayPanel;
    public GameObject _pausePanel;
    public GameObject _gameoverPanel;

    public Sprite _spriteSoundOn;
    public Sprite _spriteSoundOff;

    public RawImage _rawDisplayed;
    public Texture[] rawCharacters;
    
    public Text _memoriesCatch;
    
    public PanelState State { get; set; }

    public static UIManager Instance
    {
        get; private set;
    }


    public int NumberPowerUpsLevel { get; set; }
    

    private void Awake()
    {
        Instance = this;
        State = PanelState.MenuPanel;
    }

    private void Start()
    {
        // Index of the image sound is the last one
        int v = _alwaysOnDisplayPanel.transform.childCount;
        _soundImage = _alwaysOnDisplayPanel.transform.GetChild(v-1).GetComponent<Image>();

        SwitchStatePanel(PanelState.MenuPanel);
    }

    public void UpdateMemoryCatch(int number)
    {
        _memoriesCatch.text = string.Format("Memory {0}/{1}", number, NumberPowerUpsLevel);
    }

    public void SwitchStatePanel(PanelState state)
    {
        switch (state)
        {
            case PanelState.MenuPanel:

                _menuPanel.SetActive(true);
                _storyPanel.SetActive(false);
                _onPlayPanel.SetActive(false);
                _gameoverPanel.SetActive(false);

                break;

            case PanelState.StoryPanel:

                _menuPanel.SetActive(false);
                _storyPanel.SetActive(true);
                _onPlayPanel.SetActive(false);
                _gameoverPanel.SetActive(false);

                break;

            case PanelState.OnPlayPanel:
                Debug.Log("OnPlay active");
                _menuPanel.SetActive(false);
                _storyPanel.SetActive(false);
                _onPlayPanel.SetActive(true);
                _gameoverPanel.SetActive(false);

                NumberPowerUpsLevel = 10;
                _memoriesCatch.text = string.Format("Memory {0}/{1}", 0, NumberPowerUpsLevel);



                break;

            case PanelState.PausePanel:

                _menuPanel.SetActive(false);
                _storyPanel.SetActive(false);
                _onPlayPanel.SetActive(false);
                _pausePanel.SetActive(true);
                _gameoverPanel.SetActive(false);

                break;

            case PanelState.GameOverPanel:

                _menuPanel.SetActive(false);
                _storyPanel.SetActive(false);
                _onPlayPanel.SetActive(false);
                _gameoverPanel.SetActive(true);

                break;
        }
    }

    public void SoundControl()
    {
        _soundOn = !_soundOn;

        // On/Off sound here

        // Change sprite sound here
        Sprite sprite = _soundOn ? _spriteSoundOn:_spriteSoundOff;
        _soundImage.sprite = sprite;

    }

    public void SwitchButtonToPanels(int index)
    {
        // This is called from onClick Buttons, 
        // 1 for Menu
        // 2 for Story
        // 3 for OnPlay
        // 4 for Gameover
        
        switch (index)
        {
            case 1:
                SwitchStatePanel(PanelState.MenuPanel);
                break;
            case 2:
                SwitchStatePanel(PanelState.StoryPanel);
                break;
            case 3:
                SwitchStatePanel(PanelState.OnPlayPanel);
                break;
            case 4:
                SwitchStatePanel(PanelState.GameOverPanel);
                break;
        }
    }

    public void Quit()
    {
        Debug.Log("Quit the Application.");
        Application.Quit();
    }

    public void ChooseCharacter()
    {
        if(++_currentIndexRaw >= rawCharacters.Length)
        {
            _currentIndexRaw = 0;
        }
        
        _rawDisplayed.texture = rawCharacters[_currentIndexRaw];
    }
}
