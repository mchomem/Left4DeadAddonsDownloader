# Left 4 Dead Addons Downloader

Addon Download is a small tool to automate content download for the addons folder in the Left 4 Dead game. Developed in C#. net core, this tool is very practice and util, with one click it's possible to get all designed custom content to the game.

![Left 4 Dead Addons Downloader](/Docs/img/l4dad.png)

## Tool features

- Download files from the source site;
- Unzipping downloaded files;
- Copy to the Left 4 Dead game addons directory;
- Record (in .csv format) of previously downloaded files to avoid new downlaod;
- Log recording of all activities.

## Json file

From reading a file in json format available on a website, the tool obtains url's containing the download of vpk files.
The json file format is this:

```
{
	FilesToDownload: [
		{
			Label: "hem no mercy 1",
			Url: "https://www.gamemaps.com/mirrors/download/7890/6"
		}
	]
}
```

The tool is currently available on the website [Super Expert Brasil](http://superexpertbrasil.servegame.com).

## Dependence

"Left 4 Dead Addon Download" needs .NET 5.0 to work. This binary can be founded in https://dotnet.microsoft.com/download/dotnet/thank-you/runtime-5.0.10-windows-x64-installer. Is already included on the installer.

## Support

Currently the tool can run on Windows 10 on 64 bit platform.

## License

Left 4 Dead Addon Donwload is distributed under the Open Source Licence.
