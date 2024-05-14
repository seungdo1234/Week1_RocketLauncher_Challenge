using UnityEngine;
using UnityEngine.UI;

public class EnergyDashboard : MonoBehaviour
{
    [SerializeField] private EnergySystem energySystem;
    [SerializeField] private Image fillBar;
    private void Start()
    {
        // TODO : energySystem에서 값이 바뀌면 fillBar.fillAmount가 바뀌도록 변경
        energySystem.OnEnergyChanged += ModifyEnergyDashboard;
    }

    private void ModifyEnergyDashboard(float fuel)
    {
        fillBar.fillAmount = fuel / energySystem.MaxFuel;
    }

}