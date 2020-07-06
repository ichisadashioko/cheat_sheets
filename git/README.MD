# Tips for `git`

## Configure `git` to use `vim`

`vim` is not the default editor for editing commit message on Linux.

```sh
git config --global core.editor "vim"
```

## Stop `git` on Windows converts `lf` to `crlf` when checking out

This is useful for cloning with `git` on Windows and using the repo in `WSL` or another Linux systems (dual-booting or shared drives).

```sh
git config --global core.autocrlf false
```

## List all tags

List all released versions of the library.

```sh
git tag
# or
git tag -l
```

## Checkout from tag

```sh
git checkout tags/<tag_name> -b <branch_name>
```
