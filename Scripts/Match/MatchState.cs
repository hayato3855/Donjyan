using UnityEngine;

public class MatchState : MonoBehaviour
{
    public static bool s_HasEnemyContact = false;
    public static bool s_IsBattle = false;
    public static bool s_IsMatch = false;
    public static bool s_MyAgain = false;
    public static bool s_EnemyAgain = false;
    public static bool s_HasTutorial = false;

    public static GameObject s_MyBattleUnit;
    public static GameObject s_EnemyBattleUnit;

    public static GameObject[,] s_GanarateMyUnits = new GameObject[3,10];
    public static GameObject[,] s_GanarateEnemyUnits = new GameObject[3,10];


    public enum WinnerTeam
    {
        My,
        Enemy
    }
    public static WinnerTeam s_WinnerTeam;
}
