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

    public void ReiniciarPartida()
    {
        Time.timeScale = 1f; // Despausa o jogo
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recarrega a cena atual
    }

    public void VoltarAoMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu"); // Nome da cena que a Sthephany vai criar
    }

    public void IniciarJogo()
{
    Time.timeScale = 1f;
    SceneManager.LoadScene("SampleScene"); 
}
}