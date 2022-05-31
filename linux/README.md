# Linux useful commands

## Show file content from terminal

- Show all file content:

    ```bash
    cat [file-path]
    ```

- Show the first `n` lines:

    ```bash
    head -[n] [file-path]
    ```

- Show file content with line number:

    ```bash
    cat -n [file-path]
    ```

- Count number of lines in text file:

    ```bash
    wc -l [file-path]
    ```

- List all files in folder with its absolute path name:

	```bash
	find $(pwd) -type f
	```

- Finding files

  - by file name: `find . -name filename.ext`
