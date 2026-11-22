# @collana-solutions/csag-abstractions

## 1.0.0

### Major Changes

- [#6](https://github.com/collana-solutions/Csag.Abstractions/pull/6) [`6ff8f6b`](https://github.com/collana-solutions/Csag.Abstractions/commit/6ff8f6b0fb76428d52926828d5a451f7e07f4742) Thanks [@neotrow](https://github.com/neotrow)! - The package moves to a new ID and new namespaces. The API and the behavior are the same as in 2022.2.171322.
  
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
