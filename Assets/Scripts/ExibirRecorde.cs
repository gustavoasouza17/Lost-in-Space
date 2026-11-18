using UnityEngine;
using TMPro;

public class ExibirRecorde : MonoBehaviour
{
    public TextMeshProUGUI textoRecorde;

    void Start()
    {
        // Puxa o tempo recorde guardado (se não houver, assume 0)
        float tempoRecorde = PlayerPrefs.GetFloat("TempoRecorde", 0);

        if (textoRecorde != null)
        {
            // Formata para mostrar como segundos (ex: "45s")
            textoRecorde.text = Mathf.Floor(tempoRecorde) + "s";
        }
    }
}