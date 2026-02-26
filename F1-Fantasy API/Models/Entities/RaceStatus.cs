namespace F1_Fantasy_API.Models.Entites;

public enum RaceStatus
{
    Open,        //0 user can update team
    Locked,      //1 Can't update team
    InProgress,  //2 can add driver race results
    Finished,    //3 checks first for all driver results
    Scored       //4 triggers the team's points calculation functionality
    //Note : I need to make status can't be changed after setting it to scored to reduce errors caused by admin
}