using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Documento : MonoBehaviour
{
    [Header("Painel do Documento")]
    [SerializeField] private GameObject painelDialogo;

    [Header("Texto do Documento")]
    [SerializeField] private TMP_Text textoDialogo;

    [Header("O que vai estar escrito")]
    [TextArea]
    [SerializeField] private string escritaDocumento;

    [Header("Pegando o Player")]
    [SerializeField] private GameObject jogador;

    [Header("Pos-Pocessamento")]
    [SerializeField] Volume escurecer;

    [Header("WinCon")]
    int pageNum;

    
    

   
    private FirstPersonController player;
    private bool jogadorPerto = false;
     private bool documentoColetado = false;

    void Start()
    {
        player = jogador.GetComponent<FirstPersonController>();
        if (escurecer!= null)
            escurecer.enabled = false;

    }

    void Update()
    {
       if (pageNum == 4)
        {
            SceneManager.LoadScene("End");
        }
       if (jogadorPerto && Input.GetButtonDown("Fire1") && !painelDialogo.activeSelf)
       { 


            AbrirDocumento();
            if(escurecer != null)
                escurecer.enabled = true;
            Time.timeScale = 0f;
       }
        
        else if (painelDialogo.activeSelf && Input.GetButtonDown("Fire2"))
        {
            FecharDocumento();
            if (escurecer != null)
                escurecer.enabled = false;
            Time.timeScale = 1f;
           
          
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = false;
        }
    }

    private void AbrirDocumento()
    {
        painelDialogo.SetActive(true);
        textoDialogo.gameObject.SetActive(true);
        textoDialogo.text = escritaDocumento;
    }

    private void FecharDocumento()
    {
        painelDialogo.SetActive(false);
        textoDialogo.gameObject.SetActive(false);
        pageNum += 1;
        Destroy(gameObject);
    }
}



