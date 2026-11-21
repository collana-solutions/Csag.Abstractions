# Csag.Abstractions

Common abstractions for .NET libraries and applications, published as the NuGet package [`Csag.Abstractions`](https://www.nuget.org/packages/Csag.Abstractions) for .NET Standard 1.2 and later:

- `ICacheProvider<TEnum>` and its base class `CacheProvider<TEnum>`: caching in containers named by an enum value (`Csag.Abstractions.Caching`)
- `IPasswordHasher`: password hashing (`Csag.Abstractions.Security`)
- `IStringSerializer`: string serialization (`Csag.Abstractions.Serialization`)

The [package README](Csag.Abstractions/README.md) describes the types.

```bash
dotnet add package Csag.Abstractions
```

Up to version 2022.2.171322 the package was published as `Neolution.Abstractions`, with the namespaces `Neolution.Abstractions.*`.

## Build

Prerequisites:

- The .NET SDK pinned in [global.json](global.json) (10.0.4xx, a newer 10.0 SDK rolls forward).
- Node.js 24 with Corepack, for the changesets tooling: run `corepack enable` and then `pnpm install` once in the repository root.

```bash
dotnet restore --locked-mode
dotnet build --configuration Release --no-restore
dotnet pack --configuration Release --no-build -o ./nupkgs
```

The package project has a `packages.lock.json`, and CI restores in locked mode. After changing a package reference, run `dotnet restore` without `--locked-mode` and commit the updated lock file.

`Csag.Abstractions.UnitTests` is not part of the solution, so neither CI nor a restore at the repository root builds it. It targets `netcoreapp3.1` and references `Neolution.Extensions.DependencyInjection` from the private Azure DevOps feed `neolution`, which `nuget.config` maps for that package only. Restoring it needs credentials for that feed.

## Preview packages

Each pull request to `main` or to a `release/**` branch publishes the package to a public preview feed on feedz.io. A draft PR, a PR from a fork and a PR from Dependabot publish no preview. The version is one patch above the current release, for example `2023.0.1-pr.42.183` (PR 42, workflow run 183). The **"chore: version packages"** PR publishes a release candidate of the upcoming version instead, for example `2023.1.0-pr.73.190`, so the changes of the next release can be tested before it ships. In prerelease mode the version in `package.json` is a prerelease such as `2024.0.0-rc.0`, and the preview extends it, for example `2024.0.0-rc.0.pr.42.183`. That version sorts after the prerelease and before the next one. A comment on the PR gives the version of its latest push. The feed removes previews after 30 days. Releases go to nuget.org only.

To use a preview in an application, add the feed to the `nuget.config` of the application. The feed needs no credentials:

```xml
<packageSources>
  <clear />
  <add key="nuget.org" value="https://api.nuget.org/v3/index.json" />
  <add key="csag-abstractions-previews" value="https://f.feedz.io/collana-solutions/csag-abstractions/nuget/index.json" />
</packageSources>
<packageSourceMapping>
  <packageSource key="nuget.org">
    <package pattern="*" />
    <package pattern="Csag.Abstractions" />
  </packageSource>
  <packageSource key="csag-abstractions-previews">
    <package pattern="Csag.Abstractions" />
  </packageSource>
</packageSourceMapping>
```

The `Csag.Abstractions` pattern is also necessary under nuget.org. NuGet looks for a package only in the sources of its most specific pattern, so without it the released versions do not restore.

To test a preview:

1. Set `Csag.Abstractions` to the preview version.
2. If the application restores in locked mode, update its `packages.lock.json` files.
3. Add the feed only on the branch that tests the preview. The main branch of the application then does not need feedz.io to restore.

## Release process

This repository follows the [collana-solutions release playbook](https://github.com/collana-solutions/release-playbook) (Changesets, NuGet variant):

1. Every PR that changes the package needs a changeset. Run `pnpm changeset`, choose the bump type and describe the change for consumers of the package. CI's **Changeset Check** fails a PR that changes the project folder, `Directory.Build.props`, `Directory.Packages.props` or `global.json` without a changeset. Add an empty one (`pnpm changeset --empty`) when such a change ships nothing. A PR that only touches CI or repository documentation needs none.
2. On merge to `main`, the Release workflow keeps a **"chore: version packages"** PR up to date. It bumps the version in `Csag.Abstractions/package.json`, writes it into the `.csproj` with `scripts/sync-versions.mjs` and updates `Csag.Abstractions/CHANGELOG.md`.
3. Merging that PR creates the git tag and the GitHub Release. The release starts the **NuGet Publish** workflow, which packs the package and pushes it to nuget.org through trusted publishing.

Dependabot PRs get their changesets automatically. Do not edit `CHANGELOG.md` or the `<Version>` in the `.csproj` by hand.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
