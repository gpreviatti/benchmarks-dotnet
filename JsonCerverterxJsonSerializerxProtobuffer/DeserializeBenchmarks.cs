using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;

namespace JsonCerverterxJsonSerializer;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
public class DeserializeBenchmarks
{
    private readonly JsonSerializerOptions _serializerOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    [Benchmark(Description = "Deserialize object with JsonSeriealizer")]
    [Arguments(1, 10)]
    [Arguments(10, 100)]
    [Arguments(100, 200)]
    public async Task<List<PersonEntity>> DeserializeWithJsonSerializer(int amountPeople, int amountAccounts)
    {
        var person = PersonEntity.GetPerson(amountPeople, amountAccounts);

        var stringContent = new StringContent(
            System.Text.Json.JsonSerializer.Serialize(person, _serializerOptions),
            Encoding.UTF8,
            "application/json"
        );

        var stream = await stringContent.ReadAsStreamAsync();

        return await System.Text.Json.JsonSerializer.DeserializeAsync<List<PersonEntity>>(stream);
    }

    [Benchmark(Description = "Deserialize object with JsonSeriealizer Async")]
    [Arguments(1, 10)]
    [Arguments(10, 100)]
    [Arguments(100, 200)]
    public async Task<List<PersonEntity>> DeserializeWithJsonSerializerAsync(int amountPeople, int amountAccounts)
    {
        var person = PersonEntity.GetPerson(amountPeople, amountAccounts);

        var content = await GetJson(person);

        var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

        var stream = await stringContent.ReadAsStreamAsync();

        return await System.Text.Json.JsonSerializer.DeserializeAsync<List<PersonEntity>>(stream);
    }

    [Benchmark(Description = "Deserialize object with JsonConvert (NewtonSoft)")]
    [Arguments(1, 10)]
    [Arguments(10, 100)]
    [Arguments(100, 200)]
    public async Task<List<PersonEntity>?> DeserializeWithJsonConvert(int amountPeople, int amountAccounts)
    {
        var person = PersonEntity.GetPerson(amountPeople, amountAccounts);

        var stringContent = new StringContent(
            JsonConvert.SerializeObject(person),
            Encoding.UTF8,
            "application/json"
        );

        var stream = await stringContent.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<List<PersonEntity>>(stream);
    }

    [Benchmark(Description = "Deserialize with Protobuffer")]
    [Arguments(1, 10)]
    [Arguments(10, 100)]
    [Arguments(100, 200)]
    public List<PersonProto> DeserializeWithProtobuffer(int amountPeople, int amountAccounts)
    {
        var person = PersonProto.GetPerson(amountPeople, amountAccounts);

        using var stream = new MemoryStream();
        ProtoBuf.Serializer.Serialize(stream, person);

        var arrayBytes = stream.ToArray();

        using var memoryStream = new MemoryStream(arrayBytes);
        return ProtoBuf.Serializer.Deserialize<List<PersonProto>>(memoryStream);
    }


    private static async Task<string> GetJson(object obj)
    {
        using var stream = new MemoryStream();

        await System.Text.Json.JsonSerializer.SerializeAsync(stream, obj, obj.GetType());

        stream.Position = 0;
        using var reader = new StreamReader(stream);

        return await reader.ReadToEndAsync();
    }
}