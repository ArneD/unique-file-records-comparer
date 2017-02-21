# Unique File Records Comparer

## What problem does it solve?

Imagine the following scenario.

File 1:

| Name | Birthdate | ... |
| ---- | --------- | --- |
| Foo bar | 29/02/1985 | xxx |
| Lastname Firstname | 1/1/1981 | abc |
| ... | ... | ... |

File 2:

| First name | Last name | Birthdate | ... |
| ---------- | --------- | --------- | --- |
| Foo | Bar | 29/02/1985 | xxx |
| Firstname | Lastname | 1/1/1981 | def |

If selecting columns to compare Name vs First name & Last name, the program will match these 2 records.

## How to use

First, select your source file and target file.

For example: [Source](https://github.com/ArneD/unique-file-records-comparer/blob/master/src/UniqueFileRecordsComparer/tests/UniqueFileRecordsComparer.Core.IntegrationTests/TestFiles/TwoFieldsCsvWithHeaders.csv) [Target](https://github.com/ArneD/unique-file-records-comparer/blob/master/src/UniqueFileRecordsComparer/tests/UniqueFileRecordsComparer.Core.IntegrationTests/TestFiles/OneFieldXlsxWithHeaders.xlsx)

Then select which columns to compare

![Select columns](https://github.com/ArneD/unique-file-records-comparer/blob/master/assets/selectColumns.PNG "Select your columns")

Result

![Result](https://github.com/ArneD/unique-file-records-comparer/blob/master/assets/result.PNG "Result")