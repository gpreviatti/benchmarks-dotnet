using BenchmarkDotNet.Running;
using FastExpressionCompiler;
using Mapster;

TypeAdapterConfig.GlobalSettings.Compiler = exp => exp.CompileFast();

BenchmarkRunner.Run(typeof(Program).Assembly);