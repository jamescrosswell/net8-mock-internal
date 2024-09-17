# DeviceTestingKitApp Sample App with NSubstitute

This folder contains a couple of simple class libraries and a DeviceTest app that can be used to run unit tests for the
classes and methods in those libraries on an Android device, to demonstrate a with CastelProxy `DynamicProxyGenAssembly2` 
when using NSubstitute to mock internal interfaces and targeting `net8.0-android` or `net9.0-android`.

## Projects

The `src` folder contains two libraries:

* `SimpleApp.Library`  
  A basic class library with an internal interface that we want to mock during testing.
* `SimpleApp.StrongLib`  
  A strongly named class library that also has an internal interface that we want to mock during testing.

The `test` folder contains a `SimpleApp.DeviceTests` project with some unit tests for each of the class libraries.

To run these tests with XHarness:

1. LAUNCH A DEVICE
    I used a Pixel 5 running Android API v33. Consequently, the runtime setting used below is `android-arm64`.

2. PUBLISH THE APP
    ```zsh
    dotnet publish test/SimpleApp.DeviceTests/SimpleApp.DeviceTests.csproj \
              -f net8.0-android \
              -r android-arm64 \
              -c Release \
              /bl:./artifacts/logs/msbuild-publish.binlog
    ```

3. RUN THE TESTS
    ```zsh
    dotnet xharness android test \
      --timeout="00:05:00" \
      --launch-timeout=00:10:00 \
      --package-name com.companyname.simpleapp.devicetests \
      --instrumentation devicerunners.xharness.maui.XHarnessInstrumentation \
      --app test/SimpleApp.DeviceTests/bin/Release/net8.0-android/android-arm64/publish/com.companyname.simpleapp.devicetests-Signed.apk \
      --output-directory artifacts
    ```

## Result

I was expecting the unit test using the internal interface from the strongly named assembly to fail... as this is what 
we're seeing in our production app. However, all the test are currently passing so this needs further investigation. 