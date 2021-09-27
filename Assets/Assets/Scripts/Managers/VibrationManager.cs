using UnityEngine;
using MoreMountains.NiceVibrations;
public class VibrationManager : MonoBehaviour
{
    #region Singleton
    public static VibrationManager Instance = null;

    private void Awake()
    {
        if(Instance == null)
        Instance = this;
    }
    #endregion

    public void SuccesVibration()
    {
        MMVibrationManager.Haptic(HapticTypes.Success, false, true, this);
    }
    public void HeavyVibration()
    {
        MMVibrationManager.Haptic(HapticTypes.HeavyImpact, false, true, this);
    }
    public void MediumVibration()
    {
        MMVibrationManager.Haptic(HapticTypes.MediumImpact, false, true, this);
    }
    public void LightVibration()
    {
        MMVibrationManager.Haptic(HapticTypes.LightImpact, false, true, this);
    }
}