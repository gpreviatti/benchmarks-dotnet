# Solution with BenchMarks tests

Simpple solution with some benchmarks for some of the most used libraries and packages in dotnet

- `ListsAndSpans`: compares iteration/sum performance across arrays, List<T>, interface-based collections, and Span<T>. Results showed that Span<T> is fastest, followed by arrays then List<T>, while interface-based iteration incurs significant overhead. See the detailed report in `ListsAndSpans/BenchmarkDotNet.Artifacts/results`.

## Results

[JsonConverter x JsonSerializer x Protobuffer](./JsonCerverterxJsonSerializerxProtobuffer)

[HttpClient x Refit](./HttpClientxRefit)

[Mappers Libraries](./Mappers)

[Database Frameworks](./DatabaseFrameworks)

[Class x Struct x Record](./ClassStructRecord)

[Lists and Spans](./ListsAndSpans) – detailed benchmarks and HTML report available in the project directory.
