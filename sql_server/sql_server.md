# SQL Server

[TOC]

## CREATE TABLE

```sql
CREATE TABLE table_name (
    column1 datatype,
    column2 datatype,
    column3 datatype,
    ...
)
```

## ALTER TABLE

### ALTER TABLE - ADD COLUMN

```sql
ALTER TABLE table_name
ADD column_name datatype
```

### ALTER TABLE - DROP COLUMN

```sql
ALTER TABLE table_name
DROP COLUMN column_name
```

### ALTER TABLE - ALTER/MODIFY COLUMN

```sql
ALTER TABLE table_name
ALTER COLUMN column_name datatype
```

## SQL FOREIGN KEY

### SQL FOREIGN KEY on CREATE TABLE

```sql
CREATE TABLE table_name (
    column1 datatype NOT NULL PRIMARY KEY,
    column2 datatype NOT NULL FOREIGN KEY REFERENCES another_table(column_name)
)
```

```sql
CREATE TABLE table_name (
    column1 datatype NOT NULL,
    column2 datatype NOT NULL,
    PRIMARY KEY (column1),
    FOREIGN KEY (column2) REFERENCES another_table(column_name)
)
```

## INSERT Multiple Rows

```sql
INSERT INTO table_name (column_list)
VALUES
    (value_list_1),
    (value_list_2),
    ...
    (value_list_n)
```

## DELETE

```sql
DELETE FROM table_name WHERE condidtion
```

## UPDATE

```sql
UPDATE table_name
SET column1 = value1, column2 = value2, column2 = (column3 + x)...
WHERE condition;
```

## ALWAYS TRUE CONDITIONS

```sql
WHERE TRUE
WHERE 1
WHERE NULL IS NULL
```