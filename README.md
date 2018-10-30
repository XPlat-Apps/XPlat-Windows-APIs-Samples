XPlat Windows APIs samples
===========

XPlat Windows APIs are designed to make it easier for UWP developers to build for iOS and Android taking advantage of common APIs found in the Windows APIs without a great deal of change to their existing Windows app code. 

The design for these APIs are based on the interfaces within the Windows SDK allowing an ease to porting a current Universal Windows Platform application to Xamarin iOS and Android.

For example, if your application takes advantage of the Windows.Storage (e.g. Windows.Storage.ApplicationData.Current.LocalFolder), we provide a XPlat.Storage API for those (e.g. XPlat.Storage.ApplicationData.Current.LocalFolder) which you can use in your Xamarin iOS and Android applications. 

This repo contains the samples that demonstrate the usage of these APIs within your Windows, Android or iOS applications.

## License
XPlat Windows APIs samples are made available under the terms and conditions of the [MIT license](LICENSE). 
