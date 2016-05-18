namespace CarQuotaNoPickPublic.Properties
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    internal class Resources
    {
        private static CultureInfo resourceCulture;
        private static System.Resources.ResourceManager resourceMan;

        internal Resources()
        {
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }

        internal static Bitmap main_bg
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("main_bg", resourceCulture);
            }
        }

        internal static Bitmap main_bg_c
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("main_bg_c", resourceCulture);
            }
        }

        internal static Bitmap main_bgC
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("main_bgC", resourceCulture);
            }
        }

        internal static Bitmap main_btn2
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("main_btn2", resourceCulture);
            }
        }

        internal static Bitmap main_btn4
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("main_btn4", resourceCulture);
            }
        }

        internal static Bitmap main_close
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("main_close", resourceCulture);
            }
        }

        internal static Bitmap main_close2
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("main_close2", resourceCulture);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    System.Resources.ResourceManager manager = new System.Resources.ResourceManager("CarQuotaNoPickPublic.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = manager;
                }
                return resourceMan;
            }
        }
    }
}

