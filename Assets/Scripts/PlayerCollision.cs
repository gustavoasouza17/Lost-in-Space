using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [Header("Áudio da Nave do Jogador")]
    [SerializeField] private AudioClip somDestruicaoPlayer;
    [SerializeField] [Range(0f, 1f)] private float volumeDestruicao = 1f;

    private UIManager uiManager;
    private float tempoPartida = 0f;

    void Start()
    {
        uiManager = FindFirstObjectByType<UIManager>();
    }

    void Update()
    {
        // Conta o tempo enquanto o jogo está rodando
        if (Time.timeScale > 0f)
        {
            tempoPartida += Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Alien"))
        {
            if (somDestruicaoPlayer != null)
            {
                AudioSource.PlayClipAtPoint(somDestruicaoPlayer, transform.position, volumeDestruicao);
            }

            if (uiManager != null)
            {
                // Chama FimDeJogo passando o tempo para salvar e escolher o painel certo
                uiManager.FimDeJogo(tempoPartida);
            }

            Destroy(gameObject);
        }
    }
}