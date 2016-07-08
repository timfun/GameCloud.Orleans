﻿// Copyright (c) Cragon. All rights reserved.

namespace GF.GrainInterface.Player
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Orleans;
    using GF.Unity.Common;

    public interface IGFClientSession : IGrainWithGuidKey
    {
        //---------------------------------------------------------------------
        Task SubClient(IGFClientObserver sub);

        //---------------------------------------------------------------------
        Task UnsubClient(IGFClientObserver sub);

        //---------------------------------------------------------------------
        // 客户端请求
        Task Request(ushort method_id, byte[] data);

        //---------------------------------------------------------------------
        Task GetPlayerList();

        //---------------------------------------------------------------------
        Task NewPlayer(Dictionary<string, string> map_newplayer_data);

        //---------------------------------------------------------------------
        Task DeletePlayer(string et_player_guid);

        //---------------------------------------------------------------------
        Task EnterWorld();

        //---------------------------------------------------------------------
        Task LeaveWorld();
    }
}
