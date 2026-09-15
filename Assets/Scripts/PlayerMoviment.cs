using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float limiteX = 8f; // Valor da borda da tela. Ajustaremos no Unity.

    private Rigidbody2D rb;
    private float moveInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");

        // Trava a posição da nave no eixo X entre a borda esquerda e a borda direita
        Vector3 posicaoAtual = transform.position;
        posicaoAtual.x = Mathf.Clamp(posicaoAtual.x, -limiteX, limiteX);
        transform.position = posicaoAtual;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * speed, 0f);
    }
}