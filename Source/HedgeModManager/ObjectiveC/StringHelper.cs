using System.Runtime.Versioning;

namespace HedgeModManager.ObjectiveC
{
    [SupportedOSPlatform("macos")]
    public static class StringHelper
    {
        public static NSString NSString(string source)
        {
            return new(ObjectiveC.IntPtr_objc_msgSend(new ObjectiveCClass("NSString"), "stringWithUTF8String:", source));
        }
    }
}
