using BenchmarkDotNet.Attributes;
using Google.Protobuf;
using Newtonsoft.Json;
using System.Text.Json;

namespace JsonCerverterxJsonSerializer;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
public class SerializeBenchmarks
{
    private readonly JsonSerializerOptions _serializerOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    [Benchmark(Description = "Serialize object with JsonSeriealizer")]
    [Arguments(1, 10)]
    [Arguments(10, 100)]
    [Arguments(100, 200)]
    public string SerializeWithJsonSerializer(int amountPeople, int amountAccounts)
    {
        var person = PersonEntity.GetPerson(amountPeople, amountAccounts);

        return System.Text.Json.JsonSerializer.Serialize(person, _serializerOptions);
    }

    [Benchmark(Description = "Serialize object with JsonSeriealizerAsync")]
    [Arguments(1, 10)]
    [Arguments(10, 100)]
    [Arguments(100, 200)]
    public async Task<Stream> SerializeWithJsonSerializerAsync(int amountPeople, int amountAccounts)
    {
        var person = PersonEntity.GetPerson(amountPeople, amountAccounts);

        var stream = new MemoryStream();

        await System.Text.Json.JsonSerializer.SerializeAsync(stream, person, _serializerOptions);

        return stream;
    }

    [Benchmark(Description = "Serialize object with JsonConvert (NewtonSoft)")]
    [Arguments(1, 10)]
    [Arguments(10, 100)]
    [Arguments(100, 200)]
    public string SerializeWithJsonConvert(int amountPeople, int amountAccounts)
    {
        var person = PersonEntity.GetPerson(amountPeople, amountAccounts);

        return JsonConvert.SerializeObject(person);
    }

    [Benchmark(Description = "Serialize with Protobuffer")]
    [Arguments(1, 10)]
    [Arguments(10, 100)]
    [Arguments(100, 200)]
    public byte[] SerializeWithProtobuffer(int amountPeople, int amountAccounts)
    {
        var person = PersonProto.GetPerson(amountPeople, amountAccounts);

        using var stream = new MemoryStream();
        ProtoBuf.Serializer.Serialize(stream, person);

        return stream.ToArray();
    }
}