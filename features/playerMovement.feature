Feature: Player Movement

  Scenario: Player increases ball speed
    Given the game is launched and the race has started
    When the player presses the left arrow key
    Then the velocity bar increases by 1

  Scenario: Player alternates between left and right to increase speed
    Given the game is launched and the race has started
    When the player presses the left arrow key
    And the player presses the right arrow key
    Then the velocity bar increases by 2
