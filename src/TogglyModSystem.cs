using Foundation.Util.Extensions;
using Vintagestory.API.Client;
using Vintagestory.API.Common;

namespace Toggly
{
    public class TogglyModSystem : ModSystem
    {
        private bool _isToggled = false;
        private bool _isActive = false;

        private ICoreClientAPI _clientApi;
        private TogglyConfig _config;

        public override bool ShouldLoad(EnumAppSide side) => side == EnumAppSide.Client;

        public override void StartClientSide(ICoreClientAPI api)
        {
            base.StartClientSide(api);
            _clientApi = api;
            _config = _clientApi.LoadOrCreateConfig<TogglyConfig>("TogglyConfig.json");
            _clientApi.Event.KeyDown += EventOnKeyDown;
            _clientApi.Event.MouseDown += EventOnMouseDown;
            _clientApi.Event.MouseUp += EventOnMouseUp;
            _clientApi.Input.RegisterHotKey("toggleMouse", "Toggly Toggle Mouse", GlKeys.Tilde);
            _clientApi.Input.HotKeys["toggleMouse"].Handler += OnToggleMouseHotkey;
        }

        private bool OnToggleMouseHotkey(KeyCombination keyCombination)
        {
            _isToggled = !_isToggled;
            return true;
        }

        private void EventOnMouseUp(MouseEvent e)
        {
            if (_isToggled && IsValidMouseButton(e))
            {
                e.Handled = true;
                _isActive = true;
            }
        }
        
        private void EventOnMouseDown(MouseEvent e)
        {
            if (_isActive && _config.DeactivateWhenMouseClick && IsValidMouseButton(e))
            {
                StopActivation();
            }
        }

        private void EventOnKeyDown(KeyEvent e)
        {
            if (_config.AbortKeycodes.Contains(e.KeyCode))
            {
                StopActivation();
            }
        }

        private bool IsValidMouseButton(MouseEvent e)
        {
            return _config.ValidMouseButtons.Contains((int)e.Button);
        }

        private void StopActivation()
        {
            _isToggled = false;
            _isActive = false;
        }
    }
}
