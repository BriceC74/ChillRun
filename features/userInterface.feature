Feature: User Interface

  Scenario: Velocity bar updates
    Given the game is launched and the race has started
    When the player presses the left or right arrow key
    Then the velocity bar updates accordingly

  Scenario: Timer displays
    Given the game is launched and the race has started
    When the race is in progress
    Then the timer displays the elapsed time

  Scenario: Result screen displays
    Given the race has ended
    When the result screen is shown
    Then the result screen displays the winner and the race time
