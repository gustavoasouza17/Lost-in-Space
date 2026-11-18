using UnityEngine;
using TMPro; // Se estiver a usar TextMeshPro para mostrar o recorde

public class GerenciadorDeRecorde : MonoBehaviour
{
    public TextMeshProUGUI textoTempoAtual;
    public TextMeshProUGUI textoRecorde;

    void Start()
    {
        // Carrega o recorde guardado anteriormente (se não existir, o padrão é 0)
        float tempoRecorde = PlayerPrefs.GetFloat("TempoRecorde", 0);
        
        if (textoRecorde != null)
        {
            textoRecorde.text = "Recorde: " + Mathf.Floor(tempoRecorde) + "s";
        }
    }

    // Chame esta função assim que o jogador morrer (Game Over)
    public void VerificarNovoRecorde(float tempoDaPartidaAtual)
    {
        float tempoRecordeAntigo = PlayerPrefs.GetFloat("TempoRecorde", 0);

        // Se o tempo atual for maior que o recorde guardado, atualizamos
        if (tempoDaPartidaAtual > tempoRecordeAntigo)
        {
            PlayerPrefs.SetFloat("TempoRecorde", tempoDaPartidaAtual);
            PlayerPrefs.Save(); // Salva permanentemente no dispositivo
            Debug.Log("Novo recorde batido: " + tempoDaPartidaAtual);
        }
    }
}