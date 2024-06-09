using System.Data;
using BenchmarkDotNet.Attributes;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFrameworks;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
public class DatabaseBenchmarks
{
    protected EntityFrameworkDbContext? _entityFrameworkDbContext;
    protected IDbConnection? _dbConnection;

    #region Setups
    [GlobalSetup(Target = nameof(Entity_Framework_Select_One))]
    public void Entity_Framework_Select_One_Setup() => _entityFrameworkDbContext = new();

    [GlobalSetup(Target = nameof(Entity_Framework_Select_One_No_Tracking))]
    public void Entity_Framework_Select_One_No_Tracking_Setup() => _entityFrameworkDbContext = new();

    [GlobalSetup(Target = nameof(Dapper_Select_One))]
    public void Dapper_Select_One_Setup() 
        => _dbConnection = new SqlConnection("Server=127.0.0.1,1433;Database=benchmarks;User Id=sa;Password=SqlServer2022!;TrustServerCertificate=true;");

    [GlobalSetup(Target = nameof(Dapper_Select_One_With_Fields))]
    public void Dapper_Select_One_With_Fields_Setup()
        => _dbConnection = new SqlConnection("Server=127.0.0.1,1433;Database=benchmarks;User Id=sa;Password=SqlServer2022!;TrustServerCertificate=true;");
    #endregion



    [Benchmark(Description = "Entity Framework Select One")]
    public async Task Entity_Framework_Select_One()
    {
        await _entityFrameworkDbContext!.Person
            .FirstOrDefaultAsync(p => p.Name.Equals("Name1"));
    }

    [Benchmark(Description = "Entity Framework Select One No Tracking")]
    public async Task Entity_Framework_Select_One_No_Tracking()
    {
        await _entityFrameworkDbContext!.Person
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Name.Equals("Name1"));
    }

    [Benchmark(Description = "Dapper Select One")]
    public async Task Dapper_Select_One()
    {
        var sql = $"SELECT TOP 1 * FROM Person WHERE Name = @Name";
        await _dbConnection!.QuerySingleAsync<Person>(sql, new { Name = "Name1" });
    }

    [Benchmark(Description = "Dapper Select One With Fields")]
    public async Task Dapper_Select_One_With_Fields()
    {
        var sql = $"SELECT TOP 1 Id, Name, Email, BirthDate FROM Person WHERE Name = @Name";
        await _dbConnection!.QuerySingleAsync<Person>(sql, new { Name = "Name1" });
    }
}
