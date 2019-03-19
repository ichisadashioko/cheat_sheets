## Set proxy

- `git config --global [proxy-type].proxy [proxy-type]://[username]:[password]@[proxy-server-url]:[port]`

- Examples

    ```bash
    git config --global https.proxy https://:@proxy:8080
    git config --global http.proxy http://:@proxy:8080
    git config --global ftp.proxy ftp://:@proxy:8080
    ```

## Unset proxy

- `git config --global --unset-all [proxy-type].proxy`

- Examples

    ```bash
    git config --global --unset-all https.proxy
    git config --global --unset-all http.proxy
    git config --global --unset-all ftp.proxy
    ```