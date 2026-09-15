using UnityEngine;

public class AlienBehaviour1 : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float limiteInferior = -6f; // Ajuste esse valor para o fundo da sua tela

    void Update()
    {
        // Faz o alienígena descer constantemente (eixo Y negativo)
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        // Limpeza de memória: destrói o objeto se ele sair pela parte de baixo da câmera
        if (transform.position.y < limiteInferior)
        {
            Destroy(gameObject);
        }
    }
}
