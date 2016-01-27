
Feature: The Berlin Clock
	As a clock enthusiast
    I want to tell the time using the Berlin Clock
    So that I can increase the number of ways that I can read the time


Scenario: Midnight 00:00
When the time is "00:00:00"
Then the clock should look like
"""
Y
OOOO
OOOO
OOOOOOOOOOO
OOOO
"""


Scenario: Middle of the afternoon
When the time is "13:17:01"
Then the clock should look like
"""
O
RROO
RRRO
YYROOOOOOOO
YYOO
"""

Scenario: Just before midnight
When the time is "23:59:59"
Then the clock should look like
"""
O
RRRR
RRRO
YYRYYRYYRYY
YYYY
"""

Scenario: Midnight 24:00
When the time is "24:00:00"
Then the clock should look like
"""
Y
RRRR
RRRR
OOOOOOOOOOO
OOOO
"""

Scenario: The 13 hours
When the time is "13:00:00"
Then the clock should look like
"""
Y
RROO
RRRO
OOOOOOOOOOO
OOOO
"""

Scenario: Missing time info
When the time is "24:20:"
Then the clock should look like
"""
Sorry! Missing time information. I expect something like "00:00:00" to "24:59:59" (hh:mm:ss)
"""

Scenario: Missing time value separator
When the time is "1345:00"
Then the clock should look like
"""
Sorry! Bad time format. Aren't you missing some ":". I expect something like "00:00:00" to "24:59:59" (hh:mm:ss)
"""

Scenario: More than 2400 time
When the time is "26:04:41"
Then the clock should look like
"""
I can't do it! Sorry but i expect a time between "00:00:00" and "24:59:59"
"""

Scenario: More than 60 minutes
When the time is "24:68:88"
Then the clock should look like
"""
I can't do it! Sorry but i expect a time between "00:00:00" and "24:59:59"
"""


Scenario: The totally wrong tome
When the time is "null"
Then the clock should look like
"""
Oh no! Something went wrong! Please check if the value you are providing is not null
"""

