using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagePresto
{
    class ImageSizeItem : IComparable<ImageSizeItem>
    {
        public readonly float Aspect;
        public readonly ImageSize Size;

        public ImageSizeItem(ImageSize imSize)
        {
            this.Size = imSize;
            this.Aspect = imSize.Aspect();
        }

        public int CompareTo(ImageSizeItem other)
        {
            if (this.Aspect.CompareTo(other.Aspect) !=0)
            {
                return this.Aspect.CompareTo(other.Aspect);
            }
            return 0;
        }

        public static int CompareByAspect(ImageSizeItem a, ImageSizeItem b)
        {
            return a.Aspect.CompareTo(b.Aspect);
        }

        public int CompareToAspect(float aspect)
        {
            return 0;
        }
    }
}
