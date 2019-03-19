# VirtualBox

## Change VM resolution when `Guest Addition Image` has not been installed.

- Open terminal in VirtualBox install location

- `VBoxManage setextradata [VM-name] [custom-video-mode-name] [resolution]`

- Example: `VBoxManage setextradata "Widnows 7" CustomVideoMode2 1366x768x32`