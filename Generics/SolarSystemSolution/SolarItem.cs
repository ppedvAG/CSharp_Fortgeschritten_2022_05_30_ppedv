namespace SolarSystemSolution;

//public class SolarItem
//{
//    public string Description { get; set; } 
//    public SolarItemType Type { get; set; }

//    public SolarItem(string description, SolarItemType solarItemType)
//    {
//        Description = description;  
//        Type = solarItemType;
//    }
//}

record SolarItem(string Description, SolarItemType Type);

public enum SolarItemType { Star, Planet, Trabant }
