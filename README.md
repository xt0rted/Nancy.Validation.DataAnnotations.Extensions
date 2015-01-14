# Nancy.Validation.DataAnnotations.Extensions

[![Build status](https://ci.appveyor.com/api/projects/status/k5r5yhlca6cl79i6?svg=true)](https://ci.appveyor.com/project/xt0rted/nancy-validation-dataannotations-extensions)
[![NuGet Status](http://img.shields.io/nuget/v/Nancy.Validation.DataAnnotations.Extensions.svg?style=flat)](https://www.nuget.org/packages/Nancy.Validation.DataAnnotations.Extensions/)
[![MyGet Status](https://img.shields.io/myget/13degrees/vpre/Nancy.Validation.DataAnnotations.Extensions.svg?style=flat&label=myget)](http://www.myget.org/f/13degrees)

This project adds support to `Nancy.Validation.DataAnnotations` for the following .NET 4.5 attributes.

- [CompareAttribute](http://msdn.microsoft.com/en-us/library/System.ComponentModel.DataAnnotations.CompareAttribute.aspx)
- [CreditCardAttribute](http://msdn.microsoft.com/en-us/library/System.ComponentModel.DataAnnotations.CreditCardAttribute.aspx)
- [EmailAddressAttribute](http://msdn.microsoft.com/en-us/library/System.ComponentModel.DataAnnotations.EmailAddressAttribute.aspx)
- [FileExtensionsAttribute](http://msdn.microsoft.com/en-us/library/System.ComponentModel.DataAnnotations.FileExtensionsAttribute.aspx)
- [MaxLengthAttribute](http://msdn.microsoft.com/en-us/library/System.ComponentModel.DataAnnotations.MaxLengthAttribute.aspx)
- [MinLengthAttribute](http://msdn.microsoft.com/en-us/library/System.ComponentModel.DataAnnotations.MinLengthAttribute.aspx)
- [PhoneAttribute](http://msdn.microsoft.com/en-us/library/System.ComponentModel.DataAnnotations.PhoneAttribute.aspx)
- [UrlAttribute](http://msdn.microsoft.com/en-us/library/System.ComponentModel.DataAnnotations.UrlAttribute.aspx)


## Development

This repository contains `.git*` and `.hg*` files. This allows for the use of either Git or [Hg](http://mercurial.selenic.com/) using Fog Creek's [Kiln Harmony](http://www.fogcreek.com/kiln/).

To use Hg you will need to clone or fork this repository and then import it into your instance of Kiln as a Git repository. From there you will be able to work in Hg exclusively aside from when pushing changes up to GitHub. You will also need to enable the [EOL extension](http://mercurial.selenic.com/wiki/EolExtension) for this repository if you do not have it setup globally.


## Release

1. Tag the most recent commit
2. Bump the version number in `SharedAssemblyInfo.cs`


## Copyright and license

Copyright (c) 2015 Brian Surowiec under [the MIT License](LICENSE).