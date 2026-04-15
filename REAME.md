Contains a repository for a case study warehouse data/orders web UI

AI Tools:
Normally I'd use Codex (Which could generate the app based on the swagger json in seconds...), but since I didn't have access to codex on my personal machine, I used chatgpt, etc.

ChatGPT helped refresh my memory on the difference between razor pages and MVC.



Resources used:

Swagger: https://api.casestudy.enterbridge.com/swagger/index.html

api endpoints: https://api.casestudy.enterbridge.com/



Design choices:

.NET 6 - I know it's older... but it's what I have on my home computer. In real life I would use the latest (.NET 10)



Architecture:

A page for product catalog with prices 

A page to view the price history for a product

A page to create an order (Should include templates)

A page to view/edit/delete orders (Communicate edits to the buyer - auto email from business domain?)



