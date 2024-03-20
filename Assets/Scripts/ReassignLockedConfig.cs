using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

public class ReassignLockedConfig : MonoBehaviour
{
    [Header("References")]
    public AnalyticsHandler analyticsHandler;
    public SingleOptionSelector rimSelector;
    public materialChangeSystem rimMCS1, rimMCS2, 
        caliperMCS, armRestMCS, inlaysMCS, bootNetMCS;
    public CxrCategoryManager seatCategoryManager, steeringCategoryManager,
        steeringLogoCategoryManager;

    public List<string> rimTypes;

    [Header("Config")]
    public string[] configs;
    
    [Header("Indexes")]
    public int carPackageIndex;
    public int stylingPackageIndex, paintIndex, rimIndex, 
        caliperIndex, seatIndex, upholsteryIndex,armRestIndex, inlaysIndex,
        steeringWheelIndex, steeringWheelLogoIndex, bootNetIndex;

    bool isRSQ8;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reassign(string _configString)
    {
        configs = _configString.Split(',');
        isRSQ8 = configs[0].Contains("RSQ8");

        //Remove escape characters
        for(int i = 0; i < configs.Length; i++) { configs[i] = Regex.Unescape(configs[i]); }

        //Packages
        carPackageIndex = analyticsHandler.carPackage.configs.ToList().FindIndex(x => x.name.Contains(configs[0]));
        stylingPackageIndex = analyticsHandler.stylingPackage.configs.ToList().FindIndex(x => x.name.Contains(configs[1]));

        //Car Paint
        materialChangeSystem _paintMCS = isRSQ8 ? analyticsHandler.carPaintMCSRSQ8 : analyticsHandler.carPaintMCSQ8;
        paintIndex = _paintMCS.materials.ToList().FindIndex(x => x.name.Contains(configs[2]));

        //Rim
        rimIndex = rimSelector.optionNamesForAnalytics.ToList().FindIndex(x => configs[3].Contains(x));
        int _mcsIndex = 0;
        if (isRSQ8) _mcsIndex = rimMCS1.materialNamesForAnalytics.ToList().FindIndex(x => x.Contains(configs[3]));

        //Caliper
        caliperIndex = caliperMCS.materialNamesForAnalytics.ToList().FindIndex(x => configs[4].Contains(x));

        //Seat
        string seatName = configs[5].Substring(0, configs[5].IndexOf("(") != -1 ? configs[5].IndexOf("(") : configs[5].Length);
        string upholstery = configs[5].Split('(', ')')[1];
        seatIndex = seatCategoryManager.categoryNameForAnalytics.FindIndex(x => seatName.Contains(x));
        upholsteryIndex = analyticsHandler.upholsteryMCS[seatIndex].MaterialNameForAnalyticsList().FindIndex(x => upholstery.Contains(x));
        armRestIndex = upholstery.Contains("Brown") ? 1 : (upholstery.Contains("Black") ? 0 : (upholstery.Contains("Grey") ? 3 : 2));

        //Inlays
        inlaysIndex = inlaysMCS.materialNamesForAnalytics.ToList().FindIndex(x => configs[6].Contains(x));

        //Steering Wheel
        steeringWheelIndex = steeringCategoryManager.categoryNameForAnalytics.FindIndex(x => configs[7].Contains(x));
        steeringWheelLogoIndex = steeringLogoCategoryManager.categoryNameForAnalytics.FindIndex(x => configs[7].Contains(x));

        //Boot net
        if (isRSQ8) bootNetIndex = bootNetMCS.materialNamesForAnalytics.ToList().FindIndex(x => configs[8].Contains(x));

        //Assign configs
        analyticsHandler.carPackage.SetConfig(carPackageIndex);
        analyticsHandler.stylingPackage.SetConfig(stylingPackageIndex);
        _paintMCS.SetMaterial(paintIndex);
        rimSelector.Select(rimIndex);
        rimMCS1.SetMaterial(_mcsIndex);
        rimMCS2.SetMaterial(_mcsIndex);
        caliperMCS.SetMaterial(caliperIndex);
        seatCategoryManager.Select(seatIndex);
        analyticsHandler.upholsteryMCS[seatIndex].OnMatChange(upholsteryIndex);
        armRestMCS.SetMaterial(armRestIndex);
        inlaysMCS.SetMaterial(inlaysIndex);
        steeringCategoryManager.Select(steeringWheelIndex);
        if (steeringWheelLogoIndex != -1) steeringLogoCategoryManager.Select(steeringWheelLogoIndex);
        if (isRSQ8) bootNetMCS.SetMaterial(bootNetIndex);
    }
}
