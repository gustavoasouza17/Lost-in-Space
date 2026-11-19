using UnityEngine;
using UnityEngine.UI;

public class SeletorDeNaveMenu : MonoBehaviour
{
    [Header("Visual na Tela do Menu")]
    [SerializeField] private Image imagemNavePreview; // O objeto Image da nave no Canvas do Menu
    [SerializeField] private Sprite[] spritesDasNaves; // Arraste aqui os 3 Sprites das naves

    private int indiceAtual = 0;
    private const string CHAVE_NAVE = "NaveSelecionada";

    void Start()
    {
        // Carrega a última nave salva (ou 0 se for a primeira vez)
        indiceAtual = PlayerPrefs.GetInt(CHAVE_NAVE, 0);
        indiceAtual = Mathf.Clamp(indiceAtual, 0, spritesDasNaves.Length - 1);
        AtualizarVisual();
    }

    public void ProximaNave()
    {
        if (spritesDasNaves.Length == 0) return;
        indiceAtual = (indiceAtual + 1) % spritesDasNaves.Length;
        SalvarEAtualizar();
    }

    public void NaveAnterior()
    {
        if (spritesDasNaves.Length == 0) return;
        indiceAtual = (indiceAtual - 1 + spritesDasNaves.Length) % spritesDasNaves.Length;
        SalvarEAtualizar();
    }

    private void SalvarEAtualizar()
    {
        PlayerPrefs.SetInt(CHAVE_NAVE, indiceAtual);
        PlayerPrefs.Save();
        AtualizarVisual();
    }

    private void AtualizarVisual()
    {
        if (imagemNavePreview != null && spritesDasNaves.Length > 0)
        {
            imagemNavePreview.sprite = spritesDasNaves[indiceAtual];
        }
    }
}