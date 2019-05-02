# Vim

## SCROLLING + SCREENS:

- Screen positions: H M L (high, middle, low)
- Scrolling: Ctrl-U/D/B/F (up, down, back, forward)
## EDITING:

- :e[dit] {file}
- :f[ind] {file}
- goto file: gf
- Alternate buffer Ctrl-^
- Enter insert mode at the begining/end of line: `I`/`A`

## SEARCHING:

- /{pattern}
- ?{pattern}
- Search forward for word under cursor: *
- Search backward for word under cursor: #
- Goto declaration: gd

## MARKS

- m{a-zA-Z} sets up a custom location
- `{a-zA-Z} to jump to mark

## TAGS:

- Ctrl-] to jump to keyword definition
- Ctrl-t to pop from the tag stack
- :tags to see all tags

## JUMPS/CHANGES:

- Ctrl-O / Ctrl-I to cycle through jumplist
- g; / g, to cycle through changes

## Miscellaneous

- Insert a line below/above and enter `INSERT` mode: `o`/`O`
- Basic movement: `h`, `j`, `k`, and `l` (left, down, up, and right)
- Word movement: `w`, `e`, and `b`

## Cut, Copy, and Paste

- `cut`:

	1. Place your cursor at the start or end of the piece of text
	2. Press `v` to enter `VISUAL` mode
	3. Use your movement skill to select the piece of text
	4. Press `x` to `cut`

- `paste`: Press `p` to paste.

## `QUIT`

- `:q`: normal `quit`
- `:q!`: force `quit` without saving
- `:wq`: `write` (save) then `quit`
- `:qall`: `quit` all

## Project file structure

- `:20vs .`: show the current directory `.` with `20` character wide vertical (`v`) split (`s`)
- Change viewport: `Ctrl` + `w` (twice)
- Split the file:

	- `:sp`: horizontal split
	- `:vsp`: vertical split

- Swap viewport: `Ctrl` + `w` then `x`
