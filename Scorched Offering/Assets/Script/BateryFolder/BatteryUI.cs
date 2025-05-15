using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BatteryUI : BateryManeger
{

    [Header("Referência")]
    [SerializeField] private Image batteryImage;
    [SerializeField] private TextMeshProUGUI batteryText;

    [Header("Fonte")]
    [SerializeField] private BatterySystem batterySystem;

    void Update()
    {
        if (batterySystem == null) return;

        float percent = batterySystem.BatteryPercent * 100f;

        if (batteryImage != null)
            batteryImage.fillAmount = batterySystem.BatteryPercent;

        if (batteryText != null)
        {
            batteryText.text = Mathf.RoundToInt(percent) + "%";

            if (percent > 50f)
                batteryText.color = Color.green;
            else if (percent > 20f)
                batteryText.color = Color.yellow;
            else
                batteryText.color = Color.red;
        }
    }
}