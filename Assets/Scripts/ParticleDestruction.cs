using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ParticleDestruction : MonoBehaviour
{
    #region Exposed

    [SerializeField] private float _minimumSpeed;
    #endregion

    #region Unity LifeCycle

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (_rigidbody.velocity.magnitude < _minimumSpeed) 
        {
            gameObject.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        
    }
    #endregion

    #region Methods

    #endregion

    #region Private & Protected
    private Rigidbody2D _rigidbody;
    #endregion
}
