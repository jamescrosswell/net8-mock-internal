namespace DeviceTestingKitApp;

internal class Dummy(IDummyHelper dummyHelper)
{
	public string GetDummyString() => dummyHelper.GetDummyString();
}
