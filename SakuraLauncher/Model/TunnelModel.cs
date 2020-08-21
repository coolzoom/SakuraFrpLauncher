﻿using SakuraLibrary.Proto;
using TunnelStatus = SakuraLibrary.Proto.Tunnel.Types.Status;

namespace SakuraLauncher.Model
{
    public interface ITunnelModel
    {
        bool IsReal { get; }
        TunnelModel Real { get; }
    }

    public class TunnelModel : ModelBase, ITunnelModel
    {
        public bool IsReal => true;
        public TunnelModel Real => this;

        public Tunnel Proto = null;

        public int Id => Proto.Id;
        public int Node => Proto.Node;
        public string Name => Proto.Name;
        public string Type => Proto.Type;
        public string Description => Proto.Description;

        public bool Pending => Proto.Status == TunnelStatus.Pending;
        public bool Enabled => Proto.Status != TunnelStatus.Disabled;

        public string NodeName { get => _nodeName; set => Set(out _nodeName, value); }
        private string _nodeName;

        public TunnelModel(Tunnel proto)
        {
            Proto = proto;
        }

        public void Start()
        {

        }

        public void Stop()
        {

        }
    }

    public class FakeTunnelModel : ITunnelModel
    {
        public bool IsReal => false;
        public TunnelModel Real => null;
    }
}
