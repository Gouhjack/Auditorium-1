using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBoxManager : MonoBehaviour
{
    #region Exposed
    [SerializeField] float _volumeUpPerParticle;
    [SerializeField] float _volumeDecayPerSecond;
    [SerializeField] float _volumeDecayDelay;
    [SerializeField] SpriteRenderer[] _volumeBars;
    [SerializeField] Color _enabledColor;
    [SerializeField] Color _disabledColor;
    private GameManager _gameManager; 
    #endregion

    #region Unity LifeCycle

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        


    }
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad > startDecayTime) 
        { 
            _volume -= _volumeDecayPerSecond * Time.deltaTime;
            _volume = Mathf.Clamp01(_volume);
            
        }
        _audio.volume = _volume;

        UpdateRenderer();
    }
    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _volume += _volumeUpPerParticle;
        // _volume = Mathf.Min(_volume + _volumeUpPerParticle, 1); celle ci est celle d'en dessous font la même chose
        _volume = Mathf.Clamp01(_volume);

        startDecayTime = Time.timeSinceLevelLoad + _volumeDecayDelay;

        
    }
    #endregion

    #region Methods
    void UpdateRenderer()
    {
        int numberBarsToEnabled = Mathf.FloorToInt(_volumeBars.Length * _volume);

        for (int i = 0; i < _volumeBars.Length; i++)
        {
            if (i < numberBarsToEnabled)
            {
                _volumeBars[i].color = _enabledColor;
            }
            else
            {
                _volumeBars[i].color = _disabledColor;
            }
        }
      
    }
    #endregion

    #region Private & Protected
    private float _volume;
    private float startDecayTime;
    private AudioSource _audio;
    #endregion
}
