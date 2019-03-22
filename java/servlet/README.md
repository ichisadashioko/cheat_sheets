# Java Servlet Cheat Sheet

## Redirect `request`

```java
request.getRequestDispatcher("[another-servlet]").forward(request, response);
```

## Java Servlet HttpSession

### Get `HttpSession` from `HttpRequest`

```java
HttpSession sess = request.getSession();
```

## Include a header file in JSP

```jsp
<jsp:include page="header_file"/>
```