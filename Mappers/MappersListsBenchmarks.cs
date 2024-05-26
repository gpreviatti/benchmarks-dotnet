using AutoMapper;
using BenchmarkDotNet.Attributes;
using Mapster;

namespace Mappers;

[MemoryDiagnoser]
[HardwareCounters]
[MarkdownExporter]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
public class MappersListsBenchmarks
{
    IMapper autoMapper;

    [GlobalSetup(Target = nameof(AutoMapper))]
    public void AutoMapperSetup()
    {
        MapperConfiguration config = new(cfg =>
        {
            cfg.CreateMap<PersonEntity, PersonEntityDto>();
            cfg.CreateMap<AccountEntity, AccountEntityDto>();
            cfg.CreateMap<AddressEntity, AddressEntityDto>();
        });
        autoMapper = new Mapper(config);
    }

    [GlobalSetup(Target = nameof(MapsterLookingForConstructor))]
    public void MapsterLookingForConstructorSetup()
    {
        TypeAdapterConfig.GlobalSettings.Default.MapToConstructor(true);
        TypeAdapterConfig.GlobalSettings.Default.IgnoreNullValues(true);
    }

    [Benchmark(Description = "Native")]
    [Arguments(1, 10)]
    [Arguments(10, 100)]
    [Arguments(100, 200)]
    public void Native(int amountPeople, int amountAccounts)
    {
        var people = PersonEntity.GetPerson(amountPeople, amountAccounts);

        foreach (var person in people)
        {
            var personDto = new PersonEntityDto
            {
                Id = person.Id,
                Name = person.Name,
                Email = person.Email,
                BirthDate = person.BirthDate,
                Address = new()
                {
                    Id = person.Address.Id,
                    City = person.Address.City,
                    ZipCode = person.Address.ZipCode,
                    State = person.Address.State,
                    Country = person.Address.Country,
                    Neighborhood = person.Address.Neighborhood,
                },
                Accounts = person.Accounts.Select(x => new AccountEntityDto()
                {
                    Id = x.Id,
                    AccountType = x.AccountType,
                    Description = x.Description,
                    UserId = x.UserId
                }).ToList()
            };
        }
    }

    [Benchmark(Description = nameof(MapsterLookingForConstructor))]
    [Arguments(1, 10)]
    [Arguments(10, 100)]
    [Arguments(100, 200)]
    public void MapsterLookingForConstructor(int amountPeople, int amountAccounts)
    {
        var people = PersonEntity.GetPerson(amountPeople, amountAccounts);

        foreach (var person in people)
            person.Adapt<PersonEntityDto>();
    }

    [Benchmark(Description = nameof(Mapster))]
    [Arguments(1, 10)]
    [Arguments(10, 100)]
    [Arguments(100, 200)]
    public void Mapster(int amountPeople, int amountAccounts)
    {
        var people = PersonEntity.GetPerson(amountPeople, amountAccounts);

        foreach (var person in people)
            person.Adapt<PersonEntityDto>();
    }

    [Benchmark(Description = nameof(AutoMapper))]
    [Arguments(1, 10)]
    [Arguments(10, 100)]
    [Arguments(100, 200)]
    public void AutoMapper(int amountPeople, int amountAccounts)
    {
        var people = PersonEntity.GetPerson(amountPeople, amountAccounts);

        foreach (var person in people)
            autoMapper.Map<PersonEntityDto>(person);
    }
}
