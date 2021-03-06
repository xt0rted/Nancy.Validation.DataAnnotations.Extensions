# Nancy.Validation.DataAnnotations.Extensions

[![Build Status](https://ci.appveyor.com/api/projects/status/k5r5yhlca6cl79i6?svg=true)](https://ci.appveyor.com/project/xt0rted/nancy-validation-dataannotations-extensions)
[![NuGet Status](http://img.shields.io/nuget/v/Nancy.Validation.DataAnnotations.Extensions.svg?style=flat)](https://www.nuget.org/packages/Nancy.Validation.DataAnnotations.Extensions/)
[![MyGet Status](https://img.shields.io/myget/13degrees/vpre/Nancy.Validation.DataAnnotations.Extensions.svg?style=flat&label=myget)](http://www.myget.org/f/13degrees/)

This project adds support to `Nancy.Validation.DataAnnotations` for the following .NET 4.5 attributes.

- [CompareAttribute](http://msdn.microsoft.com/en-us/library/System.ComponentModel.DataAnnotations.CompareAttribute.aspx)
- [CreditCardAttribute](http://msdn.microsoft.com/en-us/library/System.ComponentModel.DataAnnotations.CreditCardAttribute.aspx)
- [EmailAddressAttribute](http://msdn.microsoft.com/en-us/library/System.ComponentModel.DataAnnotations.EmailAddressAttribute.aspx)
- [EnumDataTypeAttribute](http://msdn.microsoft.com/en-us/library/System.ComponentModel.DataAnnotations.EnumDataTypeAttribute.aspx)
- [FileExtensionsAttribute](http://msdn.microsoft.com/en-us/library/System.ComponentModel.DataAnnotations.FileExtensionsAttribute.aspx)
- [MaxLengthAttribute](http://msdn.microsoft.com/en-us/library/System.ComponentModel.DataAnnotations.MaxLengthAttribute.aspx)
- [MinLengthAttribute](http://msdn.microsoft.com/en-us/library/System.ComponentModel.DataAnnotations.MinLengthAttribute.aspx)
- [PhoneAttribute](http://msdn.microsoft.com/en-us/library/System.ComponentModel.DataAnnotations.PhoneAttribute.aspx)
- [UrlAttribute](http://msdn.microsoft.com/en-us/library/System.ComponentModel.DataAnnotations.UrlAttribute.aspx)


## Using

Install via NuGet `Install-Package Nancy.Validation.DataAnnotations.Extensions`

By default Nancy will load and register all `IDataAnnotationsValidatorAdapter` instances. Unless you've changed how these get loaded there's nothing to configure.


## Release

1. Tag the most recent commit
2. Bump the version number in `SharedAssemblyInfo.cs`


## Copyright and license

Copyright (c) 2017 Brian Surowiec under [the MIT License](LICENSE).
