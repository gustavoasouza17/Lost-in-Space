using UnityEngine;

public class PlanetaMovimento : MonoBehaviour
{
    public float velocidade = 2f; // Velocidade com que o planeta desce
    public float limiteInferior = -10f; // Ponto onde o planeta é destruído

    void Update()
    {
        transform.Translate(Vector3.down * velocidade * Time.deltaTime);

            if (transform.position.y < limiteInferior)
        {
            Destroy(gameObject);
        }
    }
}