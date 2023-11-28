using System;
using System.Collections.Generic;

public struct UIItemsData
{
    public string header;
    public string leftPanel;
    public string rightPanel;
    public List<GearSet> leftGearSet;
    public List<GearSet> rightGearSet;
    public Action<GearSet> leftCallback;
    public Action<GearSet> rightCallback;
}