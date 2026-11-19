using UnityEngine;

public class AplicarNaveEscolhida : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRendererPlayer;
    [SerializeField] private Sprite[] spritesDasNaves; // Mesma ordem do Menu (0, 1, 2)

    private const string CHAVE_NAVE = "NaveSelecionada";

    void Start()
    {
        if (spriteRendererPlayer == null)
        {
            spriteRendererPlayer = GetComponent<SpriteRenderer>();
        }

        int indiceEscolhido = PlayerPrefs.GetInt(CHAVE_NAVE, 0);

        if (spritesDasNaves != null && spritesDasNaves.Length > 0 &&
            indiceEscolhido >= 0 && indiceEscolhido < spritesDasNaves.Length)
        {
            spriteRendererPlayer.sprite = spritesDasNaves[indiceEscolhido];
        }
    }
}