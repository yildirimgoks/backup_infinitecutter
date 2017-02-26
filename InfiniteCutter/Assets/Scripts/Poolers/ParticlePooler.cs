using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePooler : MonoBehaviour {
    public static ParticlePooler current;
    public ParticleSystem pooledParticle;
    public int pooledAmount = 5;

    List<ParticleSystem> pooledParticles;

    // Use this for initialization

    private void Awake() {
        current = this;
    }

    void Start () {
        pooledParticles = new List<ParticleSystem>();
        for (int i = 0; i < pooledAmount; i++) {
            ParticleSystem obj = Instantiate(pooledParticle) as ParticleSystem;
            obj.Stop();
            pooledParticles.Add(obj);
        }
	}

    public ParticleSystem GetPooledParticle() {
        for (int i = 0; i < pooledParticles.Count; i++) {
            if (!pooledParticles[i].isPlaying) {
                return pooledParticles[i];
            }
        }
        return null;
    }

    public void DestroyParticle(ParticleSystem ps) {
        ps.Stop();
    }
	
	
}
