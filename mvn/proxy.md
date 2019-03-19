# MVN proxy

- `mvn [COMMAND] -Dhttp.proxyHost=[PROXY_SERVER] -Dhttp.proxyPort=[PROXY_PORT] -Dhttp.nonProxyHosts=[PROXY_BYPASS_IP]`

- Example
    - `mvn package -Dhttp.proxyHost=proxy -Dhttp.proxyPort=8080`
    - `mvn package -Dhttps.proxyHost=proxy -Dhttps.proxyPort=8080`
    - `mvn package -Dhttp.proxyHost=proxy -Dhttp.proxyPort=8080 -Dhttps.proxyHost=proxy -Dhttps.proxyPort=8080`