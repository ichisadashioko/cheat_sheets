# The package

```python
import re
```

# Regex functions

- `findall` : Returns a list containing all matches
- `search` : Returns a `Match` object if there is a match anywhere in the string
- `split` : Returns a list where the string has been split at each match
- `sub` : Replaces one or many matches with a string

# Find matching pattern in string

```python
txt = 'import re'
re.search('re', txt) # returns <_sre.SRE_Match object; span=(7, 9), match='re'>
re.search('\w+', txt) # returns <_sre.SRE_Match object; span=(0, 6), match='import'>
```

# Replace matched string

- Replace with string

```python
re.sub('re', 'os', 'import re') # returns 'import os'

re.sub('r', '3', 'import re') # returns 'impo3t 3e'
```

- Replace with regex

```python
re.sub(r"(\w+)(\s+)(\w+)", r"\3\2\1", 'import re') # return 're import'
```