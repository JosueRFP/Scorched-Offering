using UnityEngine;

public class BatterySystem : MonoBehaviour
{
    [Header("Configuração da Bateria")]
    [SerializeField] private float maxBattery = 100f;
    [SerializeField] private float drainRate = 5f;
    [SerializeField] private float rechargeRate = 10f;
    [SerializeField] private VisaoNoturna visaoNoturna;

    private float currentBattery;

    public float BatteryPercent => currentBattery / maxBattery;

    void Start()
    {
        currentBattery = maxBattery;
    }

    void Update()
    {
        if (!IsDraining())
        {
            RechargeBattery();
        }
    }

    public void DrainBattery()
    {
        currentBattery -= drainRate * Time.deltaTime;
        currentBattery = Mathf.Max(currentBattery, 0f);
    }

    public void RechargeBattery()
    {
        currentBattery += rechargeRate * Time.deltaTime;
        currentBattery = Mathf.Clamp(currentBattery, 0f, maxBattery);
    }

    public bool HasBattery()
    {
        return currentBattery > 0f;
    }

    public void Recharge(float amount)
    {
        currentBattery += amount;
        currentBattery = Mathf.Clamp(currentBattery, 0f, maxBattery);
    }

   private bool IsDraining()
{
    return visaoNoturna != null && visaoNoturna.EstaComVisaoNoturna();
}
   public float GetBattery()
    {
        return currentBattery;
    }
}