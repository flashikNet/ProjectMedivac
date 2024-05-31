using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Infrastructure.Data;

public static class MongoDbContext
{
    public static void AddMongoDbDependencies(this IServiceCollection services, string connectionString, string databaseName)
    {
        services.AddSingleton<IMongoClient>(provider => new MongoClient(connectionString));
        services.AddScoped<IMongoDatabase>(provider =>
        {
            var mongoClient = provider.GetRequiredService<IMongoClient>();
            return mongoClient.GetDatabase(databaseName);
        });

        services.AddScoped<IMongoCollection<Team>>(provider =>
        {
            var database = provider.GetRequiredService<IMongoDatabase>();
            return database.GetCollection<Team>("Teams");
        });   
        
        services.AddScoped<IMongoCollection<User>>(provider =>
        {
            var database = provider.GetRequiredService<IMongoDatabase>();
            return database.GetCollection<User>("Users");
        });     
        
        services.AddScoped<IMongoCollection<Duel>>(provider =>
        {
            var database = provider.GetRequiredService<IMongoDatabase>();
            return database.GetCollection<Duel>("Duels");
        });        
    }
}