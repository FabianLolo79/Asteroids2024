using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Sprite[] sprites; //matriz de sprites
    public float size = 1.0f; 
    public float minSize = 0.05f;
    public float maxSize = 0.5f;
    public float speed = 8.0f;
    public float maxLifeTime = 30.0f;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)]; //asteroide aleatorio

        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f); //giro aleatorio

        this.transform.localScale = Vector3.one * this.size; //tamaño aleatorio

        _rigidbody.mass = this.size; //masa aleatoria deacuerdo a su tamaño?
    }

    public void SetTrayectory(Vector2 direction)
    {
        _rigidbody.AddForce(direction * this.speed);
        Destroy(this.gameObject, this.maxLifeTime);
    }
}
