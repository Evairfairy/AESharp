namespace AESharp.Core.Database.Models.Logon
{
    public enum AccountFlags : byte
    {
        Classic = 0,
        TheBurningCrusade = 8,
        WrathOfTheLichKing = 16,
        WrathAndBurningCrusade = TheBurningCrusade | WrathOfTheLichKing,
        //Cataclysm = 32,
        //MistsOfPandaria = 64,
        //WarlordsOfDraenor = 128,
        //Legion = 256,
    }
}