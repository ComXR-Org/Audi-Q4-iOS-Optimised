using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AnalyticsAPIManager))]
public class AnalyticsHandler : MonoBehaviour
{
    public CXRConfigManager carPackage, stylingPackage;
    public materialChangeSystem carPaintMCSQ8, carPaintMCSRSQ8;
    public List<string> seatTypes, rimTypes, caliperTypes, 
        upholsteryTypes, inlaysTypes, bootNetTypes, steeringWheelTypes;
    public MCS_MultiSceneManager[] upholsteryMCS;

    [Header("Starting configuration indexes")]
    public int carPackageIndex;
    public int sylingPackageIndex, carPaintIndex, seatIndex, rimIndex, caliperIndex,
        inlaysIndex, bootNetIndex, steeringWheelIndex;

    private int currentSeatIndex;

    AnalyticsAPIManager apiManager;

    // Start is called before the first frame update
    void Start()
    {
        apiManager = GetComponent<AnalyticsAPIManager>();

        Invoke("RecordInitialState", 2f);
    }

    private void RecordInitialState()
    {
        //Record initial state for locked congfig
        LockedCarPackage(carPackageIndex);
        LockedStylingPackage(sylingPackageIndex);
        LockedPaintQ8(carPaintIndex);
        LockedSeat(seatIndex);
        LockedRim(rimIndex);
        LockedCaliper(caliperIndex);
        LockedInlays(inlaysIndex);
        LockedBootNet(bootNetIndex);
        LockedSteeringWheel(steeringWheelIndex);
    }

    #region "Configurations"
    public void CarPackageSelected(int _index)
    {
        apiManager.RegisterCarEvent("CarPackageSelected", carPackage.configs[_index].name);
        LockedCarPackage(_index);
    }

    public void StylingPackageSelected(int _index)
    {
        apiManager.RegisterCarEvent("StylingPackageSelected", stylingPackage.configs[_index].name);
        LockedStylingPackage(_index);
    }

    public void CarPaintSelectedQ8(int _index)
    {
        apiManager.RegisterCarEvent("PaintChange", carPaintMCSQ8.materials[_index].name.Replace("Q8 ", string.Empty));
        LockedPaintQ8(_index);
    }

    public void CarPaintSelectedRSQ8(int _index)
    {
        apiManager.RegisterCarEvent("PaintChange", carPaintMCSRSQ8.materials[_index].name.Replace("RSQ8 ", string.Empty));
        LockedPaintRSQ8(_index);
    }

    public void SeatSelected(int _index)
    {
        apiManager.RegisterCarEvent("SeatChange", seatTypes[_index] + " (" + upholsteryMCS[_index].CurrentMaterialNameForAnalytics() + ")");
        currentSeatIndex = _index;
        LockedSeat(_index);
    }

    public void UpholsterySelected(int _index)
    {
        SeatSelected(currentSeatIndex);
    }

    public void InlaysSelected(int _index)
    {
        apiManager.RegisterCarEvent("InlaysChange", inlaysTypes[_index]);
        LockedInlays(_index);
    }

    public void BootNetSelected(int _index)
    {
        apiManager.RegisterCarEvent("BootNetChange", bootNetTypes[_index]);
        LockedBootNet(_index);
    }

    public void SteeringWheelSelected(int _index)
    {
        apiManager.RegisterCarEvent("SteeringWheelChange", steeringWheelTypes[_index]);
        LockedSteeringWheel(_index);
    }

    public void RimSelected(int _index)
    {
        apiManager.RegisterCarEvent("RimChange", rimTypes[_index]);
        LockedRim(_index);
    }

    public void CaliperPaintSelected(int _index)
    {
        apiManager.RegisterCarEvent("CaliperChange", caliperTypes[_index]);
        LockedCaliper(_index);
    }
    #endregion

    #region "Locked Configurations"
    public void LockedCarPackage(int _index) => LockedData.LockedCarPackage = carPackage.configs[_index].name;
    public void LockedStylingPackage(int _index) => LockedData.LockedStylingPackage = stylingPackage.configs[_index].name;
    public void LockedPaintQ8(int _index) => LockedData.LockedPaint = carPaintMCSQ8.materials[_index].name.Replace("Q8 ", string.Empty);
    public void LockedPaintRSQ8(int _index) => LockedData.LockedPaint = carPaintMCSRSQ8.materials[_index].name.Replace("RSQ8 ", string.Empty);
    public void LockedSeat(int _index) => LockedData.LockedSeat = seatTypes[_index] + " (" + upholsteryMCS[_index].CurrentMaterialNameForAnalytics() + ")";
    public void LockedRim(int _index) => LockedData.LockedRim = rimTypes[_index];
    public void LockedCaliper(int _index) => LockedData.LockedCaliper = caliperTypes[_index];
    public void LockedInlays(int _index) => LockedData.LockedInlays = inlaysTypes[_index];
    public void LockedBootNet(int _index) => LockedData.LockedBootNet = bootNetTypes[_index];
    public void LockedSteeringWheel(int _index) => LockedData.LockedSteeringWheel = steeringWheelTypes[_index];
    #endregion

    #region "Features enabled - Exterior"
    public void CarDoorOpened()
    {
        apiManager.RegisterCarEvent("FeatureSelected", "Car Door");
    }

    public void DriveSelectTriggered()
    {
        apiManager.RegisterCarEvent("FeatureSelected", "Drive Select");
    }

    public void SpoilerOpened()
    {
        apiManager.RegisterCarEvent("FeatureSelected", "Spoiler");
    }

    public void ParkAssistTriggered()
    {
        apiManager.RegisterCarEvent("FeatureSelected", "Park Assist");
    }

    public void BootOpened()
    {
        apiManager.RegisterCarEvent("FeatureSelected", "Boot");
    }

    public void TailLightTriggered()
    {
        apiManager.RegisterCarEvent("FeatureSelected", "Rear Light");
    }

    public void HeadLightTriggered()
    {
        apiManager.RegisterCarEvent("FeatureSelected", "Head Light");
    }

    public void RearIndicatorLightTriggered()
    {
        apiManager.RegisterCarEvent("FeatureSelected", "Rear Indicator Light");
    }

    public void SideIndicatorLightTriggered()
    {
        apiManager.RegisterCarEvent("FeatureSelected", "Side Indicator Light");
    }


    #endregion

    #region "Features enabled - Interior"
    public void MoodLightTriggered()
    {
        apiManager.RegisterCarEvent("FeatureSelected", "Mood Light");
    }

    public void AcTriggered()
    {
        apiManager.RegisterCarEvent("FeatureSelected", "AC System");
    }

    public void SoundSystemTriggered()
    {
        apiManager.RegisterCarEvent("FeatureSelected", "Sound System");
    }

    public void SeatMassagerTriggered()
    {
        apiManager.RegisterCarEvent("FeatureSelected", "Seat Massager");
    }

    public void PhoneBoxOpened()
    {
        apiManager.RegisterCarEvent("FeatureSelected", "Phone Box");
    }

    public void HUDOpened()
    {
        apiManager.RegisterCarEvent("FeatureSelected", "HUD");
    }

    public void MMIScreenTriggered(int _index)
    {
        apiManager.RegisterCarEvent("FeatureSelected", "MMI Screen " + (_index == 0 ? "Top" : "Bottom"));
    }

    public void Triggered360Cam()
    {
        apiManager.RegisterCarEvent("FeatureSelected", "360 Camera");
    }

    public void ConsoleTriggered()
    {
        apiManager.RegisterCarEvent("FeatureSelected", "Virtual Cockpit");
    }

    public void MiniatureViewTriggered()
    {
        apiManager.RegisterCarEvent("FeatureSelected", "Miniature View");
    }
    #endregion
}
