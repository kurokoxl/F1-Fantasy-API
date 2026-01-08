namespace F1_Fantasy_API.Models.Entites;

public enum RaceStatus
{
    Open,         //user can update team
    Locked,      
    InProgress,  
    Finished,    //admin can add results
    Scored       // admin can update results
}