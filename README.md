# LiveChat

LiveChat.OrchardCore is an Orchard Core CMS Module that provides the necessary settings to add script code from your live chat service to the website.

## Status

[![Build status](https://ci.appveyor.com/api/projects/status/thpxx1klwbpekvgv?svg=true)](https://ci.appveyor.com/project/davidhayden/livechat) [![Status](https://img.shields.io/myget/davidhayden-ci/v/LiveChat.OrchardCore.svg)](https://www.myget.org/feed/davidhayden-ci/package/nuget/LiveChat.OrchardCore)

## Getting Started

Add the NuGet package, **LiveChat.OrchardCore**, to the Orchard Core CMS Website. Launch the website and sign in as an administrator to enable the module from the dashboard under <i>Configuration</i> -> <i>Modules</i>.

![LiveChat.OrchardCore](https://github.com/davidhayden/LiveChat/blob/master/assets/livechat-module.png?raw=true)

Add the script code from your live chat service to the settings area provided by the module, <i>Configuration</i> -> <i>Settings</i> -> <i>Live Chat</i>.

![LiveChat.OrchardCore Settings](https://github.com/davidhayden/LiveChat/blob/master/assets/livechat-settings.png?raw=true)

Make sure you check <em>Enable</em> to activate live chat and click <em>Save</em> to save the settings.

Visit the front-end of your website. The script code will be injected at the bottom of every non-admin page just above the closing `body` tag.

## Troubleshooting

If your live chat service is not displaying on the website, here are some common problems.

* **Incorrect Script Code**: Please double-check the script you entered into settings is correct and your live chat service is active and configured properly.
* **Live Chat Not Enabled**: The <em>Enable</em> checkbox allows you to turn on and off live chat without removing the code. Make sure you have checked <em>Enable</em>.
* **Missing FootScript from Theme Layout**: The script code is injected into the website using Orchard Core's `ResourceManager`. Verify your theme's layout is injecting resources of type `FootScript`.

See the Orchard Core Documentation for more information on [Resources](https://orchardcore.readthedocs.io/en/latest/OrchardCore.Modules/OrchardCore.Resources/README/).

## Customizations

The module is easily customizable. Here are a couple possible customizations depending on your needs.

### Injecting Live Chat at Head of Page

If you prefer your live chat script be added within the `head` tag of the page instead of before the closing `body` tag, you can change the `LiveChatFilter` code to inject the code as <em>HeadScript</em>.

```
// _resourceManager.RegisterFootScript(content);
_resourceManager.RegisterHeadScript(content);
```

### Requesting Live Chat Code Instead of Script in Settings

Many third-party plugins ask for a <em>code</em>, instead of a <em>script</em>, from the live chat service. These plugins are usually specific to a certain service and a bit more fragile since they need to be updated when the script they embed changes. Asking for a script avoids frequent updates and allows the module to support multiple live chat services.

However, you can modify the module to request a code in settings instead of a script by changing `LiveChatSettings.Edit.cshtml`. You can then embed the live chat service's script in the module and generate the script using the code before the call to `_resourceManager`.

```
var code = new HtmlString(settings.Text);
var content = GenerateScript(code);
_resourceManager.RegisterFootScript(content);
```

## Road map

There is 1 planned enhancement:

* **Caching**: Caching will be implemented using `IMemoryCache`.

## Credits
LiveChat.OrchardCore is created and maintained by David Hayden.
