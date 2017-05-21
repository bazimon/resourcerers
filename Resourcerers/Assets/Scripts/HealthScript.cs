using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {

    public float health;

    private float timer;
    private SpriteRenderer spriteRenderer;
    private Material defaultMaterial;
    private Material whiteMaterial;

    private void TimerCountdown()
    {
        timer = Mathf.Max(0f, timer - Time.deltaTime);
        if (timer == 0)
        {
            spriteRenderer.material = defaultMaterial;
        }
    }

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultMaterial = spriteRenderer.material;
        whiteMaterial = new Material(Shader.Find("GUI/Text Shader"));
    }

    void Update() {
        TimerCountdown();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            Destroy(gameObject);
        }
        else
        {
            spriteRenderer.material = whiteMaterial;
            timer = 0.1f;
        }
    }
}

    
