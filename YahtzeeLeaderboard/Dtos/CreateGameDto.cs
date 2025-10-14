namespace YahtzeeLeaderboard.Dtos
{
    public record CreateGameDto(
        int PlayerOne,
        DateTime Date,
        int? PlayerTwo,
        int? PlayerThree,
        int? PlayerFour,
        int? PlayerFive,
        int? PlayerSix
    );
}