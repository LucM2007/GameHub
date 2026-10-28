using GameHubApi.Models;
using MongoDB.Driver;

namespace GameHubApi.Data;

public class GameHubDbContext
{
    public IMongoCollection<Accounts> Accounts { get; }
    public IMongoCollection<Games> Games { get; }
    public IMongoCollection<Reviews> Reviews { get; }
    public IMongoCollection<AccountGames> AccountGames { get; }
    public IMongoCollection<AccountReviews> AccountReviews { get; }
    public IMongoCollection<Commants> Comments { get; }
    public IMongoCollection<Footages> Footages { get; }
    public IMongoCollection<GameFootages> GameFootages { get; }
    public IMongoCollection<GameReviews> GameReviews { get; }
    public IMongoCollection<Leaderboards> Leaderboards { get; }
    public IMongoCollection<NewsLetters> NewsLetters { get; }
    public IMongoCollection<RefreshTokens> RefreshTokens { get; }

    public GameHubDbContext(IMongoDatabase database)
    {
        Accounts = database.GetCollection<Accounts>("Accounts");
        Games = database.GetCollection<Games>("Games");
        Reviews = database.GetCollection<Reviews>("Reviews");
        AccountGames = database.GetCollection<AccountGames>("AccountGames");
        AccountReviews = database.GetCollection<AccountReviews>("AccountReviews");
        Comments = database.GetCollection<Commants>("Comments");
        Footages = database.GetCollection<Footages>("Footages");
        GameFootages = database.GetCollection<GameFootages>("GameFootages");
        GameReviews = database.GetCollection<GameReviews>("GameReviews");
        Leaderboards = database.GetCollection<Leaderboards>("Leaderboards");
        NewsLetters = database.GetCollection<NewsLetters>("NewsLetters");
        RefreshTokens = database.GetCollection<RefreshTokens>("RefreshTokens");
    }
}
