---
"@collana-solutions/csag-abstractions": major
---

The package moves to a new ID and new namespaces. The API and the behavior are the same as in 2022.2.171322.

| Up to 2022.2.171322 | From this version |
| --- | --- |
| Package `Neolution.Abstractions` | Package `Csag.Abstractions` |
| Namespace `Neolution.Abstractions.Caching` | Namespace `Csag.Abstractions.Caching` |
| Namespace `Neolution.Abstractions.Security` | Namespace `Csag.Abstractions.Security` |
| Namespace `Neolution.Abstractions.Serialization` | Namespace `Csag.Abstractions.Serialization` |

**To migrate:**

1. Replace the `Neolution.Abstractions` package reference with `Csag.Abstractions`, at this version or later.
2. Change the namespaces: `using Neolution.Abstractions.Caching;` becomes `using Csag.Abstractions.Caching;`, and the same for `.Security` and `.Serialization`.

The keys that `CacheProvider<TEnum>` builds contain only the name of your enum type and its values, so they do not change.

The `Neolution.Abstractions` ID gets deprecated on nuget.org, with `Csag.Abstractions` as the alternate. Its existing versions stay available, but it gets no new releases.
