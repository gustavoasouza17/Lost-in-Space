using UnityEngine;
using UnityEngine.SceneManagement; // Obrigatório para trocar de cenas

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject painelGameOver;

    public void AtivarGameOver()
    {
        painelGameOver.SetActive(true);
        Time.timeScale = 0f; // Pausa a queda dos inimigos
    }

    // Função para o botão "Jogar Novamente"
    public void ReiniciarPartida()
    {
        Time.timeScale = 1f; // Despausa o jogo
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recarrega a cena atual
    }

    // Função para o botão "Menu" (Assumindo que o Menu será a cena 0)
    public void VoltarAoMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu"); // Nome da cena que a Sthephany vai criar
    }
}