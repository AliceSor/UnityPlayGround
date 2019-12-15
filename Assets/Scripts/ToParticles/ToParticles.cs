using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
[RequireComponent(typeof(MeshRenderer))]
public class ToParticles : MonoBehaviour
{
    public float speed = 0.1f;
    public Vector2 minmaxSize = new Vector2(0, 0.4f);

    private ParticleSystem _particleSystem;
    private MeshRenderer _meshRenderer;
    private MeshFilter _meshFilter;
    private ParticleSystem.Particle[] _particles;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshFilter = GetComponent<MeshFilter>();
        _particleSystem = GetComponent<ParticleSystem>();
        _particleSystem.Pause();
    }

    public void Disintigrate()
    {
        // _particleSystem.GetParticles(_particles);
        int count = _meshFilter.mesh.vertexCount;
        Vector3[] p = _meshFilter.mesh.vertices;
        _particleSystem.Emit(1);
        ParticleSystem.Particle particle;
        _particles = new ParticleSystem.Particle[count];
        if (_particleSystem.particleCount > 0)
        {
            _particleSystem.GetParticles(_particles);
            particle = _particles[0];
            Debug.Log(particle.ToString());
        }
        else
        {
            particle = new ParticleSystem.Particle();
            particle.size = 1f;
            
        }
        //particle = new ParticleSystem.Particle();
        //particle.size = 0.1f;
        //particle.startLifetime = 5;
        //particle.color = Color.black;
        _particles = new ParticleSystem.Particle[count];

        for (int i = 0; i < count; i++)
        {
            _particles[i] = particle;
            _particles[i].position = p[i];
            _particles[i].velocity = _meshFilter.mesh.normals[i] * speed;
            _particles[i].startSize = Random.Range(minmaxSize.x, minmaxSize.y);
        }
        _particleSystem.Play();
        _meshRenderer.enabled = false;
        _particleSystem.SetParticles(_particles, count);
    }
}
