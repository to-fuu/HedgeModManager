using System.Runtime.Versioning;

namespace HedgeModManager.ObjectiveC
{
    [SupportedOSPlatform("macos")]
    public struct NSWorkspace
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(NSWorkspace obj) => obj.NativePtr;

        public NSWorkspace()
        {
            // Ensure AppKit is linked
            ObjectiveC.LinkAppKit();

            var cls = new ObjectiveCClass("NSWorkspace");
            NativePtr = ObjectiveC.IntPtr_objc_msgSend(cls, new Selector("sharedWorkspace"));
        }

        public string UrlForApplicationWithBundleIdentifier(string bundleIdentifier)
        {
            var nsString = StringHelper.NSString(bundleIdentifier);
            var path = ObjectiveC.IntPtr_objc_msgSend(NativePtr, new Selector("URLForApplicationWithBundleIdentifier:"), nsString);
            nsString.Dispose();

            return new string(ObjectiveC.string_objc_msgSend(path, new Selector("fileSystemRepresentation")));
        }
    }
}
