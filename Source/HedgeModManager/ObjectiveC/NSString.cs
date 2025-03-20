using System.Runtime.Versioning;

namespace HedgeModManager.ObjectiveC
{
    [SupportedOSPlatform("macos")]
    public struct NSString : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(NSString obj) => obj.NativePtr;
        public NSString(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveC.objc_msgSend(NativePtr, sel_release);
        }

        private static readonly Selector sel_release = "release";
    }
}
