using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace HedgeModManager.ObjectiveC
{
    [SupportedOSPlatform("macos")]
    public static partial class ObjectiveC
    {
        public const string ObjCRuntime = "/usr/lib/libobjc.A.dylib";
        public const string Libdl = "libdl.dylib";

        public const string AppKitFramework = "/System/Library/Frameworks/AppKit.framework/AppKit";

        [LibraryImport(ObjCRuntime, StringMarshalling = StringMarshalling.Utf8)]
        public static partial IntPtr objc_getClass(string name);

        [LibraryImport(Libdl, StringMarshalling = StringMarshalling.Utf8)]
        private static partial IntPtr dlopen(string path, int mode);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial void objc_msgSend(IntPtr receiver, Selector selector);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial IntPtr IntPtr_objc_msgSend(IntPtr receiver, Selector selector);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend", StringMarshalling = StringMarshalling.Utf8)]
        public static partial IntPtr IntPtr_objc_msgSend(IntPtr receiver, Selector selector, string param);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend")]
        public static partial IntPtr IntPtr_objc_msgSend(IntPtr receiver, Selector selector, IntPtr a);

        [LibraryImport(ObjCRuntime, EntryPoint = "objc_msgSend", StringMarshalling = StringMarshalling.Utf8)]
        public static partial string string_objc_msgSend(IntPtr receiver, Selector selector);

        public static IntPtr LinkAppKit()
        {
            return dlopen(AppKitFramework, 0);
        }
    }
}
