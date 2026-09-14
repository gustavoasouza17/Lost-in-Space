using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Configurações de Disparo")]
    public GameObject tiroPrefab; // O prefab do tiro que você acabou de criar
    public Transform pontoDeDisparo; // O local exato de onde o tiro vai sair

    void Update()
    {
        // Verifica se a barra de espaço foi pressionada
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Atirar();
        }
    }

    void Atirar()
    {
        // Cria o tiro na posição do pontoDeDisparo, com a rotação padrão
        Instantiate(tiroPrefab, pontoDeDisparo.position, Quaternion.identity);
    }
}