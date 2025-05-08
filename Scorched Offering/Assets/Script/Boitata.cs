using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public enum EstadoBoitata
{
    Escondido,
    Observando,
    Perseguindo,
    Pegando
}
public class Boitata : MonoBehaviour
{
    [Header("Referência do Jogador")]
    [SerializeField] private Transform jogador;
    [SerializeField] private Camera cameraJogador;

    [Header("Imagem de Glitch")]
    [SerializeField] private Image imagemGlitch;

    [Header("Configurações de Distância")]
    [SerializeField] private float distanciaVisao = 20f;
    [SerializeField] private float distanciaPerseguicao = 10f;
    [SerializeField] private float distanciaCaptura = 3f;

    [Header("Velocidade e Tempo")]
    [SerializeField] private float velocidade = 2f;
    [SerializeField] private float tempoParaTeleporte = 10f;
    [SerializeField] private float tempoOlharParaTeleportar = 4f;

    [Header("Configuração de Teleporte")]
    [SerializeField] private float distanciaMinimaTeleporte = 5f;
    [SerializeField] private float distanciaMaximaTeleporte = 15f;
   
    [Header("Teleporte auto")]
   [SerializeField] private float intervaloTeleporteAutomatico = 6f;


    [Header("Estado Atual do boitata")]
    [SerializeField] private EstadoBoitata estadoAtual = EstadoBoitata.Escondido;

    private float intensidadeGlitchBase = 0.09f;
    private float tempoOlhando = 0f;
    private float tempoDesdeUltimoTeleporte = 0f;

    private Vector3 cameraOriginalPosition;
    private bool olhando = false;

    private Coroutine rotinaEstado;

    private void Start()
    {
        if (cameraJogador != null)
            cameraOriginalPosition = cameraJogador.transform.localPosition;

        rotinaEstado = StartCoroutine(ControladorDeEstado());
        StartCoroutine(VerificaVisao());
    }

    private IEnumerator VerificaVisao()
    {
        while (true)
        {
            olhando = JogadorEstaOlhando();

            if (olhando)
                tempoOlhando += Time.deltaTime;
            else
                tempoOlhando = Mathf.Max(tempoOlhando - Time.deltaTime * 2f, 0f);

            float intensidadeGlitch = intensidadeGlitchBase + (tempoOlhando / tempoOlharParaTeleportar) * 0.5f;
            intensidadeGlitch = Mathf.Clamp(intensidadeGlitch, intensidadeGlitchBase, 1f);

            if (imagemGlitch != null)
                imagemGlitch.color = new Color(1, 1, 1, olhando ? intensidadeGlitch : 0f);

            if (cameraJogador != null)
            {
                if (olhando)
                {
                    float shakeX = (Mathf.PerlinNoise(Time.time * 20f, 0f) - 0.5f) * intensidadeGlitch;
                    float shakeY = (Mathf.PerlinNoise(0f, Time.time * 20f) - 0.5f) * intensidadeGlitch;
                    cameraJogador.transform.localPosition = cameraOriginalPosition + new Vector3(shakeX, shakeY, 0f);
                }
                else
                {
                    cameraJogador.transform.localPosition = cameraOriginalPosition;
                }
            }

           
            if (tempoOlhando >= tempoOlharParaTeleportar)
            {
                TeleportarAtrasDoJogador();
                tempoOlhando = 0f;
            }

            yield return new WaitForSeconds(0.05f);
        }
    }

    private IEnumerator ControladorDeEstado()
    {
        WaitForSeconds espera = new WaitForSeconds(0.1f);
        float tempoTeleporte = 0f;

        while (true)
        {
            float distancia = Vector3.Distance(transform.position, jogador.position);
            tempoTeleporte += 0.1f;
            tempoDesdeUltimoTeleporte += 0.1f;

            switch (estadoAtual)
            {
                case EstadoBoitata.Escondido:
                case EstadoBoitata.Observando:
                    if (distancia < distanciaVisao)
                        MudarEstado(EstadoBoitata.Observando);
                    else
                        MudarEstado(EstadoBoitata.Escondido);

                   if (tempoDesdeUltimoTeleporte >= intervaloTeleporteAutomatico && !olhando)

                    {
                        TeleportarPertoDoJogador();
                        tempoDesdeUltimoTeleporte = 0f;
                    }

                    if (estadoAtual == EstadoBoitata.Observando && distancia < distanciaPerseguicao)
                        MudarEstado(EstadoBoitata.Perseguindo);

                    break;

                case EstadoBoitata.Perseguindo:
                    PerseguirJogador();

                    if (distancia < distanciaCaptura)
                        MudarEstado(EstadoBoitata.Pegando);
                    else if (distancia >= distanciaVisao)
                        MudarEstado(EstadoBoitata.Escondido);
                    break;

                case EstadoBoitata.Pegando:
                 Cursor.lockState = CursorLockMode.None;
                 Cursor.visible = true;
                   SceneManager.LoadScene("Game Over");
                  
                 break;
            }

            yield return espera;
        }
    }

    private void MudarEstado(EstadoBoitata novoEstado)
    {
        if (estadoAtual == novoEstado) return;
        estadoAtual = novoEstado;
    }

    private void OlharParaJogador()
    {
        Vector3 direcao = (jogador.position - transform.position).normalized;
        Quaternion rotacao = Quaternion.LookRotation(direcao);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotacao, Time.deltaTime * 2f);
    }

    private void PerseguirJogador()
    {
        Vector3 direcao = (jogador.position - transform.position).normalized;
        transform.position += direcao * velocidade * Time.deltaTime;
        OlharParaJogador();
    }

    private void TeleportarPertoDoJogador()
    {
        Vector2 direcaoAleatoria = Random.insideUnitCircle.normalized;
        Vector3 novaPosicao = jogador.position + new Vector3(direcaoAleatoria.x, 0, direcaoAleatoria.y) * Random.Range(distanciaMinimaTeleporte, distanciaMaximaTeleporte);
        transform.position = novaPosicao;
    }

    private void TeleportarAtrasDoJogador()
    {
        Vector3 direcaoAtras = -jogador.forward;
        Vector3 novaPosicao = jogador.position + direcaoAtras * 2f; 
        transform.position = novaPosicao;
    }

    private bool JogadorEstaOlhando()
    {
        Vector3 direcaoParaBoitata = (transform.position - cameraJogador.transform.position).normalized;
        float angulo = Vector3.Angle(cameraJogador.transform.forward, direcaoParaBoitata);

        if (angulo < 45f)
        {
            if (Physics.Raycast(cameraJogador.transform.position, direcaoParaBoitata, out RaycastHit hit, distanciaVisao))
            {
                return hit.transform == transform;
            }
        }
        return false;
    }
}
