# 🏝️ MAUIsland

![](showcases/projectmockup.png)

MAUIsland is a collection of native controls, helper functions, custom controls, and app services that come from built-in MAUI framework, Syncfusion and later MAUI Toolkit, Telerik and DevExpress will added. It simplifies and demonstrates common developer patterns when building experiences for crossplatform development. It contains components and helpers to give .NET developers have better times for what they need and interact with the real result that MAUI generated.

# ⚠ Warning

We just introduced our breaking changes and this will impact the community for trying our project. Our application require appsettings.Development.json
Please kindly create this file like below image

![image](https://user-images.githubusercontent.com/32596308/221789108-b2795d5e-00d1-4cca-a166-757e818a5983.png)

And here is the content you should put in the file to make the application read the all the settings
```json
{
  "AppSettings": {
    "SyncfusionKey": "If you have a syncfusion key insert here if not the application still start as normal"
  }
}
```
Currently we cannot commit our application settings to the repository because some developers might forget and push all the secret key causing security concert in our personal assets. 


# ⁉ Support

If you need help with something or have an idea, feel free to start a [Discussion](https://github.com/CommunityToolkit/WindowsCommunityToolkit/discussions) or find us on [Discord](https://discord.gg/edgzveQ9KN). If you have detailed repro steps, open an [issue here instead](https://github.com/Strypper/mauisland/issues/new/choose).

# 📄 Code of Conduct

This project has adopted the code of conduct defined by the [Contributor Covenant](http://contributor-covenant.org/)
to clarify expected behavior in our community.
For more information see the [.NET Foundation Code of Conduct](CODE_OF_CONDUCT.md).

# Meet the contributors
<a href="https://github.com/Strypper/MAUIsland/graphs/contributors">
  <img src="https://contrib.rocks/image?repo=Strypper/MAUIsland" />
</a>

Made with [contrib.rocks](https://contrib.rocks).
