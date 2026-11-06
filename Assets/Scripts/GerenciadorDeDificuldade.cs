using UnityEngine;
using TMPro; // Obrigatório para manipular os textos da interface

public class GerenciadorDeDificuldade : MonoBehaviour
{
    [Header("Temporizador (Sistema)")]
    public float tempoDeJogo = 0f;
    public int estagioAtual = 1;

    [Header("Configurações de Progressão")]
    public float tempoPorEstagio = 30f;
    public int estagioMaximo = 5;

    [Header("Referências")]
    public AlienSpawner spawnerDeAliens; 

    [Header("Interface (UI)")]
    public TextMeshProUGUI textoTempo; // Liga ao texto dos segundos na tela
    public TextMeshProUGUI textoEstagio; // Liga ao texto do nível na tela

    void Start()
    {
        // Garante que o texto inicial mostra o estágio 1 corretamente
        if (textoEstagio != null) textoEstagio.text = "Estágio: " + estagioAtual;
    }

    void Update()
    {
        // 1. Temporizador
        tempoDeJogo += Time.deltaTime;

        // 2. Atualiza o texto do relógio no ecrã (arredondando para números inteiros)
        if (textoTempo != null)
        {
            textoTempo.text = "Tempo: " + Mathf.FloorToInt(tempoDeJogo).ToString() + "s";
        }

        // 3. Verifica a progressão
        if (estagioAtual < estagioMaximo && tempoDeJogo >= tempoPorEstagio * estagioAtual)
        {
            AvancarEstagio();
        }
    }

    void AvancarEstagio()
    {
        estagioAtual++;
        
        // Atualiza o texto visual do estágio
        if (textoEstagio != null)
        {
            textoEstagio.text = "Estágio: " + estagioAtual;
        }

        // Aumenta a dificuldade
        if (spawnerDeAliens != null)
        {
            spawnerDeAliens.tempoDeSpawn = Mathf.Max(0.5f, spawnerDeAliens.tempoDeSpawn * 0.85f);
        }
    }
}