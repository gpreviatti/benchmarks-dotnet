using AutoMapper;
using BenchmarkDotNet.Attributes;
using Bogus;
using Mapster;

namespace Mappers;

[MemoryDiagnoser]
[HardwareCounters]
[MarkdownExporter]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
public class MappersBenchmarks
{
    IMapper autoMapper;
    PersonEntity person;

    public MappersBenchmarks() => person = new Faker<PersonEntity>().Generate();

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

    [Benchmark(Description = "Native")]
    public void Native()
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

    [Benchmark(Description = "Mapster")]
    public void Mapster() => person.Adapt<PersonEntityDto>();

    [Benchmark(Description = "AutoMapper")]
    public void AutoMapper() => autoMapper.Map<PersonEntityDto>(person);
}
