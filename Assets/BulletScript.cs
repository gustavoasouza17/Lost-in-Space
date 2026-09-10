using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifetime = 3f;

    void Start()
    {
        // Destrói o tiro após "lifetime" segundos para não pesar o jogo
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Move o tiro para cima constantemente
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}