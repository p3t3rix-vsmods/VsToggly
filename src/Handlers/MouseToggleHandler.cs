using Vintagestory.API.Client;

namespace Toggly.Handlers
{
    class MouseToggleHandler
    {
        private bool _isMouseActive;
        private bool _isMouseToggled;

        private readonly ICoreClientAPI _clientApi;
        private readonly TogglyConfig _config;
        public MouseToggleHandler(ICoreClientAPI clientApi, TogglyConfig config)
        {
            _clientApi = clientApi;
            _config = config;
        }

        public void Activate()
        {
            _clientApi.Event.KeyDown += EventOnKeyDown;
            _clientApi.Event.MouseDown += EventOnMouseDown;
            _clientApi.Event.MouseUp += EventOnMouseUp;
            _clientApi.Input.RegisterHotKey("toggleMouse", "Toggly Toggle Mouse", GlKeys.Tilde);
            _clientApi.Input.HotKeys["toggleMouse"].Handler += OnToggleMouseHotKey;
        }

        private bool OnToggleMouseHotKey(KeyCombination keyCombination)
        {
            _isMouseToggled = !_isMouseToggled;
            return true;
        }

        private void EventOnMouseUp(MouseEvent e)
        {
            if (_isMouseToggled && IsValidMouseButton(e))
            {
                e.Handled = true;
                _isMouseActive = true;
            }
        }

        private void EventOnMouseDown(MouseEvent e)
        {
            if (_isMouseActive && _config.DeactivateWhenMouseClick && IsValidMouseButton(e))
            {
                StopMouseActivation();
            }
        }

        private void EventOnKeyDown(KeyEvent e)
        {
            if (_config.AbortKeycodes.Contains(e.KeyCode))
            {
                StopMouseActivation();
            }
        }

        private bool IsValidMouseButton(MouseEvent e)
        {
            return _config.ValidMouseButtons.Contains((int)e.Button);
        }

        private void StopMouseActivation()
        {
            _isMouseToggled = false;
            _isMouseActive = false;
        }
    }
}
