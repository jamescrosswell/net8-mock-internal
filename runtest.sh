#!/bin/bash

set -eux

# Clean up the artifacts directory
rm -rfd artifacts

# Build the test app
dotnet publish test/SimpleApp.DeviceTests/SimpleApp.DeviceTests.csproj \
          -f net8.0-android \
          -r android-arm64 \
          -c Release \
          /bl:./artifacts/logs/msbuild-publish.binlog

# Run the tests using xharness
dotnet xharness android test \
  --timeout="00:05:00" \
  --launch-timeout=00:10:00 \
  --package-name com.companyname.simpleapp.devicetests \
  --instrumentation devicerunners.xharness.maui.XHarnessInstrumentation \
  --app test/SimpleApp.DeviceTests/bin/Release/net8.0-android/android-arm64/publish/com.companyname.simpleapp.devicetests-Signed.apk \
  --output-directory artifacts
