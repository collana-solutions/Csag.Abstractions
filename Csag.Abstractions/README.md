# Csag.Abstractions

Common abstractions for .NET libraries and applications, for .NET Standard 1.2 and later.

| Type | Namespace | Purpose |
| --- | --- | --- |
| `ICacheProvider<TEnum>` | `Csag.Abstractions.Caching` | Gets, sets and resets cached objects in containers named by an enum value, optionally identified by a string key and with an expiration. |
| `CacheProvider<TEnum>` | `Csag.Abstractions.Caching` | Base class for an `ICacheProvider<TEnum>`. It builds the cache keys (`<enum type>:<container>` or `<enum type>:<container>_<key>`) and leaves the storage to four abstract methods. |
| `IPasswordHasher` | `Csag.Abstractions.Security` | Creates and verifies password hashes. |
| `IStringSerializer` | `Csag.Abstractions.Serialization` | Serializes objects to strings and back. |

The package holds no implementations of the interfaces. The application provides them, for example an `IPasswordHasher` based on BCrypt.

## Coming from Neolution.Abstractions

Up to version 2022.2.171322 this package was published as `Neolution.Abstractions`. Replace the package reference with `Csag.Abstractions` and change the namespaces from `Neolution.Abstractions.*` to `Csag.Abstractions.*`. The API is the same.

The [repository](https://github.com/collana-solutions/Csag.Abstractions) has the changelog and the release process.
