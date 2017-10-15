namespace AESharp.Database.Entities.MySql.Models.Logon
{
    public enum AccountFlags : byte
    {
        Classic = 0,
        TheBurningCrusade = 8,
        WrathOfTheLichKing = 16,
        WrathAndBurningCrusade = AccountFlags.TheBurningCrusade | AccountFlags.WrathOfTheLichKing,
        //Cataclysm = 32,
        //MistsOfPandaria = 64,
        //WarlordsOfDraenor = 128,
        //Legion = 256,
    }
}