﻿# EpiEasyEvents

Simple helper to make implementing handlers for EpiServer events easier

# Installation
`Install-Package Forte.EpiEasyEvents`

# How to use

First, add new initializable module that will register all event handlers in EpiServer:
```cs
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class EventHandlersRegistrar : ContentEventHandlersModule
    {
        // provide all assemblies that contains event handlers
        public EventHandlersRegistrar():base(typeof(EventHandlersRegistrar).Assembly)
        {
        }
    }
```

Then create class that implements any of the generic event handler interfaces in `Forte.EpiEasyEvents.EventHandlers` namespace. Each interface has generic argument being the content type for event.

Each interface derives from `IContentEventHandler<TContentType, TEventArgsType>` and has single method to implement: 
```cs
    void Handle(TContentType content, TEventArgsType eventArgs);
```


Example:

```cs
    // handler that will be fired when StandardPage was published
   public class ContentPublishedHandler : IPublishedContentHandler<StandardPage> 
    {
        public ContentPublishedHandler()
        {
        }
        
        public void Handle(NewsArticlePage content, SaveContentEventArgs eventArgs)
        {
            // ...
        }
    }
```