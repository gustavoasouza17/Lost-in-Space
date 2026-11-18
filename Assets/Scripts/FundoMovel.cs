using UnityEngine;

public class FundoMovel : MonoBehaviour
{
    [SerializeField] private float velocidade = 2f;
    [SerializeField] private float limiteInferior = -15f; // Onde o fundo "some" embaixo
    [SerializeField] private float posicaoReinio = 15f;   // Onde ele reaparece em cima

    void Update()
    {
        // Move o fundo para baixo continuamente
        transform.Translate(Vector3.down * velocidade * Time.deltaTime);

        // Se o fundo passou do limite inferior, reposiciona-o lá em cima para criar o loop infinito
        if (transform.position.y <= limiteInferior)
        {
            transform.position = new Vector3(transform.position.x, posicaoReinio, transform.position.z);
        }
    }
}