using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public class VisaoNoturna : MonoBehaviour
{
    [Header("Ativação")]
    [SerializeField] private KeyCode toggleNightVisionKey = KeyCode.R;

    [Header("Pós-processamento")]
    [SerializeField] private Volume nightVisionVolume;

    [Header("Animaçao de piscar")]
    [SerializeField] private GameObject recordingIcon;
    [SerializeField] private GameObject textRec;

    [Header("Referências")]
    [SerializeField] private BatterySystem batterySystem;

    [Header("Tempo para piscar")]
    [SerializeField] private float blinkInterval = 0.5f;

    private float blinkTimer = 0f;
    private bool nightVisionOn = false;

    void Start()
    {
        if (nightVisionVolume != null)
            nightVisionVolume.enabled = false;

        if (recordingIcon != null)
            recordingIcon.SetActive(false);

        if (textRec != null)
            textRec.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(toggleNightVisionKey) && batterySystem.HasBattery())
        {
            ToggleNightVision();
        }

        if (nightVisionOn)
        {
            batterySystem.DrainBattery();

            if (!batterySystem.HasBattery())
            {
                DisableNightVision();
            }
            else
            {
                BlinkRec();
            }
        }
    }

    void ToggleNightVision()
    {
        nightVisionOn = !nightVisionOn;

        if (nightVisionVolume != null)
            nightVisionVolume.enabled = nightVisionOn;

        if (recordingIcon != null)
            recordingIcon.SetActive(nightVisionOn);

        if (textRec != null)
            textRec.SetActive(nightVisionOn);
    }

    void DisableNightVision()
    {
        nightVisionOn = false;

        if (nightVisionVolume != null)
            nightVisionVolume.enabled = false;

        if (recordingIcon != null)
            recordingIcon.SetActive(false);

        if (textRec != null)
            textRec.SetActive(false);
    }

    void BlinkRec()
    {
        blinkTimer += Time.deltaTime;
        if (blinkTimer >= blinkInterval)
        {
            bool state = !recordingIcon.activeSelf;
            recordingIcon.SetActive(state);
            textRec.SetActive(state);
            blinkTimer = 0f;
        }
    }
      public bool EstaComVisaoNoturna()
  {
    return nightVisionOn;
  }
    public void RecarregarBateria(float valor)
   {
    if (batterySystem != null)
        batterySystem.Recharge(valor);
   }
}
