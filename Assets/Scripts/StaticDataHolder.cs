using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class StaticDataHolder
{
    //Launcher details
    public static string LauncherCommonLocation { get { return Path.GetPathRoot(Application.dataPath) + "/ComXR Updater"; } }
    public static string CarEventsFileName { get { return "car_events"; } }
    public static string CarEventsFile { get { return LauncherCommonLocation + "/" + CarEventsFileName + ".dat"; } }
    public static string LockedConfigFileName { get { return "locked_config"; } }
    public static string LockedConfigFile { get { return LauncherCommonLocation + "/" + LockedConfigFileName + ".dat"; } }

}
