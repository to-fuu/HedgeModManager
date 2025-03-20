using System.Runtime.Versioning;

namespace HedgeModManager.ObjectiveC
{
    [SupportedOSPlatform("macos")]
    public readonly struct ObjectiveCClass
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(ObjectiveCClass c) => c.NativePtr;

        public ObjectiveCClass(string name)
        {
            var ptr = ObjectiveC.objc_getClass(name);

            if (ptr == IntPtr.Zero)
            {
                Console.WriteLine($"Failed to get class {name}!");
            }

            NativePtr = ptr;
        }
    }
}
