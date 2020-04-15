using System.Collections.Generic;
using Vintagestory.API.Client;
using Vintagestory.API.Common;

namespace Toggly
{
    public class TogglyConfig
    {
        public List<int> AbortKeycodes { get; set; } = new List<int>(){ (int) GlKeys.Escape};
        public List<int> ValidMouseButtons { get; set; } = new List<int>(){ (int) EnumMouseButton.Right, (int) EnumMouseButton.Left};
        public bool DeactivateWhenMouseClick { get; set; } = true;
    }
}
