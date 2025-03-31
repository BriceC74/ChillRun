Feature: Race Logic

  Scenario: Race starts
    Given the game is launched
    When the player presses the start button
    Then the race starts
    And the timer begins

  Scenario: Race ends
    Given the race has started
    When the NPC reaches the finish line
    Then the race ends
    And the game displays the result screen

  Scenario: Player reaches the finish line
    Given the race has started
    When the player reaches the finish line
    Then the race ends
    And the game displays the result screen
    But the NPC is already at the finish line
