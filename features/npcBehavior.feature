Feature: NPC Behavior

  Scenario: NPC always wins the race
    Given the game is launched and the race has started
    When the player and NPC start moving
    Then the NPC always reaches the finish line before the player

  Scenario: NPC follows the predefined path
    Given the game is launched and the race has started
    When the NPC starts moving
    Then the NPC follows the predefined path correctly
