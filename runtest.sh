#!/bin/bash

set -eux

# Clean up the artifacts directory
rm -rfd artifacts

# Build the test app
dotnet publish test/DeviceTestingKitApp.DeviceTests/DeviceTestingKitApp.DeviceTests.csproj \
          -f net8.0-android \
          -r android-arm64 \
          -c Release \
          -p:AndroidSdkDirectory=/Users/jamescrosswell/Library/Developer/Xamarin/android-sdk-macosx \
          /bl:./artifacts/logs/msbuild-publish.binlog

# Run the tests using xharness
dotnet xharness android test \
  --timeout="00:05:00" \
  --launch-timeout=00:10:00 \
  --package-name com.companyname.devicetestingkitapp.devicetests \
  --instrumentation devicerunners.xharness.maui.XHarnessInstrumentation \
  --app test/DeviceTestingKitApp.DeviceTests/bin/Release/net8.0-android/android-arm64/publish/com.companyname.devicetestingkitapp.devicetests-Signed.apk \
  --output-directory artifacts \
&& code=0 && break || code=$? && sleep 15