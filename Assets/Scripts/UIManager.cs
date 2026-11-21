using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Painéis de Fim de Jogo")]
    [SerializeField] private GameObject painelGameOver;
    [SerializeField] private GameObject painelRecorde;

    [Header("Textos")]
    [SerializeField] private TextMeshProUGUI textoValorRecorde;

    [Header("Áudio")]
    [SerializeField] private AudioSource musicaFundo;   // AudioSource da trilha sonora (ex: no Canvas ou Main Camera)
    [SerializeField] private AudioSource audioSourceUI; // AudioSource dedicado aos sons da UI / fim de jogo
    [SerializeField] private AudioClip somGameOver;     // Som de Game Over normal
    [SerializeField] private AudioClip somRecorde;      // Música ou som especial ao bater o tempo recorde

    private bool somFimDeJogoTocado = false;

    private void PararMusicaFundo()
    {
        if (musicaFundo != null && musicaFundo.isPlaying)
        {
            musicaFundo.Stop();
        }
    }

    private void TocarClipeUI(AudioClip clipe)
    {
        if (!somFimDeJogoTocado && clipe != null)
        {
            if (audioSourceUI != null)
            {
                audioSourceUI.Stop();
                audioSourceUI.clip = clipe;
                audioSourceUI.Play();
            }
            else
            {
                AudioSource.PlayClipAtPoint(clipe, Camera.main != null ? Camera.main.transform.position : Vector3.zero);
            }
            somFimDeJogoTocado = true;
        }
    }

    public void AtivarGameOver()
    {
        if (painelGameOver != null) painelGameOver.SetActive(true);
        Time.timeScale = 0f;
        PararMusicaFundo();
        TocarClipeUI(somGameOver);
    }

    public void ReiniciarPartida()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
        Time.timeScale = 0f;
        PararMusicaFundo();

        float recordeAntigo = PlayerPrefs.GetFloat("TempoRecorde", 0);

        if (tempoDaPartida > recordeAntigo)
        {
            PlayerPrefs.SetFloat("TempoRecorde", tempoDaPartida);
            PlayerPrefs.Save();

            if (painelRecorde != null)
            {
                painelRecorde.SetActive(true);
                if (textoValorRecorde != null)
                {
                    textoValorRecorde.text = Mathf.Floor(tempoDaPartida) + "s";
                }
            }
            if (painelGameOver != null) painelGameOver.SetActive(false);

            // Toca a música/som de recorde (se não houver somRecorde, cai no somGameOver)
            TocarClipeUI(somRecorde != null ? somRecorde : somGameOver);
        }
        else
        {
            if (painelGameOver != null) painelGameOver.SetActive(true);
            if (painelRecorde != null) painelRecorde.SetActive(false);

            TocarClipeUI(somGameOver);
        }
    }
}