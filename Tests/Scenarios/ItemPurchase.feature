Feature: ItemPurchase

Test to verify a successful purchase of 1 item

@id1
Scenario: User purchases an item
    Given login to the site with username 'standard_user' and password 'secret_sauce'
    When the user adds a bag to the cart
    Then the item should be added to the cart
    And the item details should be correct in the cart
    When the user goes to checkout
    And puts in user  information
    And completes the checkout process
    And the total cost should be correct
    And the purchase should be successful
    Then main page is opened
