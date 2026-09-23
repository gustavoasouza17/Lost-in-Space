using UnityEngine;

public class AlienSpawner : MonoBehaviour
{
    [SerializeField] private GameObject alienPrefab; 
    [SerializeField] private float tempoDeSpawn = 2f; // Tempo de surgimento entre cada alien
    [SerializeField] private float limiteX = 8f; // Limite lateral da tela
    [SerializeField] private float alturaDoSpawn = 6f; // ALliens irão nascer no topo da tela

    private float tempoDecorrido;

    void Update()
    {
        tempoDecorrido += Time.deltaTime;

        // Quando o cronômetro atinge o tempo limite, invoca o inimigo
        if (tempoDecorrido >= tempoDeSpawn)
        {
            SpawnAlien();
            tempoDecorrido = 0f; // Zera o cronômetro para o próximo alien
        }
    }

    void SpawnAlien()
    {
        // Sorteia um número entre o lado esquerdo e direito da tela
        float posicaoXAleatoria = Random.Range(-limiteX, limiteX);
        Vector2 posicaoDeSpawn = new Vector2(posicaoXAleatoria, alturaDoSpawn);

        // Cria o prefab na cena exatamente na posição sorteada
        Instantiate(alienPrefab, posicaoDeSpawn, Quaternion.identity);
    }
}