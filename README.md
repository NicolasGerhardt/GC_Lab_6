# Week 6 Project: POS Terminal
Pair up with a classmate and write a cash register or self-service terminal for some kind of retial location.

## Requirements
[ ] Your solution must include a product class with a name category, description and price for each item.
[ ] Your store/menu must have 12 items minimum; you can instantiate them from main.
[ ] Present a menu to the user and let them choose an item ordered
    [ ] Allow the user to choose a quantity for the item ordered
    [ ] Give he user a line total (item price * qty)
[ ] Either through the menu or  a separate question, allow them to re-display the menu and to complete the purchase
[ ] When the user asks to cmplete the purchase
    [ ] Give a the subtotal
    [ ] Ask for payment in cash, ask for amount tendered ad provide change
    [ ] Display a receipt with all the items ordered, subtotal, grand total, amount tendered and change
[ ] Return to the original menu for a new order

_You must develop this project with __TDD__ and include all appropriate tests._ Your Solution should ahve a console project including multiple classes, and an XUnit project including a test class for each relevant class from the console project.

One of the things creating this project with TDD will force you to do is to move as much functionality out of main as possible so it's testable. Ideally Main and Program in general will have a minimal code, Primarily for Console input and output, and your other classes will have no consoelinput and output.
