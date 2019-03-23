# NodeJS File System Module

## Create new text file

    ```javascript
    fs.openSync(file_path, [option])
    ```

- `w` flag will create the file if not exist and will remove all the content of the existing file
- `a` flag will create the file if not exist and not overwrite the file

## Write to file

    ```javascript
    fs.writeFile(file_path, content, {flag: 'a+'}, (err) => {})
    ```

- Some commonly flags:

    - `r+` open the file for reading and writing
    - `w+` open the file for reading and writing, positioning the stream at the beginning of the file. The file is created if not exisiting
    - `a` open the file for writing, positioning the stream at the and of the file. The file is created if not exisiting
    - `a+` open the file for reading and writing, positioning the stream at the end of the file. The file is created if not exisiting