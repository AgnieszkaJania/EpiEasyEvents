﻿using EPiServer;
using EPiServer.Core;

namespace Forte.EpiEasyEvents
{
    public interface IContentEventHandler<TContentType, TEventArgsType> where TEventArgsType : ContentEventArgs where TContentType : IContentData
    {
        void Handle(TContentType content, TEventArgsType eventArgs);
    }
}
