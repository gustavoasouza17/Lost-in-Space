using UnityEngine;
using UnityEngine.SceneManagement; // Obrigatório para trocar de cenas
using TMPro; // Obrigatório para lidar com textos do TextMeshPro

public class UIManager : MonoBehaviour
{
    [Header("Painéis de Fim de Jogo")]
    [SerializeField] private GameObject painelGameOver; // O Game Over normal
    [SerializeField] private GameObject painelRecorde;  // O painel especial de recorde (arte azul)
    
    [Header("Textos")]
    [SerializeField] private TextMeshProUGUI textoValorRecorde; // Texto onde vai aparecer o valor do recorde

    public void AtivarGameOver()
    {
        if (painelGameOver != null) painelGameOver.SetActive(true);
        Time.timeScale = 0f; // Pausa a queda dos inimigos
    }

    public void ReiniciarPartida()
    {
        Time.timeScale = 1f; // Despausa o jogo
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recarrega a cena atual
    }

    public void VoltarAoMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu"); 
    }

    public void IniciarJogo()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene"); 
    }

    public void FimDeJogo(float tempoDaPartida)
    {
        // Para o tempo do jogo
        Time.timeScale = 0f;

        // Puxa o recorde antigo guardado (padrão 0)
        float recordeAntigo = PlayerPrefs.GetFloat("TempoRecorde", 0);

        if (tempoDaPartida > recordeAntigo)
        {
            // Bateu o recorde! Guarda o novo valor
            PlayerPrefs.SetFloat("TempoRecorde", tempoDaPartida);
            PlayerPrefs.Save();

            // Mostra o painel especial de recorde e esconde o normal
            if (painelRecorde != null)
            {
                painelRecorde.SetActive(true);
                if (textoValorRecorde != null)
                {
                    textoValorRecorde.text = Mathf.Floor(tempoDaPartida) + "s";
                }
            }
            if (painelGameOver != null) painelGameOver.SetActive(false);
        }
        else
        {
            // Não bateu o recorde, mostra o Game Over normal
            if (painelGameOver != null) painelGameOver.SetActive(true);
            if (painelRecorde != null) painelRecorde.SetActive(false);
        }
    }
}