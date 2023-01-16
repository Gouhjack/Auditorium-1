using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    #region Exposed
    [Header("Données des particules")]
    [SerializeField] private ParticlesPool _pool;
    [SerializeField] [Tooltip("Drag de la particule")] float _particleDrag;
    [SerializeField] [Tooltip("Vitesse de la paricule en m/s")] float _particleSpeed;

    [Header("Données de spawn")]
    [SerializeField] [Range(0, 5)]  float _spawnerRadius;
    [SerializeField] float _nextSpawnTime;
    [SerializeField] float _spawnDelay;

    [Header("Valeurs pour dessiner le gizmo")]
    [SerializeField] Color _gizmosColor;
    [SerializeField] bool _drawGizmo;
    
    #endregion

    #region Unity LifeCycle
    void Start()
    {
        
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad > _nextSpawnTime)
        {
            _nextSpawnTime = Time.timeSinceLevelLoad + _spawnDelay;
            // spawn des particules
            GameObject newParticle = SpawnParticle();

            //Launch des particules
            LaunchParticle(newParticle);
            //Debug.Log("Spawn particle");


        }
    }
        private void OnDrawGizmos()
    {
        if (_drawGizmo)
        {
            Gizmos.color = _gizmosColor;
            Gizmos.DrawWireSphere(transform.position, _spawnerRadius);
            Gizmos.DrawRay(transform.position, transform.right * _particleSpeed);
        }
    }
    #endregion

    #region Methods
    
    private GameObject SpawnParticle()
    {
        Vector2 position = Random.insideUnitCircle * _spawnerRadius + (Vector2)transform.position;
        GameObject particle = _pool.GetParticle();
        if (particle != null) 
        {
            particle.GetComponent<TrailRenderer>().Clear();
            particle.SetActive(true);
            particle.transform.position = position;
        }
        return particle;
    }
    
    private void LaunchParticle(GameObject particle)
    {
        if (particle != null)
        {
            Rigidbody2D rigidbody = particle.GetComponent<Rigidbody2D>();
            rigidbody.drag = _particleDrag;
            rigidbody.velocity = transform.right * _particleSpeed;
        }
    }




    #endregion

    #region Private & Protected

    #endregion
}
