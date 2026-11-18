using UnityEngine;

public class FundoInfinito : MonoBehaviour
{
    public float velocidade = 2f;
    private Vector2 offset;
    private Material materialFundo;

    void Start()
    {
        // Obtém o material da imagem de fundo
        materialFundo = GetComponent<Renderer>().material;
    }

    void Update()
    {
        // Desloca a textura do fundo ao longo do tempo no eixo Y
        offset = new Vector2(0, Time.time * velocidade);
        materialFundo.mainTextureOffset = offset;
    }
}