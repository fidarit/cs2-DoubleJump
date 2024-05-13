![GitHub tag (with filter)](https://img.shields.io/github/v/tag/fidarit/cs2-DoubleJump?style=for-the-badge&label=Version)
![GitHub Repo stars](https://img.shields.io/github/stars/fidarit/cs2-DoubleJump?style=for-the-badge)
![GitHub all releases](https://img.shields.io/github/downloads/fidarit/cs2-DoubleJump/total?style=for-the-badge)
![GitHub last commit (branch)](https://img.shields.io/github/last-commit/fidarit/cs2-DoubleJump/master?style=for-the-badge)

# DoubleJumpCS2
CS2 implementation of double jump plugin written in C# for CounterStrikeSharp. Based on the version for CS:GO by FoxSerito.

## Features
- [x] Setting jump counts via config or `dj_count` command
- [x] Setting jump velocity via config or `dj_velocity` command

## Config
The configuration file can be found at the following path: `addons\counterstrikesharp\configs\plugins\DoubleJumpCS2\DoubleJumpCS2.json`

```json
{
  "JumpsCount": 2,
  "Velocity": 250.0,
  "AllowInstantJump": true
  "RequiredPermission": "@css/vip"
}
```

### Configuration Options:
- **JumpsCount**: Specifies the maximum number of consecutive jumps allowed. Default value is `2`.  
- **Velocity**: Sets the velocity of the double jump. Default value is `250.0`.  
- **AllowInstantJump**: Determines whether instant double jumps are allowed. When set to `false`, the next jump can only be performed when the player has started falling. Default value is `true`.  
- **RequiredPermission**: Specifies the required permission level for using the double jump feature. If empty, all players are granted access. Default value is `"@css/vip"`.

## Requirements
- [Metamod:Source](https://www.sourcemm.net/downloads.php/?branch=master)
- [CounterStrikeSharp](https://github.com/roflmuffin/CounterStrikeSharp)

## Installation
1. Download the zip file from the [latest release](../../releases), and extract the contents into your `counterstrikesharp/plugins` directory.

## Acknowledgments
If you appreciate the project then please take the time to star the repository 🙏

![Star us](https://github.com/b3none/gdprconsent/raw/development/.github/README_ASSETS/star_us.png)

## Credits
This was inspired by the [CS:GO DoubleJump](https://github.com/FoxSerito/FOXWORLD_plugin_DoubleJump_CSGO) written by [FoxSerito](https://github.com/FoxSerito).
