using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using System;
using System.IO;

public class AnalyticsAPIManager : MonoBehaviour
{
    public static string hostingURL = "http://54.208.104.117/Audi/Services.php?Service=";

    public static bool isCarOpened = false;

    private List<CarEvent> carEventList;
    private List<LockedConfig> lockedConfigList;
    private string carId;
    // Start is called before the first frame update
    void Start()
    {
        carId = "2";
        //RegisterUserInfo();
        if (!isCarOpened)
        {
            RegisterCarEvent("CarOpened", "Yes");
            isCarOpened = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator registerCarEvent(string carEventName, string carEventParameter)
    {
        WWWForm form = new WWWForm();
        form.AddField("date_time", System.DateTime.Now.Year +"-"+ System.DateTime.Now.Month + "-" + System.DateTime.Now.Day + " " + System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute + ":" + System.DateTime.Now.Second);  //year-month-date hour:minute:second
        form.AddField("user_id", PlayerPrefs.GetString("user_id"));
        form.AddField("car_id", carId);
        form.AddField("event_name", carEventName);
        form.AddField("parameter", carEventParameter);

        UnityWebRequest w = UnityWebRequest.Post(hostingURL + "registerCarEvent", form);
        yield return w.SendWebRequest();
        if (w.error == null)
        {
            //Debug.Log("Record inserted.");
            string itemData = w.downloadHandler.text;
            var ResponseData = JSON.Parse(itemData);
            Debug.Log("<color=blue>Car Event Response" + ResponseData + "</color>");
        }
        else
            Debug.Log("Error during upload: " + w.error);
    }

    //For entering new event
    public void RegisterCarEvent(string carEventName, string carEventParameter)
    {
        //StartCoroutine(registerCarEvent(carEventName,carEventParameter));
        RecordEventLocally(carEventName,carEventParameter);
    }

    private void RecordEventLocally(string carEventName, string carEventParameter)
    { 
        string _dateTime = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + " " 
            + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second; //year-month-date hour:minute:second

        //Create an event object
        CarEvent _carEvent = new CarEvent(_dateTime, carId, carEventName, carEventParameter);

        //Store that event object in a file
        if (!Directory.Exists(StaticDataHolder.LauncherCommonLocation)) Directory.CreateDirectory(StaticDataHolder.LauncherCommonLocation);
        if (!File.Exists(StaticDataHolder.CarEventsFile) || new FileInfo(StaticDataHolder.CarEventsFile).Length == 0)
        {
            //If saving locally for the 1st time, create a new car event list and add current event to it
            carEventList = new List<CarEvent> { _carEvent };
        }
        else
        {
            //If local file exist, fetch previous car event list and add current event to it
            carEventList = JsonUtility.FromJson<CarEventList>(File.ReadAllText(StaticDataHolder.CarEventsFile)).carEventList;
            if (!(carEventList.Exists(c => c.dateTime.Equals(_carEvent.dateTime) && c.eventName.Equals(_carEvent.eventName))))
                carEventList.Add(_carEvent);
        }
        File.WriteAllText(StaticDataHolder.CarEventsFile, JsonUtility.ToJson(new CarEventList(carEventList), true));
    }

    IEnumerator registerUserInfo()
    {
        WWWForm form = new WWWForm();
        form.AddField("system_name", SystemInfo.deviceName);
        form.AddField("location", "");  

        UnityWebRequest w = UnityWebRequest.Post(hostingURL + "registerUserInfo", form);
        yield return w.SendWebRequest();
        if (w.error == null)
        {
            //Debug.Log("Record inserted.");
            Debug.Log("Error during upload: " + w.error);
            string itemData = w.downloadHandler.text;
            var ResponseData = JSON.Parse(itemData);
            Debug.Log(ResponseData);
            if(ResponseData["status"] == "duplicate")
            {
                Debug.Log("Record alredy exists.");
            }
            PlayerPrefs.SetString("user_id", ResponseData["Data"][0]["user_id"]);
            Debug.Log(PlayerPrefs.GetString("user_id"));
        }
        else
            Debug.Log("Error during upload: " + w.error);
    }

    //For entering new event
    public void RegisterUserInfo()
    {
        if (PlayerPrefs.HasKey("user_id")) return;
        StartCoroutine(registerUserInfo());
    }

    public void LockedParameters()
    {
        RegisterCarEvent("LockedCarPackage", LockedData.LockedCarPackage);
        RegisterCarEvent("LockedStylingPackage", LockedData.LockedStylingPackage);
        RegisterCarEvent("LockedPaint", LockedData.LockedPaint);
        RegisterCarEvent("LockedSeat", LockedData.LockedSeat);
        RegisterCarEvent("LockedRim", LockedData.LockedRim);
        RegisterCarEvent("LockedCaliper", LockedData.LockedCaliper);
        RegisterCarEvent("LockedInlays", LockedData.LockedInlays);
        RegisterCarEvent("LockedSteeringWheel", LockedData.LockedSteeringWheel);
        if(LockedData.LockedCarPackage.Contains("RSQ8")) 
            RegisterCarEvent("LockedBootNet", LockedData.LockedBootNet);

        #region "Record Locked Config event"
        string _dateTime = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + " "
            + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second; //year-month-date hour:minute:second
        string _lockedConfigString = LockedData.LockedCarPackage + "," + LockedData.LockedStylingPackage + "," + LockedData.LockedPaint +
            "," + LockedData.LockedRim + "," + LockedData.LockedCaliper + "," + LockedData.LockedSeat + "," + LockedData.LockedInlays +
            "," + LockedData.LockedSteeringWheel;
        if (LockedData.LockedCarPackage.Contains("RSQ8")) _lockedConfigString += "," + LockedData.LockedBootNet;
        string _mobile = "", _email = "", _videoUrl = "";

        //Create an locked config event object
        LockedConfig _lockedConfig = new LockedConfig(_dateTime, carId, _lockedConfigString, _mobile, _email, _videoUrl);

        //Store that event object in a file
        if (!Directory.Exists(StaticDataHolder.LauncherCommonLocation)) Directory.CreateDirectory(StaticDataHolder.LauncherCommonLocation);
        if (!File.Exists(StaticDataHolder.LockedConfigFile) || new FileInfo(StaticDataHolder.LockedConfigFile).Length == 0)
        {
            //If saving locally for the 1st time, create a new locked config event list and add current event to it
            lockedConfigList = new List<LockedConfig> { _lockedConfig };
        }
        else
        {
            //If local file exist, fetch previous locked config event list and add current event to it
            lockedConfigList = JsonUtility.FromJson<LockedConfigList>(File.ReadAllText(StaticDataHolder.LockedConfigFile)).lockedConfigList;
            if (!lockedConfigList.Exists(l => l.dateTime.Equals(_lockedConfig.dateTime))) lockedConfigList.Add(_lockedConfig);
        }
        File.WriteAllText(StaticDataHolder.LockedConfigFile, JsonUtility.ToJson(new LockedConfigList(lockedConfigList), true));
        #endregion
    }
}

[Serializable]
public class CarEvent
{ 
    public string dateTime, carId, eventName, eventParameter;
    public bool eventUploaded;
    public CarEvent(string _dateTime, string _carId, string _eventName, string _eventParameter)
    {
        dateTime = _dateTime;
        carId = _carId;
        eventName = _eventName;
        eventParameter = _eventParameter;
        eventUploaded = false;
    }
}

[Serializable]
public class CarEventList
{
    public List<CarEvent> carEventList;
    public CarEventList(List<CarEvent> _carEventList) => carEventList = _carEventList;
}

[Serializable]
public class LockedConfig
{
    public string dateTime, carId, lockedConfig,
        mobile, email, videoUrl;
    public bool eventUploaded;
    public LockedConfig(string _dateTime, string _carId, string _lockedConfig,
        string _mobile, string _email, string _videoUrl)
    {
        dateTime = _dateTime;
        carId = _carId;
        lockedConfig = _lockedConfig;
        mobile = _mobile;
        email = _email;
        videoUrl = _videoUrl;
        eventUploaded = false;
    }

}

[Serializable]
public class LockedConfigList
{
    public List<LockedConfig> lockedConfigList;
    public LockedConfigList(List<LockedConfig> _lockedConfigList) => lockedConfigList = _lockedConfigList;
}
