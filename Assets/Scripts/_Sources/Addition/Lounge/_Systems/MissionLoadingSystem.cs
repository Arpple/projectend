using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lounge {
    public class MissionLoadingSystem: IInitializeSystem {
        private MissionSetting setting;
        private GameContext _context;
        private MissionBookController MissionBookController;

        public MissionLoadingSystem(Contexts contexts,MissionBookController MissionBookController,MissionSetting missionSetting){
            this._context = contexts.game;
            this.MissionBookController = MissionBookController;
            this.setting = missionSetting;
        }

        public void Initialize() {
            this.MissionBookController.Init(_context.localEntity, setting);
        }
    }
}
