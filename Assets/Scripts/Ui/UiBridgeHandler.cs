using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiBridgeHandler : MonoBehaviour
{
     
    public waypoints waypoint;
    public materialChangeSystem paintMcs,interiorMcs,inlayMcs;
    public SingleOptionSelector wheelSelector;
    public videoPlayerMultiple taillight, headlight;
  
    public AudiQEytAnimManager audiQEytAnimManager;
    public genericToggler genericToggler;
    public HudDisplay hud;
    public CarInteriorAmbientLighting CarInteriorAmbientLighting;
    public CameraScale CameraScale;
    // Start is called before the first frame update

    public void SetPaintMat(int paintNumber) { paintMcs.SetMaterial(paintNumber); }
    public void SetInteriorMat(int matNumber) { interiorMcs.SetMaterial(matNumber); }
    public void SetInlayMat(int matNumber) { inlayMcs.SetMaterial(matNumber); }
    public void SelectWheel(int wheelNum) { wheelSelector.Select(wheelNum); }
    public void GoToSeat(Transform seatPostrans) { }
    public void GoToLocation(Transform locTrans) { }
    public void togglethisOnce(Transform t) { genericToggler.ToggleThisOnce(t.gameObject); }

    public void MoodLight() {
        CarInteriorAmbientLighting.MoodLightState();

    }
    public void DollHouse() { }
    public void HUD() {

        hud.huddisplay();
    }
    public void Paint() { }
    public void MiniatureView() {
        CameraScale.ScaleButton();

    }
    public void Reading() {
        
    }
    public void Weather() {
        genericToggler.togglethisonce();
    }
    public void TailLight() {
        taillight.PlayToggle01();
    }
    public void Headlight() {
        headlight.PlayToggle01();
        

    }
    public void SeatA() { waypoint.SeatA(); }
    public void SeatB() { waypoint.SeatB(); }
    public void SeatC() { waypoint.SeatC(); }
    public void SeatD() { waypoint.SeatD(); }
    public void Pump() {
        audiQEytAnimManager.DriveSelect();
    }
    public void Poweroff() {
        Application.Quit();
    }
    public void reset(){
        SceneManager.LoadScene(0);
    }
    public void threedsound() {
        genericToggler.togglethisonce();

    }
    public void Bootspace() {
        audiQEytAnimManager.BootSpace();
            }
    public void parkassisst() {
        genericToggler.togglethisonce();
    }
    public void deriveassisst() {
        genericToggler.togglethisonce();
            }
   public void phonebox() { }
    public void footmassager()
    {
        genericToggler.togglethisonce();
    }
    


}

