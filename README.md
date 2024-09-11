# DeviceTestingKitApp Sample App with NSubstitute

This folder contains a dummy sample app that can be used to run unit tests on an Android device, to demonstrate a 
problem with CastelProxy `DynamicProxyGenAssembly2` when using NSubstitute to mock internal interfaces and targeting
`net8.0-android` or `net9.0-android`.

## Projects

The `src` folder contains two projects:

* `DeviceTestingKitApp`  
  This is the main app. It is a simple ".NET MAUI app" with a single non-interactive page.
* `DeviceTestingKitApp.MauiLibrary`  
  This is a .NET MAUI class library that contains an internal interface and class that we want to use in an NSubstitute
  test.

The `test` folder contains a `DeviceTestingKitApp.DeviceTests` project containing two trivial tests:
- `SuccessfulTest` that always passes
- `InternalInterfaces_ShouldBeAccessible` that uses NSubstitute to mock an internal class in the `DeviceTestingKitApp.MauiLibrary` project. This test always fails.

To run these tests with XHarness:


1. LAUNCH A DEVICE
  I used a Pixel 5 running Android API v33. Consequently, the runtime setting used below is `android-arm64`.

2. PUBLISH THE APP
  ```zsh
  dotnet publish test/DeviceTestingKitApp.DeviceTests/DeviceTestingKitApp.DeviceTests.csproj \
            -f net8.0-android \
            -r android-arm64 \
            -c Release \
            -p:AndroidSdkDirectory=/Users/jamescrosswell/Library/Developer/Xamarin/android-sdk-macosx \
            /bl:./artifacts/logs/msbuild-publish.binlog
  ```

3. RUN THE TESTS
  ```zsh
  dotnet xharness android test \
    --timeout="00:05:00" \
    --launch-timeout=00:10:00 \
    --package-name com.companyname.devicetestingkitapp.devicetests \
    --instrumentation devicerunners.xharness.maui.XHarnessInstrumentation \
    --app test/DeviceTestingKitApp.DeviceTests/bin/Release/net8.0-android/android-arm64/publish/com.companyname.devicetestingkitapp.devicetests-Signed.apk \
    --output-directory artifacts \
  && code=0 && break || code=$? && sleep 15
  ```

## Result

The test using NSubstitute will fail. The results will be output to `/artifacts/TestResults.xml` and will contain 
the following failure:
```
System.ArgumentException : Can not create proxy for type DeviceTestingKitApp.IDummyHelper because it is not accessible. Make it public, or internal and mark your assembly with [assembly: InternalsVisibleTo(\"DynamicProxyGenAssembly2\")] attribute, because assembly DeviceTestingKitApp.MauiLibrary is not strong-named.
```

However, the `InternalsVisibleTo` attribute is already defined in DeviceTestingKitApp.MauiLibrary.csproj (which is the
assembly containing the internal interface and class that CastleProxy needs).