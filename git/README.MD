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

## Signing commits

Config `git` to sign every commits without adding the `-S` option.

```sh
git config --global commit.gpgSign true
```

Tell `git` about the key that we want to use to sign commits.

```sh
git config --global user.signingKey <key>
```

## Prevent "destructive" pull

When you have changes in both remote and local, `git pull` will attempt to merge them. As we have already known, resolving conflicts is the least thing I want `git` to handle automatically.

```sh
git config --global pull.ff only
```
