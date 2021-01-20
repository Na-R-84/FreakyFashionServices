# FreakyFashionServices
########

# GET /api/catalog/items
# GET /api/catalog/items/1
# PUT /api/basket/{id}
# GET /api/basket/{id}
# GET /api/productprice?products=ABC123,BCA321,AAA123,BBB123
# POST /api/order
# #####
# API Gateway
# GET /api/products
# PUT /api/basket/{customerIdentifier}
# POST /api/order
#
Du ska ta fram en API Gateway som låter en applikation, såsom exempelvis en single-page -implementation av Freaky Fashion utföra följande operationer:

Hämta samtliga produkter (inklusive pris (catalog service + product price service = aggregering av data)).
Lägga till en produkt i varukorgen.
Lägga en order.

För att få detta på plats kommer du behöva göra följande:

Skapa Order-service som hanterar POST /api/order. Denna kommer i sin tur anropa Basket-service för att hämta ut varukorgen och sen omvandla den till en order som lagras i databas. Vi kommer sedan åt denna via Gateway API.
Skapa ProductPrice-service som hanterar GET /api/productprice?products=ABC123,BCA321,... Denna returnerar en motsvarande lista, innehållandes pris för varje produkt. Det är ok om du genererar priset slumpmässigt i denna servicen.
