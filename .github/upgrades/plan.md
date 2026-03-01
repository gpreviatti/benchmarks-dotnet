# .NET 10.0 Upgrade Plan

## Execution Steps

Execute steps below sequentially one by one in the order they are listed.

1. Validate that a .NET 10.0 SDK required for this upgrade is installed on the machine and if not, help to get it installed.
2. Ensure that the SDK version specified in global.json files is compatible with the .NET 10.0 upgrade.
3. Upgrade JsonCerverterxJsonSerializerxProtobuffer\JsonCerverterxJsonSerializerxProtobuffer.csproj to .NET 10.0
4. Upgrade HttpClientxRefit\HttpClientxRefit.csproj to .NET 10.0
5. Upgrade Mappers\Mappers.csproj to .NET 10.0
6. Upgrade DatabaseFrameworks\DatabaseFrameworks.csproj to .NET 10.0
7. Upgrade ClassStructRecord\ClassStructRecord.csproj to .NET 10.0
8. Upgrade ReferencexValue\ReferencexValue.csproj to .NET 10.0
9. Upgrade ListsAndSpans\ListsAndSpans.csproj to .NET 10.0

## Settings

### Aggregate NuGet packages modifications across all projects

NuGet packages used across all selected projects or their dependencies that need version update in projects that reference them.

| Package Name                                 | Current Version | New Version | Description                           |
|:---------------------------------------------|:---------------:|:-----------:|:--------------------------------------|
| Microsoft.EntityFrameworkCore                |    8.0.6        |  10.0.3     | Recommended for .NET 10.0             |
| Microsoft.EntityFrameworkCore.SqlServer      |    8.0.6        |  10.0.3     | Recommended for .NET 10.0             |
| Microsoft.Extensions.Hosting                 |    8.0.0        |  10.0.3     | Recommended for .NET 10.0             |
| Newtonsoft.Json                              |   13.0.3        |  13.0.4     | Recommended for .NET 10.0             |

### Project upgrade details

#### JsonCerverterxJsonSerializerxProtobuffer\JsonCerverterxJsonSerializerxProtobuffer.csproj modifications

Project properties changes:
- Target framework should be changed from `net8.0` to `net10.0`

NuGet packages changes:
- Newtonsoft.Json should be updated from `13.0.3` to `13.0.4`

Feature upgrades:
- System.Net.Http.HttpContent.ReadAsStreamAsync API behavioral change: This method now returns a memory stream instead of the network stream, which may affect streaming scenarios. Review code that depends on the stream type.

#### HttpClientxRefit\HttpClientxRefit.csproj modifications

Project properties changes:
- Target framework should be changed from `net8.0` to `net10.0`

NuGet packages changes:
- Microsoft.Extensions.Hosting should be updated from `8.0.0` to `10.0.3`

#### Mappers\Mappers.csproj modifications

Project properties changes:
- Target framework should be changed from `net8.0` to `net10.0`

#### DatabaseFrameworks\DatabaseFrameworks.csproj modifications

Project properties changes:
- Target framework should be changed from `net8.0` to `net10.0`

NuGet packages changes:
- Microsoft.EntityFrameworkCore should be updated from `8.0.6` to `10.0.3`
- Microsoft.EntityFrameworkCore.SqlServer should be updated from `8.0.6` to `10.0.3`

#### ClassStructRecord\ClassStructRecord.csproj modifications

Project properties changes:
- Target framework should be changed from `net8.0` to `net10.0`

#### ReferencexValue\ReferencexValue.csproj modifications

Project properties changes:
- Target framework should be changed from `net9.0` to `net10.0`

#### ListsAndSpans\ListsAndSpans.csproj modifications

Project properties changes:
- Target framework should be changed from `net9.0` to `net10.0`