using Foundation.Util.Extensions;
using Toggly.Handlers;
using Vintagestory.API.Client;
using Vintagestory.API.Common;

namespace Toggly
{
    public class TogglyModSystem : ModSystem
    {
        private ICoreClientAPI _clientApi;
        private TogglyConfig _config;

        private MouseToggleHandler _mouseToggleHandler;
        private SprintToggleHandler _sprintToggleHandler;

        public override bool ShouldLoad(EnumAppSide side) => side == EnumAppSide.Client;

        public override void StartClientSide(ICoreClientAPI api)
        {
            _clientApi = api;
            _config = _clientApi.LoadOrCreateConfig<TogglyConfig>("TogglyConfig.json");

            _mouseToggleHandler = new MouseToggleHandler(api, _config);
            _sprintToggleHandler = new SprintToggleHandler(api);

            _mouseToggleHandler.Activate();
            _sprintToggleHandler.Activate();
        }
    }
}
