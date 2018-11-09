using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEffect : MonoBehaviour {

    public float spawnEffectTime = 2;
    public float pause = 1;
    public AnimationCurve fadeIn;
    public AnimationCurve fadeOut;
    private bool aux;
    private bool aux2;
    // ParticleSystem ps;
    float timer = 0;
    Renderer _renderer;

    int shaderProperty;

    private PlayerAttack pa;

	void Start ()
    {
        pa = FindObjectOfType<PlayerAttack>();
        shaderProperty = Shader.PropertyToID("_cutoff");
        _renderer = GetComponent<Renderer>();
       // ps = GetComponentInChildren <ParticleSystem>();

        //var main = ps.main;
        //main.duration = spawnEffectTime;

       // ps.Play();

    }
	
	void Update ()
    {

        if (Input.GetKeyDown(KeyCode.F) && pa.isAttacking(0))
        {
            aux = !aux;      
            timer = 0;
            aux2 = true;
        }
        pa.canAttack = !aux;

        if(aux2)
        {
            if (timer < spawnEffectTime + pause)
            {
                timer += Time.deltaTime*1.5f;
            }
            else
            {              
                aux2 = false;
            }

            if (aux)
            {
                _renderer.material.SetFloat(shaderProperty, fadeIn.Evaluate(Mathf.InverseLerp(0, spawnEffectTime, timer)));
            }
            else
            {
                _renderer.material.SetFloat(shaderProperty, fadeOut.Evaluate(Mathf.InverseLerp(0, spawnEffectTime, timer)));
            }
        }
        



    }
}
