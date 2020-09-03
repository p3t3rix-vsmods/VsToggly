using System;
using Vintagestory.API.Client;
using Vintagestory.API.Common;

namespace Toggly.Handlers
{
    class SprintToggleHandler
    {
        private bool _isSprintToggled = false;

        private readonly ICoreClientAPI _clientApi;

        public SprintToggleHandler(ICoreClientAPI clientApi)
        {
            _clientApi = clientApi;
        }

        public void Activate()
        {
            _clientApi.Input.RegisterHotKey("toggleSprint", "Toggly Toggle Sprint", GlKeys.CapsLock);
            _clientApi.Input.HotKeys["toggleSprint"].Handler += OnToggleSprintHotKey;
            _clientApi.Input.InWorldAction += OnEntityAction;
        }

        private void OnEntityAction(EnumEntityAction action, bool @on, ref EnumHandling handled)
        {
            if (_isSprintToggled && action == EnumEntityAction.Sprint && !on)
            {
                handled = EnumHandling.PreventDefault;
            }
        }

        private bool OnToggleSprintHotKey(KeyCombination t1)
        {
            _isSprintToggled = !_isSprintToggled;
            _clientApi.World.Player.Entity.Controls.Sprint = true;
            return true;
        }
    }
}
