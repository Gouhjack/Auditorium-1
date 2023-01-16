using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesPool : MonoBehaviour
{
    #region Exposed

    [SerializeField] GameObject _particlePrefab;
    [SerializeField] int _maxParticles;

    #endregion

    #region Unity LifeCycle

    private void Awake()
    {
        _particles = new GameObject[_maxParticles];
        for (int i = 0; i < _maxParticles; i++) 
        {
            _particles[i] = Instantiate(_particlePrefab, transform);
            _particles[i].SetActive(false);
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        
    }
    #endregion

    #region Methods

    public GameObject GetParticle()
    {
        for (int i = 0; i < _maxParticles; i++)       
        {
            if (!_particles[i].activeInHierarchy)
            {
                return _particles[i];
            }
        }
        return null;

    }

    #endregion

    #region Private & Protected

    private GameObject[] _particles;

    #endregion
}
