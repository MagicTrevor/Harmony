<<<<<<< HEAD
<<<<<<< HEAD
<p align="center">

  <h3 align="center">Harmony</h3>

  <p align="center">
    Clean, simple, and flexible ddd-based framework.
  </p>
</p>

<br>

## Table of contents

- [Quick start](#quick-start)
- [Status](#status)
- [License](#license)

## Quick start

Pre-release builds are published to [Harmony MyGet gallery.](https://www.myget.org/packages/harmony-ci/absoluteLatest)

## Status

[![Build status](https://ci.appveyor.com/api/projects/status/6k43rh3bd1kj2rk1?svg=true)](https://ci.appveyor.com/project/MagicTrevor/harmony)

|    | Version |
|:---|--------:|
|**Harmony.Core**|[![MyGet](https://img.shields.io/myget/harmony-ci/v/Harmony.Core.svg)](https://www.myget.org/packages/harmony-ci/absoluteLatest)|
|**Harmony.Data**|[![MyGet](https://img.shields.io/myget/harmony-ci/v/Harmony.Data.svg)](https://www.myget.org/packages/harmony-ci/absoluteLatest)|
|**Harmony.Data.EntityFrameworkCore**|[![MyGet](https://img.shields.io/myget/harmony-ci/v/Harmony.Data.EntityFrameworkCore.svg)](https://www.myget.org/packages/harmony-ci/absoluteLatest)||

## License

Code released under the [MIT License](https://github.com/MagicTrevor/Harmony/blob/master/LICENSE).
=======
[![Build Status](https://travis-ci.org/magictrevor/harmony.png)](https://travis-ci.org/magictrevor/harmony)
=======
[![Build status](https://ci.appveyor.com/api/projects/status/6k43rh3bd1kj2rk1?svg=true)](https://ci.appveyor.com/project/MagicTrevor/harmony)
>>>>>>> 5d44227... Update README.md

# Harmony

<<<<<<< HEAD
A small DDD-based base library
>>>>>>> a83ebf6... Update README.md
=======
## Synopsis

This is a small DDD (Domain-Driven Design) library for use in C# DOTNET projects targeting NETStandard1.4+.

## Code Example
#### Interfaces
```csharp
public interface IEntity<TKey> {
  TKey Id { get; set; }
}
```

```csharp
public interface IAuditable {
  DateTime Created { get; set; }
  string CreatedBy { get; set; }
  
  DateTime? Modified { get; set; }
  string ModifiedBy { get; set; }
}
```

## Tests

Coming soon!

## License

Licensed under MIT
>>>>>>> f6c58a0... Update README.md
