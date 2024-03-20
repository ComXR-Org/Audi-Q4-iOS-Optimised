using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageSetting : MonoBehaviour
{
    public bool chinese;
    public GameObject[] Texts;

    private void Start() {
        //chinese = false;
        SwitchLang(chinese);
    }

    public void SwitchLang(bool chinese) {
        if (chinese) {
            foreach (GameObject c in Texts) {
                c.transform.GetChild(0).gameObject.SetActive(false);
                c.transform.GetChild(1).gameObject.SetActive(true);

            }
        } else {

            foreach (GameObject c in Texts) {
                c.transform.GetChild(0).gameObject.SetActive(true);
                c.transform.GetChild(1).gameObject.SetActive(false);
            }
        }
    }

    public void SwitchToggle() {
        if (chinese) {
            chinese = false;
            SwitchLang(chinese);
        } else {
            chinese = true;
            SwitchLang(chinese);
        }
    }
}
